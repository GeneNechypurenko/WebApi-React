using Microsoft.AspNetCore.Mvc;
using WebApi_React.Models;
using WebApi_React.Repositories;
using WebApi_React.ViewModels;

namespace WebApi_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageRepository _messageRepository;

        public MessageController(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("all-messages")]
        public async Task<IActionResult> Index()
        {
            var messages = await _messageRepository.GetMessagesAsync();
            return Ok(messages);
        }

        [HttpPost("add-message")]
        public async Task<IActionResult> AddMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new Message
                {
                    Text = model.Text,
                    Username = HttpContext.Session.GetString("Username"),
                    PostedAt = DateTime.Now
                };

                await _messageRepository.AddMessageAsync(message);
                return Ok();
            }

            return BadRequest(ModelState);
        }


        [HttpGet("guestbook-entries")]
        public async Task<IActionResult> PartialGuestBookEntries()
        {
            var messages = await _messageRepository.GetMessagesAsync();
            return Ok(messages);
        }
    }
}
