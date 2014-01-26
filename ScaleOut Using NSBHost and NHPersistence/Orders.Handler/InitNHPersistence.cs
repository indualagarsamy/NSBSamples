using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Orders.Handler
{
    class InitNHPersistence : INeedInitialization
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
