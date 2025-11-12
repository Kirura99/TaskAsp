using TaskAsp.Data;
using Microsoft.EntityFrameworkCore;
using TaskAsp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(name: "default",
    pattern: "{controller=Clients}/{action=Index}/{id?}");

app.Run();
