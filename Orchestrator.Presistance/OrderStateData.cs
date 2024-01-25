﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrator.Presistance
{
    public class OrderStateData :SagaStateMachineInstance
    {
        [Key]
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderFinishedDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentCardNumber { get; set; }
        public string ProductName { get; set; }
        public bool IsCanceled { get; set; } = false;
        public string Exception { get; set; }
    }
}
