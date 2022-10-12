using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using EmployeeManagement.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public IReadOnlyList<StateCity> GetCity()
        {
            var stateCityData = File.ReadAllText("Seeder/StateCity.json");
            var stateCities = JsonConvert.DeserializeObject<List<StateCity>>(stateCityData);
            var cities = stateCities.Where(x => x.ParentId != 0);
            return cities.ToList();
        }

        public  IEnumerable<Employee> GetEmployees()
        {
            var data =  _context.Employees.Where(x => x.IsDeleted == false).ToList();
            return data;
        }
    }
}