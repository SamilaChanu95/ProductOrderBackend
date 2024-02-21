using Npgsql;
using ProductOrderBackend.DataContext;
using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DBContext _dbcontext;

        public CustomerService(DBContext dBContext)
        {
            _dbcontext = dBContext;
        }

        public bool CreateCustomer(Customer customer)
        {
            int effectedRows = 0;
            using (var connection = _dbcontext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.customer_insert_customer(@customerCode, @customerName, @customerAddress, @customerBadge, @customerDiscount)", connection))
                {
                    command.Parameters.AddWithValue("customerCode", customer.CustomerCode);
                    command.Parameters.AddWithValue("customerName", customer.CustomerName);
                    command.Parameters.AddWithValue("customerAddress", customer.CustomerAddress);
                    command.Parameters.AddWithValue("customerBadge", customer.CustomerBadge);
                    command.Parameters.AddWithValue("customerDiscount", customer.CustomerDiscount);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }

            return (effectedRows > 0);
        }

        public bool DeleteCustomerByCode(string code)
        {
            int effectedRows = 0;
            using (var connection = _dbcontext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.customer_delete_customer(@customerCode)", connection))
                {
                    command.Parameters.AddWithValue("customerCode", code);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }

            return (effectedRows > 0);
        }

        public Customer GetCustomerByCode(string code)
        {
            var customer = new Customer();
            using (var connection = _dbcontext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.customer_get_customer_by_code(@customerCode)", connection))
                {
                    command.Parameters.AddWithValue("customerCode", code);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer.CustomerCode = Convert.ToString(reader["customer_code"]);
                            customer.CustomerName = Convert.ToString(reader["customer_name"]);
                            customer.CustomerAddress = Convert.ToString(reader["customer_address"]);
                            customer.CustomerBadge = Convert.ToInt32(reader["customer_badge"]);
                            customer.CustomerDiscount = Convert.ToDouble(reader["customer_discount"]);
                        }
                    }
                }
            }
            return customer;
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> customerList = new List<Customer>();
            using (var connection = _dbcontext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM development.customer_get_customer_list()", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();

                            customer.CustomerCode = Convert.ToString(reader["customer_code"]);
                            customer.CustomerName = Convert.ToString(reader["customer_name"]);
                            customer.CustomerAddress = Convert.ToString(reader["customer_address"]);
                            customer.CustomerBadge = Convert.ToInt32(reader["customer_badge"]);
                            customer.CustomerDiscount = Convert.ToDouble(reader["customer_discount"]);

                            customerList.Add(customer);
                        }
                    }
                }
            }
            return customerList;
        }

        public bool UpdateCustomer(Customer customer)
        {
            int effectedRows = 0;
            using (var connection = _dbcontext.CreateDBConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT development.customer_update_customer(@customerCode, @customerName, @customerAddress, @customerBadge, @customerDiscount)", connection))
                {
                    command.Parameters.AddWithValue("customerCode", customer.CustomerCode);
                    command.Parameters.AddWithValue("customerName", customer.CustomerName);
                    command.Parameters.AddWithValue("customerAddress", customer.CustomerAddress);
                    command.Parameters.AddWithValue("customerBadge", customer.CustomerBadge);
                    command.Parameters.AddWithValue("customerDiscount", customer.CustomerDiscount);

                    effectedRows = (int)command.ExecuteScalar();
                }
            }
            return effectedRows > 0;
        }
    }
}
