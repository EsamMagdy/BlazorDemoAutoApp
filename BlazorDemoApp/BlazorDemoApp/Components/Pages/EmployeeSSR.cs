using BlazorApp.Models;
using BlazorDemoApp.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoApp.Components.Pages
{
    public partial class EmployeeSSR
    {
        private IEnumerable<Employee>? Employees { get; set; }
        private Employee Employee { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        private string message = "Not updated yet.";

    
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(3000);
            Employees = await EmployeeService.GetAll();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Console.WriteLine("Hello from Auto component");
                Console.WriteLine("If this is in your browser console, this is rendered in WebAssembly");
                Console.WriteLine("If this is in your server's console, this is rendered via SignalR");
            }
        }

        private async Task GetMovieDetails(int id)
        {
            Employee = null;
            StateHasChanged();

            await Task.Delay(1000);

            Employee = await EmployeeService.GetById(id);
            StateHasChanged();
        }

        private void UpdateMessage()
        {
            message = "Somebody updated me!";
        }

    }
}
