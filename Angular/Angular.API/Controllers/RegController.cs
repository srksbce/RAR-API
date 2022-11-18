using Angular.Business.Interfaces;
using Angular.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegController : ControllerBase
    {
        // GET: api/<RegController>
        
        
            private readonly IRegisterBusiness _registerBusiness;
            public RegController(IRegisterBusiness regBusiness)
            {
                _registerBusiness = regBusiness;

            }
        [HttpGet]
            public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegController>
        [HttpPost]
       
        public async Task<IActionResult> Post(regVM reg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(reg);
            }
            var result = await _registerBusiness.InRegister(reg);
            if (result is not null)
                return Ok(result);
            else
                return NotFound(result);
        }

        // PUT api/<RegController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
