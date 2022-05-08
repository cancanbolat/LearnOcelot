
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Login(string userName, string password)
        {
            TokenHandler.configuration = configuration;
            return Ok(userName == "can" && password == "123456789" ? TokenHandler.CreateAccessToken() : new UnauthorizedResult());
        }
    }
}