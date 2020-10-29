using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba4.Contexts;
using Prueba4.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContexts contexts;

        public ProductoController(AppDbContexts contexts)
        {
            this.contexts = contexts;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return contexts.Producto.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            var producto = contexts.Producto.FirstOrDefault(p => p.pro_codigo==id);
            return producto;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
            contexts.Producto.Add(producto);
            contexts.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Producto producto)
        {
            if(producto.pro_codigo == id)
            {
                contexts.Entry(producto).State = EntityState.Modified;
                contexts.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var producto = contexts.Producto.FirstOrDefault(p => p.pro_codigo == id);
            if (producto != null)
            {
                contexts.Producto.Remove(producto);
                contexts.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
