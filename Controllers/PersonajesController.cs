using Microsoft.AspNetCore.Mvc;
using DSW_3P_EJ01.Models;
using DSW_3P_EJ01.Services;
using Microsoft.AspNetCore.Authorization;

namespace DSW_3P_EJ01.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonajesController : ControllerBase
{
    private readonly IPersonajeService _service;

    public PersonajesController(IPersonajeService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Personaje>> ObtenerTodos()
    {
        var personajes = _service.ObtenerTodos();
        return Ok(personajes);
    }

    [HttpGet("{id}")]
    public ActionResult<Personaje> ObtenerPorId(int id)
    {
        var personaje = _service.ObtenerPorId(id);
        if (personaje == null)
        {
            return NotFound(new { mensaje = $"No se encontró el personaje con ID {id}." });
        }

        return Ok(personaje);
    }

    [HttpPost]
    public ActionResult<Personaje> Agregar([FromBody] Personaje personaje)
    {
        try
        {
            var creado = _service.Agregar(personaje);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Personaje personaje)
    {
        try
        {
            var actualizado = _service.Actualizar(id, personaje);
            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se encontró el personaje con ID {id} para actualizar." });
            }

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminada = _service.Eliminar(id);
        if (!eliminada)
        {
            return NotFound(new { mensaje = $"No se encontró el personaje con ID {id} para eliminar." });
        }

        return NoContent();
    }
}
