using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetAPP.Models
{
    public class TweetDBContext: DbContext
    {
        public TweetDBContext()
        {
        }

        public TweetDBContext(DbContextOptions<TweetDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Define connection string
           optionsBuilder.UseSqlServer(@"Data Source=Lab-63752164105;Initial Catalog=TweetAppDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
        }
    }
}
