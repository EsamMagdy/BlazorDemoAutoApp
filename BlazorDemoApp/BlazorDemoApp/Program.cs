using BlazorApp.Models;
using BlazorDemoApp.Client.Pages;
using BlazorDemoApp.Client.Services;
using BlazorDemoApp.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration["connectionStrings:EmployeeDbConnectionString"]);
});

//builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => {
    var client = new HttpClient();
    client.BaseAddress = new("https://localhost:7219/api/");
    //client.DefaultRequestHeaders.Authorization = new("Bearer");
    return client;
});

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorDemoApp.Client._Imports).Assembly);

app.MapControllers();
app.Run();
