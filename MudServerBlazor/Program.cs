using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MudServerBlazor.Models;
using MudServerBlazor.Persistance;
using MudServerBlazor.Persistance.Abstract;
using MudServerBlazor.Services;
using MudServerBlazor.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddScoped<ICrudRepository<Customer>,CrudRepository<Customer>>();
builder.Services.AddScoped<ICrudService<Customer>,CrudService<Customer>>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ChinookContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
