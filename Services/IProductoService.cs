using Ribbit_Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbit_Test.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync(string? nombre, decimal? minPrecio, decimal? maxPrecio);
        Task<Producto> GetProductoByIdAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto> UpdateProductoAsync(int id, Producto producto);
        Task<bool> DeleteProductoAsync(int id);
    }
}
