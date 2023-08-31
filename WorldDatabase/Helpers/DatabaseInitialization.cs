using Newtonsoft.Json;
using WorldDatabase.Data;
using WorldDatabase.Models;

namespace WorldDatabase.Helpers
{
    public static class DatabaseInitialization
    {
        public static void InitializeData(this IServiceCollection services)
        {
			try
			{
                ServiceProvider serviceProvider = services.BuildServiceProvider();
                DatabaseContext db = serviceProvider.GetService<DatabaseContext>();
                IWebHostEnvironment env = serviceProvider.GetService<IWebHostEnvironment>();

                if (!db.Countries.Any())
                {
                    string dataFilePath = $"{env.ContentRootPath}\\Data\\countries+states+cities.json";
                    string dataJsonContent = File.ReadAllText(dataFilePath);
                    List<Country> jsonCountries = JsonConvert.DeserializeObject<List<Country>>(dataJsonContent);

                    foreach (Country country in jsonCountries)
                    {
                        country.Id = 0;
                        foreach (State state in country.States)
                        {
                            state.Id = 0;
                            foreach (City city in state.Cities)
                            {
                                city.Id = 0;
                            }
                        }
                    }

                    db.Countries.AddRange(jsonCountries);
                    db.SaveChanges();
                }
            }
			catch (Exception exp)
			{
                Console.WriteLine(exp.Message);
			}
        }
    }
}
