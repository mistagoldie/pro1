using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Models;

namespace PizzeriaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s16728Context _context;

        public PizzaController(s16728Context context)
        {
            _context = context;
        }

        //api/pizza
        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.ToList());
        }

        //api/pizza/4    //api/pizza/detalis/4 przed id: "details/" 
        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if(pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

    }
}