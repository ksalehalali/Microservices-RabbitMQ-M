using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Order.Event
{
    public interface IOrderCancelEvent
    {

        public Guid OrderId { get; set; }

        public string PaymentCardNumber { get; set; }

        public string ProductName { get; set; }
    }
}
