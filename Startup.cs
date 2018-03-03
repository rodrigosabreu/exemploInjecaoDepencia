using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using injecaoDependencia.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace injecaoDependencia
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
            
            services.AddMvc();

            //Configurando e trabalhando a injecao de depencia
            //Retiar a instancia de string de conexao do home controller
            services.AddTransient<IPeopleRepository>(repository => new PeopleRepository("minhaStringSqlFake"));

            //existem outros tipos de servicos
            //toda vez que precisar do servico vai criar uma nova instancia por requisicao
            //services.AddScoped();

            //vai criar apenas uma classe concreta
            //toda vez que tiver uma nova requisicao sempre vai a mesma classe concreta
            //nunca mais vi ser instanciada
            //services.AddSingleton();
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
