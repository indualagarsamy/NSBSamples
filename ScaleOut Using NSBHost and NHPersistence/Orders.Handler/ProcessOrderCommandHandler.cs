using NServiceBus;
using Orders.Messages;

namespace Orders.Handler
{
    using System;

    public class ProcessOrderCommandHandler : IHandleMessages<OrderPlaced>
    {
        public IBus Bus { get; set; }
        public void Handle(OrderPlaced orderPlaced)
        {
            Console.Out.WriteLine("Received OrderPlaced event, order Id: " + orderPlaced.OrderId);
            
        }
    }
}
