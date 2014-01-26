using System;
using NServiceBus;
using Orders.Messages;

namespace Orders.Sender
{
    class OrderPlacedPublisher : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to publish an event. To exit, Ctrl + C");
            var counter = 0;
            while (Console.ReadLine() != null)
            {
                counter++;
                var orderPlaced = new OrderPlaced() { OrderId = "order" + counter};
                Bus.Publish(orderPlaced);
                Console.WriteLine(string.Format("Published OrderPlaced event with order id [{0}].", orderPlaced.OrderId));
            }
        }

        public void Stop()
        {   
        }
    }
}
