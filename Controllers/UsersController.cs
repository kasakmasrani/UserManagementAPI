using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        // GET users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetAllUsers());
        }

        // GET user by id
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _service.GetUserById(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // POST user
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = _service.AddUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        // PUT user
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (!_service.UpdateUser(id, user))
                return NotFound("User not found");

            return Ok("User updated");
        }

        // DELETE user
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_service.DeleteUser(id))
                return NotFound("User not found");

            return Ok("User deleted");
        }
    }
}