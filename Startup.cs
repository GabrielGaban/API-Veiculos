using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using veiculosAPI.Models;
using Microsoft.EntityFrameworkCore;
using veiculosAPI.Data;

namespace veiculosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // M�todo para adicionar servi�os ao cont�iner
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configura��o do Entity Framework Core para o modelo de Clientes
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Adicionar o VeiculoDataAccess para a parte de ve�culos
            services.AddSingleton(new VeiculoDataAccess(Configuration.GetConnectionString("DefaultConnection")));

            // Configurar o Swagger para documenta��o da API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "veiculosAPI", Version = "v1" });
            });
        }

        // M�todo para configurar o pipeline de requisi��o HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Veiculos API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}