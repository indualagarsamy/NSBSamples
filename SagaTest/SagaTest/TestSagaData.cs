namespace SagaTest
{
    using System;
    using NServiceBus.Saga;

    public class TestSagaData : ContainSagaData
    {
        [Unique]
        public Guid MessageId { get; set; }
    
        internal bool HasAllResponsesArrived()
        {
            if (HasResponse1Arrived && HasResponse2Arrived) return true;
            return false;
        }

        public bool HasResponse1Arrived { get; set; }

        public bool HasResponse2Arrived { get; set; }
    }
}
