using BLL.Services;
using DAL.Repository;

namespace todos_technical_backend.BuildExtensions
{
    internal static class ServicesInjection
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository>();
            services.AddScoped<ITaskItemsService, TaskItemsService>();
        }
    }
}
