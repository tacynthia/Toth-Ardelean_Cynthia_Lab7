using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Toth_Ardelean_Cynthia_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Toth_Ardelean_Cynthia_Lab2.Areas.Identity.Data;
using Toth_Ardelean_Cynthia_Lab2.Hubs;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<LibraryContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("NewLibraryConnection")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>();

        builder.Services.AddDbContext<IdentityContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("NewLibraryConnection")));

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
            options.Password.RequiredLength = 8;
        });

        builder.Services.AddSignalR();
        builder.Services.AddRazorPages();

        builder.Services.AddAuthorization(opts =>
        {
            opts.AddPolicy("OnlySales", policy =>
            {
                policy.RequireClaim("Department", "Sales");
            });

            opts.AddPolicy("SalesManager", policy =>
            {
                policy.RequireRole("Manager");
                policy.RequireClaim("Department", "Sales");
            });
        });

        builder.Services.ConfigureApplicationCookie(opts =>
        {
            opts.AccessDeniedPath = "/Identity/Account/AccessDenied";
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            DbInitializer.Initialize(services);
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapHub<ChatHub>("/Chat");
        app.MapRazorPages();

        app.Run();
    }
}
