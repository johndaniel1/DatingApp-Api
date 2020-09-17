
using AutoMapper;
using DatingApp.Data;
using DatingApp.Dtos;
using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingApp.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IDatingRepository<User> _repo;
        //private readonly IConfiguration _config;
        public UsersController()
        {
            _repo = new DatingRepository<User>();
        }
        public UsersController(IDatingRepository<User> repo)
        {
            // _config = config;
            _repo = repo;
        }
        public IHttpActionResult GetUsers()
        {
           List<User> users = _repo.GetUsers();

            var usersToReturn = Mapper.Map<List<User>, List<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        
        public IHttpActionResult GetUser(int id)
        {
            User user = _repo.GetUser(id);

            var userToReturn = Mapper.Map<User, UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}