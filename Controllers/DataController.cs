using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // GET: api/data
        [HttpGet]
        public IActionResult GetData()
        {
            var response = new
            {
                success = true,
                message = "DataController GET API working successfully",
                serverTime = DateTime.UtcNow,
                data = new[]
                {
                    new { id = 1, name = "Alice", type = "Admin" },
                    new { id = 2, name = "Bob", type = "User" },
                    new { id = 3, name = "Charlie", type = "Guest" }
                }
            };

            return Ok(response);
        }

        // POST: api/data
        [HttpPost]
        public IActionResult PostData([FromBody] object payload)
        {
            var response = new
            {
                success = true,
                message = "DataController POST API received your data",
                serverTime = DateTime.UtcNow,
                received = payload
            };

            return Ok(response);
        }
    }
}
