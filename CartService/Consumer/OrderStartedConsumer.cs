using MassTransit;
using Message.Order.Event;
using System.Threading.Tasks;

namespace CartService.Consumer
{
    public class OrderStartedConsumer : IConsumer<IOrderStartedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderStartedEvent> context)
        {
            // do some sorting of business
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            await Task.CompletedTask;
        }
    }
}
