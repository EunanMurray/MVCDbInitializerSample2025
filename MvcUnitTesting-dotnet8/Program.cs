using Microsoft.EntityFrameworkCore;
using MvcUnitTesting_dotnet8.Models;
using Tracker.WebAPIClient;

namespace MvcUnitTesting_dotnet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00235207", StudentName: "Eunan Murray", activityName: "Rad302 2025 Week 2 Lab 2", Task: "o Implementing Production Repository Pattern.");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(connectionString));
            // Register the repository as a service
            builder.Services.AddScoped<IRepository<Book>, WorkingBookRepository<Book>>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var _ctx = scope.ServiceProvider.GetRequiredService<BookDbContext>();
                var hostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

                DbSeeder dbSeeder = new DbSeeder(_ctx, hostEnvironment);
                dbSeeder.Seed();
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

            app.Run();
        }

        public class DbSeeder
        {
            private readonly BookDbContext _ctx;
            private readonly IWebHostEnvironment _hosting;
            private bool disposedValue;

            public DbSeeder(BookDbContext ctx, IWebHostEnvironment hosting)
            {
                _ctx = ctx;
                _hosting = hosting;
            }

            public void Seed()
            {
                _ctx.Database.EnsureCreated();

                if (!_ctx.Books.Any())
                {
                    _ctx.Books.AddRange(
                        new List<Book>()
                        {
                            new Book { Genre = "Fiction", Name = "Moby Dick", Price=12.50m },
                            new Book { Genre = "Fiction", Name = "War and Peace", Price=17m },
                            new Book { Genre = "Science Fiction", Name = "Escape from the Vortex", Price=19m},
                            new Book { Genre = "History", Name = "The Battle of the Somme", Price = 22m}
                        });
                    _ctx.SaveChanges();

                }
            }
        }
    }
}
