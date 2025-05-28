using Microsoft.EntityFrameworkCore;
using Okumura.IBOkumura.Features.Post;
using Uniface.IBOkumura.Interfaces.Post.Queries;

namespace Uniface.IBOkumura.Features.Post.Handlers.Query
{
    public class PostQueryHandler
    {
        public async Task<IEnumerable<PostDto>> Handle(PostQuery query)
        {
            var repository = new Repository();

            var dbQuery = repository.Posts.AsQueryable();

            if (query.Title != null)
            {
                dbQuery = dbQuery.Where(post => post.Title.Contains(query.Title));
            }

            return await dbQuery.ToListAsync();
        }
    }
}