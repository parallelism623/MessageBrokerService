using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqServices.EventBusRabbitMQ;
public class RabbitMqContext
{
    public RabbitMqContext(RabbitMqContextOptions<RabbitMqContext> options)
    {
        connection = options.SetConnection();
        _exchangeName = options.ExchangeName;
    }
    private string _exchangeName;

    public string GetExchangeName()
    {
        return _exchangeName ?? string.Empty; 
    }
    private IConnection connection { get; set; }

    public IConnection GetConnection() => connection;

    public void CloseConnection() => connection?.Close();

    public void Dispose() => connection?.Dispose();
}
