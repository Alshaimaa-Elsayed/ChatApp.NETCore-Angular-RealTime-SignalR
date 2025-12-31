

namespace ChatApp.Application.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationService(this  IServiceCollection services) 
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }
    }
}
