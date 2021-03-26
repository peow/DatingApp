using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalR
{
    /// <summary>
    ///     PresenceTracker is not scaleable, if you want to use more than one server, 
    ///     you have to define a reader.
    /// </summary>
    public class PresenceTracker
    {

        /// <summary>
        ///     Not threadsafe by default, needs to be locked
        /// </summary>        
        private static readonly Dictionary<string, List<string>> OnlineUsers = new Dictionary<string, List<string>>();

        public Task<bool> UserConncted(string username, string connectionId)
        {
            var isOnline = false;
            // lock the dictionary
            lock(OnlineUsers)
            {
                if(OnlineUsers.ContainsKey(username))
                {
                    OnlineUsers[username].Add(connectionId);
                }
                else 
                {
                    OnlineUsers.Add(username, new List<string>{connectionId});
                    isOnline = true;
                }                
            }
            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(string username, string connectionId)
        {
            var isOffline = false;
            lock(OnlineUsers)
            {
                if(!OnlineUsers.ContainsKey(username)) return Task.FromResult(isOffline);
                OnlineUsers[username].Remove(connectionId);
                if(OnlineUsers[username].Count == 0)
                {
                    OnlineUsers.Remove(username);
                    isOffline = true;
                }
            }
            return Task.FromResult(isOffline);
        }

        public Task<string[]> GetOnlineUsers()
        {
            string[] onlineUsers;
            lock(OnlineUsers)
            {
                onlineUsers = OnlineUsers
                    .OrderBy(k => k.Key)
                    .Select(k => k.Key)
                    .ToArray();                
            }
            return Task.FromResult(onlineUsers);
        }

        public Task<List<string>> GetConnectionsForUser(string username)
        {
            List<string> connectionsIds;
            lock(OnlineUsers)
            {
                connectionsIds = OnlineUsers.GetValueOrDefault(username);
            }

            return Task.FromResult(connectionsIds);
        }
    }
}