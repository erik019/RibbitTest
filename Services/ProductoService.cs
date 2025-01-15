using Microsoft.EntityFrameworkCore;
using Ribbit_Test.Data;
using Ribbit_Test.Models;

namespace Ribbit_Test.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync(string? nombre, decimal? minPrecio, decimal? maxPrecio)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            if (minPrecio.HasValue)
            {
                query = query.Where(p => p.Precio >= minPrecio);
            }

            if (maxPrecio.HasValue)
            {
                query = query.Where(p => p.Precio <= maxPrecio);
            }

            return await query.ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> UpdateProductoAsync(int id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null) return null;

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.CantidadEnStock = producto.CantidadEnStock;
            productoExistente.FechaCreacion = producto.FechaCreacion;

            await _context.SaveChangesAsync();
            return productoExistente;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
