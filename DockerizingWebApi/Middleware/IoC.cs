using DockerizingWebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerizingWebApi.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar el servicio de Albumes
            services.AddTransient<IAlbumesService, AlbumesService>();

            return services;
        }
    }
}
