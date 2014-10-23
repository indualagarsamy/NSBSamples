namespace SagaTest
{
    using System;
    using NServiceBus;

    public class StartSaga : ICommand
    {
        public Guid MessageId { get; set; }
    }
    public class ProcessSomething1 : ICommand
    {
        public Guid MessageId { get; set; }
    }

    public class ProcessSomething2 : ICommand
    {
        public Guid MessageId { get; set; }
    }

    public class ProcessSomething1Response : IMessage
    {
        public Guid MessageId { get; set; }
    }

    public class ProcessSomething2Response : IMessage
    {
        public Guid MessageId { get; set; }
    }
}
