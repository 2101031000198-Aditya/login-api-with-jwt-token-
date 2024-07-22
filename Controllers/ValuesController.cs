using System.Collections.Generic;
using System.Web.Http;
using token.Models;

namespace token.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<User> users = new List<User>
        {
            new User { Username = "authorized_user", Password = "password123", Role = "admin" },
            new User { Username = "unauthorized_user", Password = "wrongpassword", Role = "guest" }
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values/login
        [HttpPost]
        [Route("api/values/login")]
        public IHttpActionResult Login(User user)
        {
            
            var authenticatedUser = users.Find(u => u.Username == user.Username && u.Password == user.Password);

            if (authenticatedUser != null)
            {
                // Assuming the authentication is successful, return a token
                return Ok(new { token = "token", role = authenticatedUser.Role });
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }
    }
}
