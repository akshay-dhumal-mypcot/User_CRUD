using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_CRUD.Data;
using User_CRUD.Model;

namespace User_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var data = await _context.users.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserId(int id)
        {
            var data = await _context.users.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> PostUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> DeleteUser(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet("dummy")]
        public IActionResult GetDummyData()
        {
            var response = new
            {
                success = true,
                message = "Dummy API working successfully",
                serverTime = DateTime.UtcNow,
                data = new[]
                {
            new
            {
                id = 1,
                name = "Akshay",
                email = "akshay@test.com",
                role = "Admin"
            },
            new
            {
                id = 2,
                name = "John",
                email = "john@test.com",
                role = "User"
            }
        }
            };

            return Ok(response);
        }

    }
}
