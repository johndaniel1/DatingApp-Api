using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Data
{
    public interface IAuthRepository
    {
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
    }
}
