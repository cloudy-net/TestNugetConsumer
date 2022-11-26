using Cloudy.CMS.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Website.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy => cloudy
    .AddAdmin(admin => admin.Unprotect())
    .AddAzureMediaPicker()
    .AddContext<Context>()
);
builder.Services.AddDbContext<Context>(options => options
    .UseInMemoryDatabase("cloudytest")
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(new StaticFileOptions().MustValidate());
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/", async c => c.Response.Redirect("/Admin"));
app.MapGet("/pages", async c => await c.Response.WriteAsJsonAsync(c.RequestServices.GetService<Context>().Pages));
app.MapGet("/pages/{route:contentroute}", async c => await c.Response.WriteAsync($"Hello {c.GetContentFromContentRoute<Page>().Name}"));
app.MapControllerRoute(null, "/controllertest/{route:contentroute}", new { controller = "Page", action = "Index" });

app.Run();