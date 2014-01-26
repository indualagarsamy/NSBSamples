using NServiceBus;

namespace Orders.Sender
{
    class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher {}

    class ConfigurePersistence : INeedInitialization
    {
        public void Init()
        {
            Configure.Instance
                .UseNHibernateSubscriptionPersister() // subscription storage using NHibernate
                .UseNHibernateTimeoutPersister() // Timeout Persistance using NHibernate
                .UseNHibernateSagaPersister(); // Saga Persistance using NHibernate
        }
    }
}
