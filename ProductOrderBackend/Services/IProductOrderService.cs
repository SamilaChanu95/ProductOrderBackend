using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public interface IProductOrderService
    {
        public List<ProductOrder> GetOrderList();
        public ProductOrder GetOrderByNo(int no);
        public bool UpdateOrder(ProductOrder productOrder);
        public bool AddOrder(ProductOrder productOrder);
        public bool DeleteOrderByNo(int no);
    }
}
