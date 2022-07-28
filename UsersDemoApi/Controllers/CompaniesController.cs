using Microsoft.AspNetCore.Mvc;
using UsersDemoApi.Models;
using UsersDemoApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        CompaniesRepository repo;
        public CompaniesController(CompaniesRepository repo)
        {
            this.repo = repo;
        }


        // GET: api/<CompaniesController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return this.repo.GetAll();
        }

    }
}
