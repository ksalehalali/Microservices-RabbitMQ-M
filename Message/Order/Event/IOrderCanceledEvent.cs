using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Order.Event
{
    internal interface IOrderCanceledEvent
    {
        public Guid OrderId { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
