using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_Gonz0x.Models;
using tl2_tp7_2025_Gonz0x.Repositorios.PresupuestosRepository;

namespace tl2_tp7_2025_Gonz0x
{
   [ApiController]
   [Route("[controller]")]
   public class PresupuestosController : ControllerBase
   {
      private readonly PresupuestosRepository _presupuestosRepository;

      public PresupuestosController()
      {
         _presupuestosRepository = new PresupuestosRepository();
      }

      [HttpGet("ListarPresupuestos")]
      public ActionResult ListarPresupuestos()
      {
      var presupuestos = _presupuestosRepository.ListarPresupuestos();
      return Ok(presupuestos);
      }

      [HttpPost]
      public ActionResult CrearPresupuesto([FromBody] Presupuestos nuevoPresupuesto)
      {
      _presupuestosRepository.CrearPresupuesto(nuevoPresupuesto);
      return Ok("Presupuesto creado correctamente.");
      }

      [HttpPost("{id}/ProductoDetalle")]
      public ActionResult AgregarProductoAPresupuesto(int id, [FromBody] PresupuestosDetalle nuevoDetalle)
      {
      _presupuestosRepository.AgregarProductoAPresupuesto(id, nuevoDetalle.Producto.idProducto, nuevoDetalle.Cantidad);
      return Ok($"Producto agregado correctamente al presupuesto {id}.");

      }

      [HttpGet("{id}")]
      public ActionResult<Presupuestos> ObtenerPresupuestoPorId(int id)
      {
      var presupuesto = _presupuestosRepository.ObtenerPresupuestoPorId(id);
      if (presupuesto == null)
         return NotFound($"No se encontró el presupuesto con ID {id}.");

      return Ok(presupuesto);
      }

      [HttpDelete("{id}")]
      public ActionResult EliminarPresupuesto(int id)
      {
      _presupuestosRepository.EliminarPresupuesto(id);
      return Ok($"Presupuesto con ID {id} eliminado correctamente.");
      }
   }
}