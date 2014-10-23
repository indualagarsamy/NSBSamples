namespace SagaTest
{
    using System;
    using NServiceBus;

    class Handlers : IHandleMessages<ProcessSomething1>, IHandleMessages<ProcessSomething2>
    {
        public IBus Bus { get; set; }
        public void Handle(ProcessSomething1 message)
        {
            Console.WriteLine("Sending response to ProcessSomething1");
            Bus.Reply(new ProcessSomething1Response(){MessageId = message.MessageId});
        }

        public void Handle(ProcessSomething2 message)
        {

            Console.WriteLine("Sending response to ProcessSomething2");
            Bus.Reply(new ProcessSomething2Response() { MessageId = message.MessageId });
        }
    }
}
