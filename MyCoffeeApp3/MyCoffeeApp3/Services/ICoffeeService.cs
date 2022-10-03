using MyCoffeeApp3.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCoffeeApp3.Services
{
    public interface ICoffeeService
    {
        Task AddCoffee(string name, string roaster);
        Task<IEnumerable<Coffee>> GetCoffee();
        Task<Coffee> GetCoffee(int id);
        Task RemoveCoffee(int id);
    }
}