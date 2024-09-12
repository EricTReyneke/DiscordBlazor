using Data.BlazorDatabaseApis;
using Data.BlazorDatabaseApis.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscordDatabaseApis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserDataOperations userDataOperations) : ControllerBase
    {
        #region Fields
        private readonly IUserDataOperations _userDataOperations = userDataOperations;
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>List of users or an appropriate error response.</returns>
        [HttpGet("retrieve-all")]
        [ProducesResponseType(typeof(List<User>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<User>> RetrieveAllUsers()
        {
            try
            {
                List<User> users = _userDataOperations.RetrieveAllUsers();

                if (users == null || !users.Any())
                    return NotFound("No users found.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion
    }
}