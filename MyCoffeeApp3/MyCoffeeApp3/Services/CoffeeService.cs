using MyCoffeeApp3.Services;
using MyCoffeeApp3.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(CoffeeService))]
namespace MyCoffeeApp3.Services
{
    public class CoffeeService : ICoffeeService
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Coffee>();
        }

        public async Task AddCoffee(string name, string roaster)
        {
            await Init();
            var image = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/36/Closeup_of_Coffee_Beans.jpg/320px-Closeup_of_Coffee_Beans.jpg";
            var coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            var id = await db.InsertAsync(coffee);
        }

        public async Task RemoveCoffee(int id)
        {
            await Init();

            await db.DeleteAsync<Coffee>(id);
        }

        public async Task<IEnumerable<Coffee>> GetCoffee()
        {
            await Init();

            var coffee = await db.Table<Coffee>().ToListAsync();
            return coffee;
        }

        public async Task<Coffee> GetCoffee(int id)
        {
            await Init();

            var coffee = await db.Table<Coffee>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return coffee;
        }

    }
}
