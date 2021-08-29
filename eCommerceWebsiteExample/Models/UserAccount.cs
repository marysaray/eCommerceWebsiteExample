using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Models
{
    public class UserAccount
    {
        [Key] // primary key: using attached
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; } // ?: optional
    }

    public class RegisterViewModel
    { 
        [Required]
        public string Email { get; set; }

        [Compare(nameof(Email))]
        [Required]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)] // password box
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)] // password box
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)] // time is ignored
        public DateTime? DateOfBirth { get; set; }
    }
}