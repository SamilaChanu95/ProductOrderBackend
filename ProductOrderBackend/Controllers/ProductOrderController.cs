using Microsoft.AspNetCore.Mvc;
using ProductOrderBackend.Model;
using ProductOrderBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOrderBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        private readonly IProductOrderService _productOrderService;
        public ProductOrderController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        [HttpGet]
        [Route("order-list")]
        public IActionResult GetOrderList()
        {
            var result = _productOrderService.GetOrderList();
            return Ok(result);
        }

        [HttpGet]
        [Route("order/{id}")]
        public IActionResult GetOrderByNo([FromRoute] int id)
        {
            var result = _productOrderService.GetOrderByNo(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-order")]
        public IActionResult CreateOrder([FromBody] ProductOrder productOrder)
        {
            var result = _productOrderService.AddOrder(productOrder);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-order")]
        public IActionResult UpdateOrder([FromBody] ProductOrder productOrder)
        {
            var result = _productOrderService.UpdateOrder(productOrder);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-order/{id}")]
        public IActionResult DeleteOrder([FromRoute] int id)
        {
            var result = _productOrderService.DeleteOrderByNo(id);
            return Ok(result);
        }
    }
}
