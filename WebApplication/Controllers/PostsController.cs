using Microsoft.AspNetCore.Mvc;
using Uniface.IBOkumura.Features.Post.Handlers.Command;
using Uniface.IBOkumura.Features.Post.Handlers.Query;
using Uniface.IBOkumura.Interfaces.Post.Commands;
using Uniface.IBOkumura.Interfaces.Post.Exception;
using Uniface.IBOkumura.Interfaces.Post.Queries;

namespace Uniface.IBOkumura.WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<PostDto>> GetPosts([FromQuery] PostQuery query)
    {
        var queryHandler = new PostQueryHandler();

        return await queryHandler.Handle(query);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost(CreatePostCommand cmd)
    {
        var commandHandler = new CreatePostCommandHandler();

        return await commandHandler.Handle(cmd);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost([FromRoute] int id)
    {
        var cmd = new DeletePostCommand();
        cmd.Id = id;

        var commandHandler = new DeletePostCommandHandler();

        try
        {
            await commandHandler.Handle(cmd);
        }
        catch (PostNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
