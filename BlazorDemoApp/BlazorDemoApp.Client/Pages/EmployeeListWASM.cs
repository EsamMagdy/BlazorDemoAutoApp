﻿using BlazorApp.Models;
using BlazorDemoApp.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDemoApp.Client.Pages
{
    public partial class EmployeeListWASM
    {
        private IEnumerable<Employee>? Employees { get; set; }
        private Employee Employee { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
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

            //await Task.Delay(1000);

            Employee = await EmployeeService.GetById(id);
            StateHasChanged();
        }
    }
}
