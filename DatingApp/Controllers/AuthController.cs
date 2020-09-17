using DatingApp.Data;
using DatingApp.Dtos;
using DatingApp.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace DatingApp.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthRepository _repo;
        //private readonly IConfiguration _config;
        public AuthController()
        {
            _repo = new AuthRepository();
        }
        public AuthController(IAuthRepository repo)
        {
           // _config = config;
            _repo = repo;
        }

        [HttpPost]
        public IHttpActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if ( _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            User createdUser = _repo.Register(userToCreate, userForRegisterDto.Password);

            return Content(HttpStatusCode.Created, "User Created Successfully");
        }

        [HttpPost]
        public  IHttpActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(ConfigurationManager.AppSettings["Token"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}
