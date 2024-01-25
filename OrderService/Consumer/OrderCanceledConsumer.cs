using MassTransit;
using Message.Order.Event;
using OrderService.Controllers;

namespace OrderService.Consumer
{
    public class OrderCanceledConsumer : IConsumer<IOrderCancelEvent>
    {
        public OrderCanceledConsumer()
        {
            
        }
        public async Task Consume(ConsumeContext<IOrderCancelEvent> context)
        {
            // do some sorting of business
        

            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            await Task.CompletedTask;
        }
    }
}
