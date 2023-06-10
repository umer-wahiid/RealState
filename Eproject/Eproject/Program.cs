//using Microsoft.AspNetCore.Authentication.Cookies;
using Eproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Dbs>(a =>
{
    a.UseSqlServer(builder.Configuration.GetConnectionString("con"));
});
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.IsEssential = true;
});
//builder.Services.AddAuthentication
//    (CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(option =>
//    {
//        option.LoginPath = "/Access/Login";
//        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
