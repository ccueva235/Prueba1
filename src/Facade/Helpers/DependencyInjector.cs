using Data.Sql.Repositories;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Service.Services;

namespace Facade.Helpers
{
    public static class  DependencyInjector
    {
        public static  IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IUsuarioService, UsuarioService>();
            service.AddTransient<IConsultaSunatService, ConsultaSunatService>();

            return service;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            service.AddSingleton<IConsultaSunatRepository, ConsultaSunatRepository>();

            return service;
        }

    }
}
