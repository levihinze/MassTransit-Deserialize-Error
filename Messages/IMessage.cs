
namespace Messages
{
    public interface IMessage
    {
        string Message { get; set; }

        void PrintMessage();
    }
}
