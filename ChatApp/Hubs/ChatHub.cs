using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static Dictionary<string, string> _connections = new Dictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            var clientId = Context.ConnectionId;

            // Store the client ID along with other user information if needed
            _connections.Add(clientId, ""); // You can store user-related data here
            await base.OnConnectedAsync();
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Client(clientId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
