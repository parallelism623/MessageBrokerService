using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqServices.EventBus.Abstraction;
public interface IMessageConsumer
{
    public Task<T> ConsumMessage<T>();
}
