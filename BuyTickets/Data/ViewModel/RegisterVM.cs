using System.ComponentModel.DataAnnotations;

namespace BuyTickets.Data.ViewModel
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email Address is required")]
        public string EmailAddress { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirmation of Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
