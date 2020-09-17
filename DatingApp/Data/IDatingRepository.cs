using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Data
{
    public interface IDatingRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        bool SaveAll();
        List<User> GetUsers();
        User GetUser(int id);
    }
}
