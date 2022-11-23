using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KoerselslogApp.Models
{
    internal interface IAdminRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        AdminModel GetByUsername(string username);
    }
}
