using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqServices.EventBusRabbitMQ;
public static class RabbitMqExtension
{
    public delegate void ConfigEventBusRabbitMqDelegate<T>(RabbitMqContextOptions<T> context);

    public static void AddEventBusRabbitMq<T>(this IServiceCollection services, RabbitMqContextOptions<T> config)
    {
        services.AddSingleton(typeof(T), serviceProvider =>
        {
            return ActivatorUtilities.CreateInstance(serviceProvider, typeof(T), config);
        });
    }
}
