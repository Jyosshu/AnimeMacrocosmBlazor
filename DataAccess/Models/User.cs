using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [EmailAddress]
        public string UserEmailAddress { get; set; }

        [Required]
        public string UserScreenName { get; set; }
    }
}
