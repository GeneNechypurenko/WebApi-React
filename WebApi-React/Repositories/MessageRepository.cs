using Microsoft.EntityFrameworkCore;
using WebApi_React.Data;
using WebApi_React.Models;

namespace WebApi_React.Repositories
{
    public class MessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _context.Messages.OrderByDescending(m => m.PostedAt).ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
    }
}
