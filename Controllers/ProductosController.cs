using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ribbit_Test.Models;
using Ribbit_Test.Services;

namespace Ribbit_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // 1. GET /api/Productos
        [HttpGet]
        public async Task<IActionResult> GetProductos([FromQuery] string? nombre, [FromQuery] decimal? minPrecio, [FromQuery] decimal? maxPrecio)
        {
            var productos = await _productoService.GetAllProductosAsync(nombre, minPrecio, maxPrecio);
            return Ok(productos);
        }

        // 2. GET /api/Productos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // 3. POST /api/Productos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProducto = await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = createdProducto.Id }, createdProducto);
        }

        // 4. PUT /api/Productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProducto = await _productoService.UpdateProductoAsync(id, producto);
            if (updatedProducto == null)
            {
                return NotFound();
            }
            return Ok(updatedProducto);
        }

        // 5. DELETE /api/Productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productoService.DeleteProductoAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
