using EmployeeAPI.Components;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Database
builder.Services.AddDbContextFactory<EmployeeAPIContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeAPIContext")
        ?? throw new InvalidOperationException("Missing connection string.")
    )
);

// ✅ Razor & Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
