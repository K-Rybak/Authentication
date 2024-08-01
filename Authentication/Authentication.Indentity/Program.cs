using Authentication.Identity.Models;
using Authentication.Indentity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}).AddIdentity<User, Role>(config =>
    {
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequiredLength = 3;
        config.Password.RequireUppercase = false;
        config.Password.RequireLowercase = false;
        config.Password.RequireDigit = false;
    }).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Role.Administrator, b =>
    {
        b.RequireClaim(ClaimTypes.Role, Role.Administrator);
    });

    options.AddPolicy(Role.Manager, b =>
    {
        b.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Role.Administrator)
            || x.User.HasClaim(ClaimTypes.Role, Role.Manager));

    });
});

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
