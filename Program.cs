using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WRTC2026_Log.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WRTC2026_LogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WRTC2026_LogContext") ?? throw new InvalidOperationException("Connection string 'WRTC2026_LogContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
