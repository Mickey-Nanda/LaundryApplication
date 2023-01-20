using LaundryApplication.Models;
using System.Collections.Concurrent;

namespace LaundryApplication.Shared
{
    using SessionUserMap = ConcurrentDictionary<string, User>;

    // class used to store session specific data.  
    public class SessionManager : ISessionInfo
    {
        SessionUserMap _users = new SessionUserMap();

        public LaundryApplication.Models.User GetCurrentUser(string sessionId)
        {
            if (_users.ContainsKey(sessionId))
            {
                return _users[sessionId];
            }
            else
            {
                throw new Exception("No user in specified session");
            }
        }

        public void SetCurrentUser(string sessionId, User user)
        {
            if (_users.ContainsKey(sessionId))
            {
                User? discarded;
                _users.Remove(sessionId, out discarded);
            }

            _users.GetOrAdd(sessionId, user);
        }
    }
}
