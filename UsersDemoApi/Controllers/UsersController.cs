using Microsoft.AspNetCore.Mvc;
using UsersDemoApi.Models;
using UsersDemoApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersDemoApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository usersRepository;
        private CompaniesRepository companiesRepository;

        public UsersController(UsersRepository usersRepository, CompaniesRepository companiesRepository)
        {
            this.usersRepository = usersRepository;
            this.companiesRepository = companiesRepository;
        }


        // GET: api/users
        [HttpGet]
        public object Get(string _expand ="")
        {
           var users = this.usersRepository.GetAll();
            if (_expand == "companies")
            {

                var response = users.Select(u => new
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    CompaniesId = u.CompaniesId,
                    Companies = this.companiesRepository.GetAll().FirstOrDefault(c => c.Id.ToString() == u.CompaniesId)
                }).ToList();

                return response;
            }
             return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return  this.usersRepository.GetUserById(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            this.usersRepository.Add(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(User user)
        {
            this.usersRepository.Update(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.usersRepository.Remove(id);
        }
    }
}
