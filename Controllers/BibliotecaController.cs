using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() => new string[] { "Hola", "Mundo" };

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) => "value";

        [HttpPost]
        public void Post([FromBody] string value)
        {
            //TODO: Post method
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO: Put method
        }
    }
}