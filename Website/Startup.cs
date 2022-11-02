using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Cloudy.CMS.Routing;
using Cloudy.CMS.UI;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy => cloudy
    .AddAdmin(admin => admin.Unprotect())
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
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", async c => c.Response.Redirect("/Admin"));
    endpoints.MapGet("/pages", async c => await c.Response.WriteAsJsonAsync(c.RequestServices.GetService<Context>().Pages));
    endpoints.MapGet("/pages/{route:contentroute}", async c => await c.Response.WriteAsync($"Hello {c.GetContentFromContentRoute<Page>().Name}"));
    endpoints.MapControllerRoute(null, "/controllertest/{route:contentroute}", new { controller = "Page", action = "Index" });
});

app.Run();