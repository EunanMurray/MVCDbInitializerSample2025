using Tracker.WebAPIClient;
using Week1Lab12025.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'Default Connection' not found.");
builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(dbConnectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var _ctx = scope.ServiceProvider.GetRequiredService<UserContext>();
    var hostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    DbSeeder dbseeder = new DbSeeder(_ctx, hostEnvironment);
    dbseeder.Seed();
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

ActivityAPIClient.Track(
    StudentID: "S00235207", 
    StudentName: "Eunan Murray", 
    activityName: "Rad302 2025 Week 1 Lab 1",
    Task: "Database Initializer setup successfully"
);

app.Run();
