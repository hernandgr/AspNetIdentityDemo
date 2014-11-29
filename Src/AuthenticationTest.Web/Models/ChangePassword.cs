using System.ComponentModel.DataAnnotations;

namespace AuthenticationTest.Web.Models
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Password must be between 6-40 characters.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}