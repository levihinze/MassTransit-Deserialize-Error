using System;
using MassTransit;
using MassTransit.BusServiceConfigurators;
using MassTransit.Services.Routing.Configuration;
using MassTransitTest.Messages;

namespace MassTransitTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var routing = new RoutingConfigurator();
            routing.Route<Ping>().To("msmq://localhost/test_queue");

            var bus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom("msmq://localhost/test_queue_sender");
                sbc.UseMsmq();
                sbc.AddBusConfigurator(new CustomBusServiceConfigurator(routing));
            });

            var message = "";
            do
            {
                message = Console.ReadLine();
                //broadcast the message
                bus.Publish(new Ping { Message = message });
            } while (message != "exit");
        }
    }
}
