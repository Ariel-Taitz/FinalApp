using FinalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.Service
{
    public class DBMokup
    {
        private static List<User> _users;
        public DBMokup()
        {
            _users = new List<User>();
            _users.Add(new User { FirstName = "Tomer", LastName = "Marty", UEmail = "admin@mail.com", UPassword = "admin" });
            _users.Add(new User { FirstName = "Amir", LastName = "Mayo", UEmail = "user1@mail.com", UPassword = "pass1" });
            _users.Add(new User { FirstName = "Galit", LastName = "Nuvy", UEmail = "user2@mail.com", UPassword = "pass2" });
        }
        public List<User> GetUsers() { return _users; }
        public bool isExist(string uEmail, string uPass) { return _users.Any(u => u.UEmail == uEmail && u.UPassword == uPass); }
        public User? GetUser(string uEmail, string uPass) { return _users.FirstOrDefault(u => u.UEmail == uEmail && u.UPassword == uPass); }
        public void AddUser(User user) { if (user != null) { _users.Add(user); } }
        public void RemoveUser(User user) { if (user != null && _users.Contains(user)) { _users.Remove(user); } }
        public static void UpdateUser(User user)
        {
            if (user != null && _users.Contains(user))
            {
                var index = _users.IndexOf(user);
                if (index >= 0)
                {
                    _users[index] = user;
                }
            }
        }
        public bool GetUserByEmail(string email)
        {
            return _users.Any(u => u.UEmail == email);
        }
    }
}
