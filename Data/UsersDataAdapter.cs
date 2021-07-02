using SandboxGame.Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxGame.Data
{
    public class UsersDataAdapter
    {
        //connection string is different for each user
        string _sqlConnectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=SandboxGame; User Id=user;Password=pass";
        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users ([Username], [Password], [Role], [DateCreated]) VALUES (@Username, @Password, @Role, @DateCreated";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.UserPassword;
                    command.Parameters.Add("@Role", SqlDbType.NVarChar).Value = user.UserRole;
                    command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = user.DateCreated;

                    object result = command.ExecuteNonQuery();
                }
            }
        }

        public User GetUserById(int id)
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                string query = "SELECT [Username], [Password], [Role], [DateCreated] FROM Users WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = reader.GetInt32(0),
                                    UserName = reader.GetString(1),
                                    UserPassword = reader.GetString(2),
                                    UserRole = reader.GetString(3),
                                    DateCreated = reader.GetDateTime(4)
                                };

                                return user;
                            }
                        }
                    }
                }
            }

            return new User();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                string query = "SELECT [Username], [Password], [Role], [DateCreated] FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {                    
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = reader.GetInt32(0),
                                    UserName = reader.GetString(1),
                                    UserPassword = reader.GetString(2),
                                    UserRole = reader.GetString(3),
                                    DateCreated = reader.GetDateTime(4)                                    
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }

            return users;
        }

    }
}
