using Microsoft.EntityFrameworkCore;

namespace Uniface.IBOkumura.Core
{
    public class IBOkumuraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.TraversePath().Load();
            var connStr = DotNetEnv.Env.GetString("DB_CONNECTION_STRING");

            optionsBuilder.UseSqlServer(connStr);
        }
    }
}

