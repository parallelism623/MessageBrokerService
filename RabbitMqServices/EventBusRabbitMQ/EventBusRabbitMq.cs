using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using  RabbitMqServices.EventBus.Abstraction;
using RabbitMqServices.EventBus.IntegrationEvents;
using System.Text.Json;
namespace RabbitMqServices.EventBusRabbitMQ;
public class EventBusRabbitmq(ILogger<EventBusRabbitmq> logger, RabbitMqContext context) : IMessageConsumer, IMessagePublisher
{

    public Task PublishMessage(IntegrationEvent @event)
    {
        logger.LogTrace($"Starting send event by id: {@event.Id}");
        
        var routingKey = @event.RoutingKey;

        using var channel = context.GetConnection()?.CreateModel() ?? throw new InvalidOperationException("RabbitMQ connection is not open");

        channel.ExchangeDeclare(exchange: context.GetExchangeName(), type: "topic", durable: true, autoDelete: false);

        var body = SerializeMessage(@event);

        try
        {
            var properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            channel.BasicPublish(exchange: context.GetExchangeName(),
                    routingKey: routingKey, basicProperties: properties, body: body);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public Task<T> ConsumMessage<T>()
    {
        throw new NotImplementedException();
    }


    private IntegrationEvent DeserializeMessage(string message, Type eventType)
    {
        return JsonSerializer.Deserialize(message, eventType) as IntegrationEvent;
    }

    private byte[] SerializeMessage(IntegrationEvent @event)
    {
        return JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType());
    }

}
