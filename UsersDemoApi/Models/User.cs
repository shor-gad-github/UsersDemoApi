using System.Text.Json.Serialization;

namespace UsersDemoApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompaniesId { get; set; }
    }
}
