
using CodeFirst.Services;
using CodeFirst.Services.IServices;
using FirstCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get connection stirng from assseting.json file
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// SQL + EF core
builder.Services.AddDbContext<TestAvinashContext>(op => op.UseSqlServer(conn)); // Impo

// Dependency injection
builder.Services.AddTransient<ITransient, UserMethod>();
builder.Services.AddScoped<IScoped, UserMethod>();
builder.Services.AddSingleton<ISingleton, UserMethod>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//////////////////////////////////////////////////////////////////
///
var app = builder.Build();

Console.WriteLine(app.Environment.EnvironmentName);
Console.WriteLine(app.Environment.ApplicationName);
Console.WriteLine(app.Environment.ContentRootPath);
Console.WriteLine(app.Environment.WebRootPath);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Middleware !
app.UseStaticFiles(); // Middleware

app.UseRouting(); // Middleware


app.UseAuthorization(); // Middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
