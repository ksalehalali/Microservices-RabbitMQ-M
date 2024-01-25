using MassTransit;
using Message.Order.Event;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ILogger<OrderController> _logger;
        public bool connected { get; set; } =false;
        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }


    
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderPrice orderModel)
        {
            _logger.LogInformation("CreateOrder called with OrderId: {OrderId}", orderModel.OrderId);
            // do some sorting of business
            try
            {
                _logger.LogInformation("Publishing IOrderStartedEvent");
              
                await _bus.Publish<IOrderStartedEvent>(new
                {
                    orderModel.OrderId,
                    orderModel.PaymentCardNumber,
                    orderModel.ProductName
                });

                _logger.LogInformation("IOrderStartedEvent published successfully");
               
                return Ok("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while publishing IOrderStartedEvent");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
