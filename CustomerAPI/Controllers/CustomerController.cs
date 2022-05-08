using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(new List<string> { "can", "ali" });
        }
    }
}