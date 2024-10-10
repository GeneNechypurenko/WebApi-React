using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi_React.Models;

namespace WebApi_React.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
