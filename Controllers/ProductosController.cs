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

        // A partir de aquí van todos los demás Action Methods (Get, Post, etc.)
    }
}

// Ejemplo de cómo dar de alta un producto
// [HttpPost("AltaProducto")]
//  public ActionResult<string> AltaProducto(Producto nuevoProducto)
//  {
//  productoRepository.Alta(nuevoProducto);
//  return Ok("Producto dado de alta exitosamente");
// }
