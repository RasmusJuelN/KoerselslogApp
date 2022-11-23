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
    internal class AdminRepository : RepositoryBase, IAdminRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var sqlConnection = GetSqlConnection())
            using (var sqlCommand = new SqlCommand())
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "select * from [Admin] where Username=@Username and [Password]=@Password";
                sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = credential.UserName;
                sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = sqlCommand.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }
        public AdminModel GetByUsername(string? username)
        {
            AdminModel admin = null;
            using var sqlConnection = GetSqlConnection();
            using var sqlCommand = new SqlCommand();
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Select * from [Admin] where username=@username";
                sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using var reader = sqlCommand.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        admin = new AdminModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty
                        };
                    }
                }
            }
            return admin;
        }
    }

}
