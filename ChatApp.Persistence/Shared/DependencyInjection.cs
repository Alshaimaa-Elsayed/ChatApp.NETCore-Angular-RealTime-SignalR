

using Microsoft.Extensions.Configuration;

namespace ChatApp.Persistence.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistenceService(this  IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(option =>
            {
                option.Password.RequireLowercase = true;
                option.SignIn.RequireConfirmedEmail = false;
            })
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
