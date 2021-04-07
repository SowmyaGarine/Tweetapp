using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TweetAPP.Models;
using TweetAPP.Service;

namespace TweetAPP.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetAppController : ControllerBase
    {
        private readonly ITweetAppService tweetAppService;
        private ILogger<TweetAppController> logger;

        public TweetAppController(ITweetAppService tweetAppService, ILogger<TweetAppController> logger)
        {
            this.tweetAppService = tweetAppService;
            this.logger = logger;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>response.</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var result = await this.tweetAppService.UserRegister(user);
                return Ok(result);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string emailID, string password)
        {
            try
            {
                var result = await this.tweetAppService.UserLogin(emailID, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Post Tweet.
        /// </summary>
        /// <param name="tweet">tweet.</param>
        /// <returns>response.</returns>
        [HttpPost]
        [Route("tweet")]
        public async Task<IActionResult> Tweet(Tweet tweet)
        {
            try
            {
                var result = await this.tweetAppService.PostTweet(tweet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await this.tweetAppService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Get All Tweets.
        /// </summary>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("alltweets")]
        public async Task<IActionResult> GetAllTweets()
        {
            try
            {
                var result = await this.tweetAppService.GetAllTweets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Update Password.
        /// </summary>
        /// <returns>response.</returns>
        [HttpPut]
        [Route("updatepassword")]
        public async Task<IActionResult> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                var result = await this.tweetAppService.UpdatePassword(emailId, oldpassword, newPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Forgot Password.
        /// </summary>
        /// <returns>response.</returns>
        [HttpPut]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string emailId, string password)
        {
            try
            {
                var result = await this.tweetAppService.ForgotPassword(emailId, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }
        [HttpGet]
        [Route("usertweets")]
        public async Task<IActionResult> GetTweetsByUser(int userId)
        {
            try
            {
                var result = await this.tweetAppService.GetTweetsByUser(userId);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }
    }
}
