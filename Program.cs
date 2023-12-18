using FirstCore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get connection stirng from assseting.json file
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// SQL + EF core
builder.Services.AddDbContext<TestAvinashContext>(op => op.UseSqlServer(conn)); // Impo

//////////////////////////////////////////////////////////////////
///
var app = builder.Build();

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
