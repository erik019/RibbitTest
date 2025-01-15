using Microsoft.EntityFrameworkCore;
using Ribbit_Test.Models;

namespace Ribbit_Test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Producto
            modelBuilder.Entity<Producto>().Property(p => p.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Datos iniciales
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Laptop",
                    Descripcion = "Laptop de alta gama para desarrolladores",
                    Precio = 1500.99m,
                    CantidadEnStock = 10,
                    FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Fecha estática
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Mouse",
                    Descripcion = "Mouse inalámbrico ergonómico",
                    Precio = 25.50m,
                    CantidadEnStock = 50,
                    FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Fecha estática
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Teclado",
                    Descripcion = "Teclado mecánico retroiluminado",
                    Precio = 80.75m,
                    CantidadEnStock = 20,
                    FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Fecha estática
                }
            );
        }

    }
}
