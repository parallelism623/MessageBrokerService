using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqServices.EventBusRabbitMQ;
public class RabbitMqContextOptions<T>
{
    public string? ExchangeName { get; set; }
    private string HostName { get; set; }
    private string? UserName { get; set; }
    private string? Password { get; set; }

    protected internal IConnection SetConnection()
    {
        ConnectionFactory factory = new ConnectionFactory {
            HostName = HostName,
            UserName = UserName,
            Password = Password
        };
        try
        {
            return factory.CreateConnection();
        }
        catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException e)
        {

            throw;
        }
    }
    public void ConnectionToHost(string HostName, string UserName, string Password)
    {
        HostName = HostName ?? throw new ArgumentNullException(nameof(HostName));
        UserName = UserName ?? string.Empty;
        Password = Password ?? string.Empty;
    }
}
