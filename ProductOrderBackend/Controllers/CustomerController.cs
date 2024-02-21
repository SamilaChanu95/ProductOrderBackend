using Microsoft.AspNetCore.Mvc;
using ProductOrderBackend.Model;
using ProductOrderBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOrderBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customer-list")]
        public IActionResult GetCustomerList()
        {
            var result = _customerService.GetCustomerList();
            return Ok(result);
        }

        [HttpGet]
        [Route("customer/{code}")]
        public IActionResult GetCustomerByCustomerCode([FromRoute] string code)
        {
            Customer customer = _customerService.GetCustomerByCode(code);
            return Ok(customer);
        }

        [HttpPost]
        [Route("create-customer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            bool result = _customerService.CreateCustomer(customer);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-customer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-customer/{code}")]
        public IActionResult DeleteCustomerByCustomerCode([FromRoute] string code)
        {
            var result = _customerService.DeleteCustomerByCode(code);
            return Ok(result);
        }
    }
}
