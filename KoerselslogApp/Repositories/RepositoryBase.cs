using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoerselslogApp.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        
        public RepositoryBase()
        {
            _connectionString = @"Server=192.168.23.122, 1433;Initial Catalog=KoerselslogAppDB;Persist Security Info=True;User ID=sa;Password=Rambam111";
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
