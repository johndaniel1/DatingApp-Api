using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DatingApp.Models;

namespace DatingApp.Data
{
    public class DatingRepository<T> : IDatingRepository <T> where T : class
    {
        private readonly DataContext _context = null;
        public DbSet<T> table = null;

        public DatingRepository()
        {
            _context = new DataContext();
            table = _context.Set<T>();
        }

            public DatingRepository(DataContext context)
            {
                _context = context;
                table = _context.Set<T>();
            }

            public void Add(T entity)
            {
            table.Add(entity);
            }

            public void Delete(T entity) 
            {
                table.Remove(entity);
            }

            public User GetUser(int id)
            {
                var user = _context.Users.Include(p => p.Photos).FirstOrDefault(u => u.Id == id);

                return user;
            }

            public List<User> GetUsers()
            {
                var users = _context.Users.Include(p => p.Photos).ToList();

                return users;
            }

            public bool SaveAll()
            {
                return _context.SaveChanges() > 0;
            }            
    }
}