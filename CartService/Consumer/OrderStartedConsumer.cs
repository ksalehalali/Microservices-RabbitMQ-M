using MassTransit;
using Message.Order.Event;
using System.Threading.Tasks;

namespace CartService.Consumer
{
    public class OrderStartedConsumer : IConsumer<IOrderStartedEvent>
    {
        private readonly IBus _bus;

        public OrderStartedConsumer(IBus bus)
        {
            _bus = bus;
        }
        public async Task Consume(ConsumeContext<IOrderStartedEvent> context)
        {
            // do some sorting of business
            try
            {

                await _bus.Publish<IOrderCancelEvent>(new
                {
                   OrderId = Guid.NewGuid(),
                    PaymentCardNumber=context.Message.PaymentCardNumber,
                    ProductName= context.Message.ProductName
                });

                ///
            }
            catch (Exception ex)
            {
               
            }
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            await Task.CompletedTask;


        }
    }
}
