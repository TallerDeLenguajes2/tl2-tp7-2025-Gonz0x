using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_Gonz0x.Models;
using tl2_tp7_2025_Gonz0x.Repositorios.ProductosRepository;

namespace tl2_tp7_2025_Gonz0x
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosRepository _productoRepository;

        public ProductosController()
        {
            _productoRepository = new ProductosRepository();
        }

        [HttpGet("GetProductos")]
        public ActionResult GetProductos()
        {
            var productos = _productoRepository.ListarProductos();
            return Ok(productos);
        }
    
        [HttpPost("CrearProducto")]
        public ActionResult CrearProducto([FromBody] Productos nuevoProducto)
        {
            _productoRepository.CrearProducto(nuevoProducto);
            return Ok($"Producto '{nuevoProducto.Descripcion}' creado correctamente.");
            
        }
        
        [HttpPut("{id}")]
        public ActionResult ModificarProducto(int id, [FromBody] Productos productoModificado)
        {
            _productoRepository.ModificarProducto(id, productoModificado);
            return Ok($"Producto con ID {id} modificado correctamente.");
        }

        [HttpGet("{id}")]
        public ActionResult<Productos> ObtenerProductoPorId(int id)
        {
            var producto = _productoRepository.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound($"No se encontró un producto con ID {id}.");
            }
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            _productoRepository.EliminarProducto(id);
            return Ok($"Producto con ID {id} eliminado correctamente.");
        }

    }
}
