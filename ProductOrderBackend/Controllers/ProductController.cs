using Microsoft.AspNetCore.Mvc;
using ProductOrderBackend.Model;
using ProductOrderBackend.Services;

namespace ProductOrderBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("product-list")]
        public IActionResult GetProductList()
        {
            var result = _productService.GetProductList();
            return Ok(result);
        }

        [HttpGet]
        [Route("product/{productCode}")]
        public IActionResult GetProductByProductCode([FromRoute] string productCode)
        {
            Product result = _productService.GetProductByPCode(productCode);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-product")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var result = _productService.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-product")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var result = _productService.UpdateProduct(product);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-product/{code}")]
        public IActionResult DeleteProductByProductCode([FromRoute] string code)
        {
            var result = _productService.DeleteProductByPCode(code);
            return Ok(result);
        }

    }
}
