using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RabbitMqServices.EventBus.IntegrationEvents;
public record IntegrationEvent
{
    [JsonInclude]
    public Guid Id { get; set; }

    [JsonInclude]
    public DateTime CreationDate { get; set; }

    [JsonInclude]
    public string RoutingKey { get; set; } = default!;
}
