using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetAPP.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
