namespace SagaTest
{
    using System;
    using NServiceBus;

    class Bootstrapper : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        public void Start()
        {
            Console.WriteLine("Press enter to begin the Saga");
            while (Console.ReadLine() != null)
            {
                Bus.SendLocal(new StartSaga()
                {
                    MessageId = Guid.NewGuid()
                });
            }
        }

        public void Stop()
        {
            
        }
    }
}
