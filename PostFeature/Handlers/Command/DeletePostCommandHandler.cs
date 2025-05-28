using Okumura.IBOkumura.Features.Post;
using Uniface.IBOkumura.Interfaces.Post.Commands;
using Uniface.IBOkumura.Interfaces.Post.Exception;

namespace Uniface.IBOkumura.Features.Post.Handlers.Command
{
    public class DeletePostCommandHandler
    {
        public async Task Handle(DeletePostCommand cmd)
        {
            var repository = new Repository();

            var dto = await repository.Posts.FindAsync(cmd.Id);

            if (dto == null)
            {
                throw new PostNotFoundException();
            }

            repository.Posts.Remove(dto);

            await repository.SaveChangesAsync();
        }
    }
}