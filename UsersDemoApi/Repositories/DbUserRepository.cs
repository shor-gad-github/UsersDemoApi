using System.Data.SqlClient;
using UsersDemoApi.Models;

namespace UsersDemoApi.Repositories
{
    public class DbUserRepository : IUserRepository
    {
        string connectionString= "";

        public DbUserRepository()
        {
            connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=DBUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        
        }

        public int Add(User newUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string queryString ="SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //ROW in DB
                    {

                        User user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(3),
                            Email = reader.GetString(1),
                            Phone = reader.GetString(2),
                            CompaniesId = reader.GetInt32(4).ToString()
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int idToRemove)
        {
            throw new NotImplementedException();
        }

        public bool Update(User userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
