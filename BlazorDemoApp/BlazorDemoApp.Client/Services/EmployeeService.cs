using BlazorApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorDemoApp.Client.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly HttpClient _httpClientFactory;
        private readonly JsonSerializerOptions _options;


        public EmployeeService(HttpClient httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                var employees = await _httpClientFactory.GetFromJsonAsync<IEnumerable<Employee>>($"employees", _options);

                return employees;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                var employee = await _httpClientFactory.GetFromJsonAsync<Employee>($"employees/{id}", _options);

                return employee;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
