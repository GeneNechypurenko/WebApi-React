using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_React.Repositories;

namespace WebApi_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MessageRepository _messageRepository;

        public UserController(MessageRepository messageRepository) => _messageRepository = messageRepository;
    }
}
