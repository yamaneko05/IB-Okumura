using Microsoft.EntityFrameworkCore;
using Uniface.IBOkumura.Core;
using Uniface.IBOkumura.Interfaces.Post.Queries;

namespace Okumura.IBOkumura.Features.Post
{
    class Repository : IBOkumuraDbContext
    {
        public DbSet<PostDto> Posts { get; set; }
    }
}