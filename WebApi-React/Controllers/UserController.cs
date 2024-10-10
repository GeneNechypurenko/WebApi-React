using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_React.Models;
using WebApi_React.Repositories;
using WebApi_React.ViewModels;

namespace WebApi_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository) => _userRepository = userRepository;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", model.Username);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userRepository.GetUserByUsernameAsync(model.Username);
                if (existingUser == null)
                {
                    var user = new User
                    {
                        Username = model.Username,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),

                    };

                    await _userRepository.AddUserAsync(user);
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }
    }
}
