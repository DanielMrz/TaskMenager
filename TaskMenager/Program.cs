using Microsoft.EntityFrameworkCore;
using TaskMenager.Models;
using TaskMenager.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Nadpisanie definicji konfiguracji dbcontext na poziomie kontenera dependency injection
// Generyczny parametr przyjmuje typ danego dbcontextu
builder.Services.AddDbContext<DbTaskContext>(
        option => option
        .UseSqlServer(builder.Configuration.GetConnectionString("TaskManagerDatabaseConectionString")));
// Teraz za ka¿dym razem gdy zostanie wywo³any konstruktor kontrolera to zostanie do niego wstrzykniêty onbiekt taskrepository który implementuje interface itaskrepository
builder.Services.AddTransient<ITaskRepository, TaskRepository>();

var app = builder.Build();

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
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
