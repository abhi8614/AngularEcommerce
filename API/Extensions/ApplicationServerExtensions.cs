using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServerExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                string connStr = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connStr);
            });
            return services;
        }
    }
}
