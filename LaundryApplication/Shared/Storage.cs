using LaundryApplication.Models;

namespace LaundryApplication.Shared
{
    public interface IStorage
    {
        User GetUserFromPhone(string phoneNumber);
        bool AddUser(string phoneNumber, string name, string email);
    }
}
