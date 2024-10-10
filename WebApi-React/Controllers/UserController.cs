using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_React.Repositories;
using WebApi_React.ViewModels;

namespace WebApi_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MessageRepository _messageRepository;

        public UserController(MessageRepository messageRepository) => _messageRepository = messageRepository;

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", model.Username);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
