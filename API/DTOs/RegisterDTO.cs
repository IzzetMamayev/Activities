<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;

>>>>>>> b79556de721255f51d5ead6e5c85af09cf666b3b
namespace API.DTOs
{
    public class RegisterDTO
    {
<<<<<<< HEAD
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
=======
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }

        [Required]
>>>>>>> b79556de721255f51d5ead6e5c85af09cf666b3b
        public string UserName{ get; set; }
    }
}