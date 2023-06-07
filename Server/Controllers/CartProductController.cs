using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Server.Data;
using SportStore.Shared.Models;

namespace SportStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public CartProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCart(CartProduct prod)
        {
            context.Add(prod);
            await context.SaveChangesAsync();
            return prod.Id;
        }

        [HttpGet("articulos")]
        public async Task<ActionResult<List<CartProduct>>> ObtenerProductos()
        {
            List<CartProduct> articulos = new List<CartProduct>();
            articulos = await context.Carrito.ToListAsync();
            return articulos;
        }

    }
}
