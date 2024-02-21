using Npgsql;
using ProductOrderBackend.DataContext;
using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly DBContext _dbContext;
        public ProductOrderService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool AddOrder(ProductOrder productOrder)
        {
            int effectedRow = 0;
            using (var connection = _dbContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_order_insert_product_order(@customerCode, @productCode, @quantity)", connection))
                {
                    command.Parameters.AddWithValue("customerCode", productOrder.CustomerCode);
                    command.Parameters.AddWithValue("productCode", productOrder.ProductCode);
                    command.Parameters.AddWithValue("quantity", productOrder.Quantity);

                    effectedRow = (int)command.ExecuteScalar();
                }
            }
            return effectedRow > 0;
        }

        public bool DeleteOrderByNo(int no)
        {
            int effectedRow = 0;
            using (var connection = _dbContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_order_delete_product_by_id(@orderNo)", connection))
                {
                    command.Parameters.AddWithValue("orderNo", no);

                    effectedRow = (int)command.ExecuteScalar();
                }
            }
            return effectedRow > 0;
        }

        public ProductOrder GetOrderByNo(int no)
        {
            ProductOrder order = new ProductOrder();
            using (var connection = _dbContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.product_order_get_product_by_id(@orderNo)", connection))
                {
                    command.Parameters.AddWithValue("orderNo", no);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order.OrderNo = Convert.ToInt32(reader["order_no"]);
                            order.CustomerCode = Convert.ToString(reader["customer_code"]);
                            order.ProductCode = Convert.ToString(reader["product_code"]);
                            order.Quantity = Convert.ToInt32(reader["quantity"]);
                        }
                    }
                }
            }
            return order;
        }

        public List<ProductOrder> GetOrderList()
        {
            List<ProductOrder> orderList = new List<ProductOrder>();
            using (var connection = _dbContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.product_order_get_product_order_list()", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductOrder order = new ProductOrder();
                            order.OrderNo = Convert.ToInt32(reader["order_no"]);
                            order.CustomerCode = Convert.ToString(reader["customer_code"]);
                            order.ProductCode = Convert.ToString(reader["product_code"]);
                            order.Quantity = Convert.ToInt32(reader["quantity"]);

                            orderList.Add(order);
                        }
                    }
                }
            }
            return orderList;
        }

        public bool UpdateOrder(ProductOrder productOrder)
        {
            int effectedRow = 0;
            using (var connection = _dbContext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.product_order_update_product_order(@orderNo, @productCode, @customerCode, @quantity)", connection))
                {
                    command.Parameters.AddWithValue("orderNo", productOrder.OrderNo);
                    command.Parameters.AddWithValue("productCode", productOrder.ProductCode);
                    command.Parameters.AddWithValue("customerCode", productOrder.CustomerCode);
                    command.Parameters.AddWithValue("quantity", productOrder.Quantity);

                    effectedRow = (int)command.ExecuteScalar();
                }
            }
            return effectedRow > 0;
        }
    }
}
