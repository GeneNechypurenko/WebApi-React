namespace WebApi_React.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
