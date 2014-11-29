using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationTest.Web.Models
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]        
        public string ConfirmPassword { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }        
    }
}