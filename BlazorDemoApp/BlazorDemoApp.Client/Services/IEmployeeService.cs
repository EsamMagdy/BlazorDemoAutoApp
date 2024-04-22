using BlazorApp.Models;

namespace BlazorDemoApp.Client.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAll();
        public Task<Employee> GetById(int id);

    }
}
