using CurdCQRSAndMediator.Application.UserDTOs;
using CurdCQRSAndMediator.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Curd_Using_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public static User user = new ();
        [HttpPost("register")]
        public ActionResult<User> Register(UserDTOs userDTOs)
        {
            var hasedPasswordn = new PasswordHasher<User>()
                .HashPassword(user , userDTOs.Password);

            user.UserName = userDTOs.UserName;
            user.PasswordHash = userDTOs.Password;

            return Ok(user);
        }
    }
}
