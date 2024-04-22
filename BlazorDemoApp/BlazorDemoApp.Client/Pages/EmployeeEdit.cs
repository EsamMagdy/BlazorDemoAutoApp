using BlazorApp.Models;
using BlazorDemoApp.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoApp.Client.Pages
{
    public partial class EmployeeEdit
    {
        [Parameter]
        public string EmployeeId { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(EmployeeId))
                return;


            Employee = await EmployeeService.GetById(int.Parse(EmployeeId));

        }
    }
}
