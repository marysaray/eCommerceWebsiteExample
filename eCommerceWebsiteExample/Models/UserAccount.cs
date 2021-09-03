using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Models
{
    /// <summary>
    /// Associated with an individual's account
    /// </summary>
    public class UserAccount
    {
        [Key] // primary key: using attached
        public int UserId { get; set; }

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional date of birth when registering
        /// </summary>
        public DateTime? DateOfBirth { get; set; } // ?: optional
    }

    /// <summary>
    /// The registration form with data annotation validation
    /// </summary>
    public class RegisterViewModel
    { 
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Compare(nameof(Email))]
        [Required]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)] // password box
        [StringLength(120, MinimumLength = 6, ErrorMessage = "Password must be between {2} and {1}")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)] // password box
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)] // time is ignored
        public DateTime? DateOfBirth { get; set; }
    }

    /// <summary>
    /// The user login form
    /// with data annotation validation
    /// </summary>
    public class LoginViewModel
    { 
        [Required]
        [Display(Name = "Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}