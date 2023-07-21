using SandboxGame.Data;
using SandboxGame.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxGame.Services
{
    public class UserService
    {
        private UsersDataAdapter _usersDataAdapter;

        public UserService()
        {
            _usersDataAdapter = new UsersDataAdapter();
        }

        public void InsertUser(string name, string role, string password)
        {            User user = new User
            {
                UserName = name,
                UserRole = role,
                DateCreated = DateTime.Now,
                UserPassword = password
            };

            _usersDataAdapter.CreateUser(user);
        }

        public List<User> GetUsers()
        {
            return _usersDataAdapter.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _usersDataAdapter.GetUserById(id);
        }
    }
}
