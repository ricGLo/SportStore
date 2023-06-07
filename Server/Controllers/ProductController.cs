using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Server.Data;
using SportStore.Shared.Models;

namespace SportStore.Server.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCart(Product prod)
        {
            context.Add(prod);
            await context.SaveChangesAsync();
            return prod.Id;
        }

        

        [HttpGet("articulos")]
        public async Task<ActionResult<List<Product>>> ObtenerProductos()
        {
            List<Product> articulos = new List<Product>();
            articulos = await context.Products.ToListAsync();
            return articulos;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> Obtener(int id)
        {
            Product item = new Product();
            item = await context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return item;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            // Obtén el registro que deseas eliminar de la base de datos
            var registro = context.Products.FirstOrDefault(r => r.Id == id);

            if (registro == null)
            {
                return NotFound(); // Devuelve un código de estado 404 (Not Found) si el registro no se encuentra.
            }

            context.Products.Remove(registro); // Elimina el registro de la base de datos
            context.SaveChanges(); // Guarda los cambios en la base de datos

            return Ok(); // Devuelve un código de estado 200 (OK) para indicar que la eliminación fue exitosa.
        }

        [HttpPut]
        public async Task<ActionResult> Comprar(int id)
        {
            // Verifica si el recurso existe en la base de datos
            var prod = context.Products.FirstOrDefault(r => r.Id == id);
            if (prod == null)
            {
                return NotFound();
            }

            prod.Qty = prod.Qty - 1;
            context.SaveChanges();
            return Ok();
        }

    }
}