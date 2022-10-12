using EmployeeManagement.Entities;

namespace EmployeeManagement.Interface
{
    public interface IEmployeeRepository
    {
        IReadOnlyList<StateCity> GetCity();
        IEnumerable<Employee> GetEmployees();
    }
}