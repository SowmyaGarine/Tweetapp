using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetAPP.Models;

namespace TweetAPP.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TweetDBContext dbcontext;

        public TweetRepository(TweetDBContext context)
        {
            dbcontext = context;
        }

        public async Task<bool> ForgotPassword(string emailId, string password)
        {
            var result = await dbcontext.User.Where(s => s.EmailId == emailId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Password = password;
                dbcontext.Update(result);
                var response = dbcontext.SaveChanges();
                if( response > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IList<Tweet>> GetAllTweets()
        {
            var result = await dbcontext.Tweets.ToListAsync();
            return result;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var result = await dbcontext.User.Select(p => new User
            {
                FirstName = p.FirstName,
                LastName = p.LastName
            }).ToListAsync();
            return result;
        }

        public async Task<IList<Tweet>> GetTweetsByUser(int userID)
        {
            var result = await dbcontext.Tweets.Where(i => i.UserId == userID).ToListAsync();
            return result;
        }

        public async Task<bool> Login(string emailId, string password)
        {
            User user = await dbcontext.User.SingleOrDefaultAsync(e => e.EmailId == emailId && e.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> PostTweet(Tweet tweet)
        {
            dbcontext.Tweets.Add(tweet);
            var result = await dbcontext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Register(User users)
        {
            dbcontext.User.Add(users);
            var result = await dbcontext.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            var update = await dbcontext.User.Where(x => x.EmailId == emailId && x.Password == oldpassword).FirstOrDefaultAsync();
            if (update != null)
            {
                update.Password = newPassword;
                dbcontext.User.Update(update);
                var result = await dbcontext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<User> ValidateEmailId(string emailId)
        {
            var user = await dbcontext.User.FirstOrDefaultAsync(e => e.EmailId == emailId);
            return user;

        }
    }
}
