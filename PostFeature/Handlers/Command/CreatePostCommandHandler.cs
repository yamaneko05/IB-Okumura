using Okumura.IBOkumura.Features.Post;
using Uniface.IBOkumura.Interfaces.Post.Commands;
using Uniface.IBOkumura.Interfaces.Post.Queries;

namespace Uniface.IBOkumura.Features.Post.Handlers.Command
{
    public class CreatePostCommandHandler
    {
        public async Task<PostDto> Handle(CreatePostCommand cmd)
        {
            var repository = new Repository();

            var dto = new PostDto();
            dto.Title = cmd.Title;
            dto.Content = cmd.Content;

            repository.Posts.Add(dto);
            await repository.SaveChangesAsync();

            return dto;
        }
    }
}