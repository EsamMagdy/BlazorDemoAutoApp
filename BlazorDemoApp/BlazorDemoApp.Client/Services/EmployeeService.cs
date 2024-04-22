using BlazorApp.Models;
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
                var list = await _httpClientFactory.GetStreamAsync($"employees");

                var employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                    (list, _options);

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
                var ss = await _httpClientFactory.GetStreamAsync($"employees/{id}");

                var employee = await JsonSerializer.DeserializeAsync<Employee>
                    (ss, _options);

                return employee;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
