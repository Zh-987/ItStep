using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PersonalInformations
    {
        public Guid Id { get; set; } //Id первый первичный ключ 

        [Required(ErrorMessage ="Fill login")]
        [Display(Name = "User login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [Display(Name = "Password")]
        public string Password { get; set;}

        //public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Fill Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Fill Year Of Birth")]
        [Display(Name = "Year Of Birth")]
        public DateTime YearOfBirth { get; set; } 

    }
}
