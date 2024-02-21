using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomerList();
        public Customer GetCustomerByCode(string code);
        public bool DeleteCustomerByCode(string code);
        public bool CreateCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
    }
}
