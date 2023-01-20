using LaundryApplication.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Concurrent;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace LaundryApplication.Shared
{
    using UserMap = ConcurrentDictionary<string, User>;
    
    // Storage implementation.  This one stores everything in memory for live access and dumps to files for persistence
    public class MemoryFileStorage : IStorage
    {
        private const string SAVE_FILE = "users.db";
        private UserMap _users = new UserMap();

        public MemoryFileStorage()
        {
            // initialize storage here if necessary!
            LoadUsers();
        }
        public User GetUserFromPhone(string phoneNumber)
        {
            if (_users.ContainsKey(phoneNumber))
            {
                return _users[phoneNumber];
            }
            else
            {
                throw new Exception("Phone Number not found");
            }
        }
        public bool AddUser(string phoneNumber, string name, string email)
        {
            if (!_users.ContainsKey(phoneNumber))
            {
                _users.GetOrAdd(phoneNumber, new User(phoneNumber, name, email));

                SaveUsers();
            }
            else
            {
                throw new Exception("Phone Number in use");
            }
            return true;
        }

        public void SaveUsers()
        {
            try
            {
                using (StreamWriter outStream = new StreamWriter(SAVE_FILE, false))
                {
                    foreach (var user in _users.Values)
                    {
                        user.serialize(outStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LoadUsers()
        {
            _users.Clear();

            try
            {
                using (StreamReader inStream = new StreamReader(SAVE_FILE))
                {
                    while (!inStream.EndOfStream)
                    {
                        User userTemp = new User("", "", "");
                        userTemp.deserialize(inStream);
                        _users.GetOrAdd(userTemp._phoneNumber, userTemp);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
