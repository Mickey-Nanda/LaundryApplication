using LaundryApplication.Models;

namespace LaundryApplication.Shared
{
    public interface ISessionInfo
    {
        public User GetCurrentUser(string sessionId);
        public void SetCurrentUser(string sessionId, User user);
    }
}
