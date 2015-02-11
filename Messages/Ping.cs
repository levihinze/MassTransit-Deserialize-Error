
using System;
using Messages;

namespace MassTransitTest.Messages
{
    public class Ping : IMessage
    {
        public string Message { get; set; }

        public void PrintMessage()
        {
            Console.WriteLine("Ping: " + Message);
        }
    }
}
