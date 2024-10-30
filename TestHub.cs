using Microsoft.AspNetCore.SignalR;

namespace EGC.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendTestMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}