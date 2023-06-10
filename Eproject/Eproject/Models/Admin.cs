using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Display(Name = "User Name")]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chr Required"), MaxLength(50)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chr Required"), MaxLength(50)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chr Required"), MaxLength(50)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string CPassword { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chr Required"), MaxLength(50)]
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
