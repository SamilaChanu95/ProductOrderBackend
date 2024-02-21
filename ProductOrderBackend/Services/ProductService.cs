using Npgsql;
using ProductOrderBackend.DataContext;
using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly DBContext _dBContext;

        public ProductService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Product> GetProductList()
        {
            List<Product> ProductsList = new List<Product>();
            using (var connection = _dBContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.product_get_product_list()", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                ProductCode = Convert.ToString(reader["product_code"]),
                                ProductName = Convert.ToString(reader["product_name"]),
                                Discount = Convert.ToDouble(reader["discount"]),
                                UnitPrice = Convert.ToDouble(reader["unit_price"]),
                            };
                            ProductsList.Add(product);
                        }
                    }
                }
            }
            return ProductsList;
        }

        public Product GetProductByPCode(string code)
        {
            Product product = new Product();
            using (var connection = _dBContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.product_get_product_by_code(@productCode)", connection))
                {
                    command.Parameters.AddWithValue("productCode", code);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductCode = Convert.ToString(reader["product_code"]),
                                ProductName = Convert.ToString(reader["product_name"]),
                                Discount = Convert.ToDouble(reader["discount"]),
                                UnitPrice = Convert.ToDouble(reader["unit_price"])
                            };
                        }
                    }
                }
            }
            return product;
        }

        public bool DeleteProductByPCode(string code)
        {
            int effectedRows = 0;
            using (var connection = _dBContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_delete_product(@productCode)", connection))
                {
                    command.Parameters.AddWithValue("productCode", code);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }
            return (effectedRows > 0);
        }

        public bool CreateProduct(Product product)
        {
            int effectedRows = 0;
            using (var connection = _dBContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_insert_product(@productCode,@productName,@discount,@unitPrice)", connection))
                {
                    command.Parameters.AddWithValue("productCode", product.ProductCode);
                    command.Parameters.AddWithValue("productName", product.ProductName);
                    command.Parameters.AddWithValue("discount", product.Discount);
                    command.Parameters.AddWithValue("unitPrice", product.UnitPrice);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }
            return (effectedRows > 0);
        }

        public bool UpdateProduct(Product product)
        {
            int effectedRows = 0;
            using (var connection = _dBContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_update_product(@productCode, @productName, @discount, @unitPrice)", connection))
                {
                    command.Parameters.AddWithValue("productCode", product.ProductCode);
                    command.Parameters.AddWithValue("productName", product.ProductName);
                    command.Parameters.AddWithValue("discount", product.Discount);
                    command.Parameters.AddWithValue("unitPrice", product.UnitPrice);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }
            return (effectedRows > 0);
        }
    }
}
