using Microsoft.Extensions.DependencyInjection;
using NZWalks.Repository.Repository;

namespace NZWalks.API.Extensions
{
    public static class Feature
    {
        public static void RefDependInject(this IServiceCollection services)
        {
            services.AddScoped<IRegionRepository, RegionRepository>();
        }
    }
}
