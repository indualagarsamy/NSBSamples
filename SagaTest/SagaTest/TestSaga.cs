namespace SagaTest
{
    using System;
    using NServiceBus;
    using NServiceBus.Saga;

    public class TestSaga : Saga<TestSagaData>,
        IAmStartedByMessages<StartSaga>,
        IHandleMessages<ProcessSomething1Response>,
        IHandleMessages<ProcessSomething2Response>       
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<ProcessSomething1Response>(message => message.MessageId).ToSaga(data => data.MessageId);
            ConfigureMapping<ProcessSomething2Response>(message => message.MessageId).ToSaga(data => data.MessageId);
        }

        public void Handle(StartSaga message)
        {
            Console.WriteLine("Received message StartSaga");
            Data.MessageId = message.MessageId;
           
            Bus.Send(new ProcessSomething1()
            {
                MessageId = message.MessageId
            });
            Bus.Send(new ProcessSomething2()
            {
                MessageId = message.MessageId
            });
            Console.WriteLine("StartSaga was successfuly processed.");
        }

        public void Handle(ProcessSomething1Response message)
        {
            Data.HasResponse1Arrived = true;
            Console.WriteLine("Received ProcessSomething1Response");
            if (Data.HasAllResponsesArrived())
            {
                Console.WriteLine("Saga is complete");
                MarkAsComplete();
            }
        }

        public void Handle(ProcessSomething2Response message)
        {
            Data.HasResponse2Arrived = true;
            Console.WriteLine("Received ProcessSomething2Response");
            if (Data.HasAllResponsesArrived())
            {
                Console.WriteLine("Saga is complete");
                MarkAsComplete();
            }
        }
    }
}




