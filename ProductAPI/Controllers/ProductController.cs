using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(new List<string> { "Kalem", "kitap", "silgi", "defter" });
        }
    }
}