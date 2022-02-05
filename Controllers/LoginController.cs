using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Dependency injection for configuration
        private readonly IConfiguration _config;

        //Constructor injection
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        //HTTP post method /api/login/token
        [HttpPost("token")]
        public IActionResult Login([FromBody]Login login)
        {
            //Checking Unauthorized
            IActionResult response = Unauthorized();

            //Authenticate user
            var user = Authenticate(login);
            if (user != null)
            {
                var tokenString = GenerateToken(login);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        //Generating Token
        private string GenerateToken(Login login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Authenticating user
        private object Authenticate(Login login)
        {
            Login user = null;
            if (login.Username == "Arshin" && login.Password == "IHaveAPassword")
            {
                user = new Login
                {
                    Username = "Arshin",
                    Password = "IHaveAPassword"
                };
            }
            return user;
        }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
