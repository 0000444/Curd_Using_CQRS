using CurdCQRSAndMediator.Application.Blogs.Commands.CreateBlogs;
using CurdCQRSAndMediator.Application.Blogs.Commands.DeleteBlogs;
using CurdCQRSAndMediator.Application.Blogs.Commands.UpdateBlogs;
using CurdCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using CurdCQRSAndMediator.Application.Blogs.Queries.GetBlogsById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Curd_Using_CQRS.Controllers
{
    public class BlogController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var blog = await Mediator.Send(new GetBlogQuery());
            return Ok(blog);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery()
            {
                BlogId = id
            });
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateBlogCommand createBlogCommand)
        {
            var user = await Mediator.Send(createBlogCommand);
            return CreatedAtAction(nameof(GetDataById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , UpdateBlogCommand updateBlogCommand)
        {
            if (id != updateBlogCommand.Id)
            {
                return BadRequest();
            }
            var update = await Mediator.Send(updateBlogCommand);
            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlogCommand()
            {
                Id = id
            });
            return NoContent();

        }
    }
}
   