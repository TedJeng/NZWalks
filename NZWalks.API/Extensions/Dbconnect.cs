using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NZWalks.Repository.Models;

namespace NZWalks.API.Extensions
{
    public static class Dbconnect
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NZWalksContext>(options =>
                                    options.UseSqlServer(config.GetConnectionString("NZWalks")));
        }
    }
}
