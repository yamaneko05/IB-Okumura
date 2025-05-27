using Microsoft.EntityFrameworkCore;

namespace Uniface.IBOkumura.Core
{
    public class IBOkumuraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; User ID=sa; Password=Uniface01; Initial Catalog=IBOKUMURA; TrustServerCertificate=true;");
        }
    }
}

