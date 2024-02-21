using ProductOrderBackend.Model;

namespace ProductOrderBackend.Services
{
    public interface IProductService
    {
        public List<Product> GetProductList();
        public Product GetProductByPCode(string code);
        public bool DeleteProductByPCode(string code);
        public bool CreateProduct(Product product);
        public bool UpdateProduct(Product product);
    }
}
