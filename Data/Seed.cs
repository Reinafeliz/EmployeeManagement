using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.Entities;
using Newtonsoft.Json;

namespace EmployeeManagement.Data
{
    public class Seed
    {
        public static async void SeedStateCity(DataContext context)
        {
            if (!context.StateCities.Any())
            {
                var stateCityData = File.ReadAllText("Seeder/StateCity.json");
                var stateCities = JsonConvert.DeserializeObject<List<StateCity>>(stateCityData);
                foreach (var item in stateCities)
                {
                    context.StateCities.Add(item);
                    await context.SaveChangesAsync();
                }
                
            }
        }
    }
}