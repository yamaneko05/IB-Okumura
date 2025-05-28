using Microsoft.Extensions.Diagnostics.HealthChecks;
using Uniface.IBOkumura.Core;

namespace Uniface.IBOkumura.WebApplication.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var dbContext = new IBOkumuraDbContext();

            var isHealthy = await dbContext.Database.CanConnectAsync();

            return isHealthy
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy();
        }
    }
}