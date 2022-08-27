using Business.Users.Services;
using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUsers([Range(1, int.MaxValue)] int offset = 1, [Range(1, 10)] int limit = 2)
        {
            return Ok(_userService.GetAll(offset, limit));
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([Required] string firstName, [Required] string lastName, [Required] string username)
        {
            var createdUser = await _userService.CreateUser(firstName, lastName, username);

            return Ok(createdUser);
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<ActionResult<UserModel>> UpdateUser([Required][FromRoute] int userId, [Required] string firstName, [Required] string lastName)
        {
            var existingUser = await _userService.GetById(userId);

            if(existingUser == null)
            {
                return NotFound();
            }
            var updatedUser = await _userService.UpdateUser(userId, firstName, lastName);
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<UserModel>> DeleteUser([Required][FromRoute] int userId)
        {
            var existingUser = await _userService.GetById(userId);

            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(userId);

            return NoContent();
        }
    }
} 

