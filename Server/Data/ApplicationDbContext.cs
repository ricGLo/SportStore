using System;   
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportStore.Shared.Models;

namespace SportStore.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
                                 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /////////////////////// Productos //////////////////////
            base.OnModelCreating(modelBuilder);
                //Running
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Nike Wmns Air Zoom Vomero 15",
                Description = "Tenis de Correr para Mujer ",
                ImageURL = "https://m.media-amazon.com/images/I/71wbkY+1KgL._AC_SY695_.jpg",
                Price = 1326.00M,
                Qty = 100,
                SportId = 1
                
            });

                //Soccer
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Voit Balón de Fútbol",
                Description = "No. 5 Hibrido S300 Clausura 2023 ",
                ImageURL = "https://m.media-amazon.com/images/I/71HaT5W8aDL._AC_SL1280_.jpg",
                Price = 659.00M,
                Qty = 100,
                SportId = 2

            });


                //Basketbal
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "LIFETIME Portátil",
                Description = "Sistema De Baloncesto Ajustable Gris Policarbonato Juventud Unisex",
                ImageURL = "https://m.media-amazon.com/images/I/71zM+jcsqhL._AC_SL1500_.jpg",
                Price = 5111.97M,
                Qty = 100,
                SportId = 3
            });


                //Fut
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Jersey Atletico de San Luis",
                Description = "Pelotas de Tenis Abiertas",
                ImageURL = "https://m.media-amazon.com/images/I/81ud+g6QyTL._AC_SL1500_.jpg",
                Price = 999,
                Qty = 0,
                SportId = 2
            });
        }


        public DbSet<CartProduct> Carrito { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
