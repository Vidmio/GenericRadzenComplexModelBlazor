using GenericRadzenComplexModelBlazor.Components;
using GenericRadzenComplexModelBlazor.Components.Model;
using GenericRadzenComplexModelBlazor.Components.Repository.Interface;
using GenericRadzenComplexModelBlazor.Components.Repository;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();
builder.Services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();
builder.Services.AddScoped<IGenericRepository<Enrollment>, EnrollmentRepository>();//ovo je za GET sa include
builder.Services.AddScoped<IGenericRepository<Error>, GenericRepository<Error>>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectionString"), sqlServerOptions => sqlServerOptions.CommandTimeout(120)),
            ServiceLifetime.Transient);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
