using UsersDemoApi.Models;

namespace UsersDemoApi.Repositories
{
    public class CompaniesRepository
    {
        private Dictionary<int, Company> dictionaryComponies;
        public CompaniesRepository()
        {
            dictionaryComponies = new Dictionary<int, Company>();
            dictionaryComponies.Add(1, new Company { Id = 1, Name = "Romaguera-Crona", CatchPhrase = "" });
            dictionaryComponies.Add(2, new Company { Id = 2, Name = "Deckow-Crist", CatchPhrase = "" });
            dictionaryComponies.Add(3, new Company { Id = 3, Name = "Keebler LLC", CatchPhrase = "" });
        }


        public IEnumerable<Company> GetAll()
        {
            return dictionaryComponies.Values.ToList();
        }

    }
}
