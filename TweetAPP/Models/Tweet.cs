using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetAPP.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Tweets { get; set; }

    }
}
