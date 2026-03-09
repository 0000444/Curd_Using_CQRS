using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curd_Using_CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private ISender? _sender;

        protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>(); 
    }
}
