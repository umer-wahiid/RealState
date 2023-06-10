using System.ComponentModel.DataAnnotations;
namespace Eproject.Models
{
    public class Login
    {
        public int id { get; set; }
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
        [Required]
        [MinLength(11, ErrorMessage = "Min 11 Chr Required"), MaxLength(20)]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        [MinLength(10, ErrorMessage = "Min 10 Chr Required"), MaxLength(250)]
        public string HAddress { get; set; }
    }
}
