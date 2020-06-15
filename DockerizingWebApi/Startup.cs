using DockerizingWebApi.DataContext;
using DockerizingWebApi.DataContext.Data;
using DockerizingWebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DockerizingWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            //Configuración de Sql Server
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
              .Replace("{{DB_ENDPOINT}}", Configuration.GetValue<string>("DB_ENDPOINT"))));            

            services.AddControllers();
            
            IoC.AddDependency(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                
            });
        }

        // Ejecutar migraciones e inicializar la bd en el container con sql-server
        public void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var _context = serviceScope.ServiceProvider.GetService<WebApiDbContext>())
                {

                    if (Configuration.GetValue<bool>("DB_MIGRATE") == true)                    
                        _context.Database.Migrate();                                            

                    if (Configuration.GetValue<bool>("DB_INITIALIZE") == true)                   
                        DbInitializer.Initialize(_context);
                    
                }
            }
        }
    }
}
