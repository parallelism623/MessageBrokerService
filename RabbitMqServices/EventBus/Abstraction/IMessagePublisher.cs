

using RabbitMqServices.EventBus.IntegrationEvents;

namespace RabbitMqServices.EventBus.Abstraction;
public interface IMessagePublisher
{
    public Task PublishMessage(IntegrationEvent @event);
}
