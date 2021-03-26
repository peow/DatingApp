using System;
using System.Threading.Tasks;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    [Authorize]
    public class PresenceHub : Hub
    {
        private readonly PresenceTracker _tracker;
        public PresenceHub(PresenceTracker tracker)
        {
            _tracker = tracker;

        }
        public override async Task OnConnectedAsync()
        {
            // Update the presence tracker
            var isOnline = await _tracker.UserConncted(Context.User.GetUsername(), Context.ConnectionId);
            
            if(isOnline)            
                await Clients.Others.SendAsync("UserIsOnline", Context.User.GetUsername());            

            // send back all connected users
            var currentUSers = await _tracker.GetOnlineUsers();
            await Clients.Caller.SendAsync("GetOnlineUsers", currentUSers);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Update the presence tracker
            var isOffline = await _tracker.UserDisconnected(Context.User.GetUsername(), Context.ConnectionId);

            if(isOffline)            
                await Clients.Others.SendAsync("UserIsOffline", Context.User.GetUsername());            

            await base.OnDisconnectedAsync(exception);
        }
    }
}