using System;
using log4net.Config;
using MassTransit;
using MassTransit.Log4NetIntegration;
using Messages;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlConfigurator.Configure();

            var bus = ServiceBusFactory.New(sbc =>
            {
                sbc.ReceiveFrom("msmq://localhost/test_queue");
                sbc.UseMsmq();
                sbc.UseLog4Net();

                sbc.Subscribe(subs => subs.Consumer(() => new MessageConsumer()));
            });

            Console.Read();
        }
    }

    public class MessageConsumer : Consumes<IMessage>.All
    {
        public void Consume(IMessage message)
        {
            message.PrintMessage();
        }
    }
}
