using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using artist.Data;
using artist.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace artist
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

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "artist", Version = "v1" });
      });


      // REVIEW
      // transient create a new one whenever one is needed
      // scoped per request create one and pass it around
      // singleton when the app starts create it and never destroy it

      // when connecting to the database use scoped

      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //repos
      services.AddTransient<ArtistsRepository>();

      //services
      services.AddTransient<ArtistsService>();

    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public IDbConnection CreateDbConnection()
    {
      // Note reading environment variable
      string connectionString = Configuration["DB:CONNECTION_STRING"];
      return new MySqlConnection(connectionString);
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artist v1"));
      }

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
