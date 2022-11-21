using KoerselslogApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KoerselslogApp.Repositories
{
    internal class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var sqlConnection = GetSqlConnection())
            using (var sqlCommand = new SqlCommand())
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "select * from [User] where Username=@Username and [Password]=@Password";
                sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = credential.UserName;
                sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = sqlCommand.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string? username)
        {
            UserModel user = null;
            using (var sqlConnection = GetSqlConnection())
            using (var sqlCommand = new SqlCommand())
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Select * from [User] where username=@username";
                sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            Email = reader[3].ToString(),
                            Username =reader[4].ToString(),
                            Password = string.Empty,
                        };
                    }
                }

            }
            return user;
        }

        public void Remove(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
