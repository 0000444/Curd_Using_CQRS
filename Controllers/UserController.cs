using Microsoft.AspNetCore.Mvc;

namespace Curd_Using_CQRS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
