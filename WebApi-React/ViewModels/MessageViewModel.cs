using System.ComponentModel.DataAnnotations;

namespace WebApi_React.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
