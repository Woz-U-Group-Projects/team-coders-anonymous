using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GroupProject3.Models;

namespace GroupProject3
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			// add reference to the SQLite Database file. If the file does not exist when the migration is run, it creates the file.
			var connectionString = "Data Source=ResidentsEntityFramework.db";
			services.AddDbContext<ResidentsContext>(options => options.UseSqlite(connectionString));

			services.AddCors(options =>
				{
					options.AddPolicy("AllowOrigin",
//						builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

					builder => 
					{
						builder.WithOrigins("http://24.164.14.197:3000","https://24.164.14.197:5001/Residents","http://localhost:3000","http://localhost:5001/Residents")
						//	.WithHeaders("x-suiteRole-header")
							.AllowAnyHeader()
							.AllowAnyMethod();
					}
					);
				}
			);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				//app.UseHttpsRedirection();
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseCors("AllowOrigin");
//			app.UseCors();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}