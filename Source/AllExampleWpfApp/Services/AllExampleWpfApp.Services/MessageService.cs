using AllExampleWpfApp.Services.Interfaces;

namespace AllExampleWpfApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
