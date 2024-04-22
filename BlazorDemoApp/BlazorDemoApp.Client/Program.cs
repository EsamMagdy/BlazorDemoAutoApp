using BlazorDemoApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7219/api/") });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();


await builder.Build().RunAsync();
