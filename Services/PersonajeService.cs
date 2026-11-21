using DSW_3P_EJ01.Models;
using DSW_3P_EJ01.Repositories;

namespace DSW_3P_EJ01.Services;

public class PersonajeService : IPersonajeService
{
    private readonly IPersonajeRepository _repository;

    public PersonajeService(IPersonajeRepository repository)
    {
        _repository = repository;

    }

        public List<Personaje> ObtenerTodos()
    {
        return _repository.ObtenerTodos();
    }

    public Personaje? ObtenerPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public Personaje Agregar(Personaje nuevoPersonaje)
    {
        ValidarPersonaje(nuevoPersonaje);

        return _repository.Agregar(nuevoPersonaje);
    }

    public bool Actualizar(int id, Personaje personaje)
    {
        // Regla de negocio: No se deberán permitir modificaciones de personajes inexistentes.
        var existente = _repository.ObtenerPorId(id);
        if (existente == null)
        {
            return false;
        }

        ValidarPersonaje(personaje);

        personaje.Id = id;
        return _repository.Actualizar(id, personaje);
    }

    public bool Eliminar(int id)
    {
        // Regla de negocio: No se deberán permitir eliminaciones de personajes inexistentes.
        var existente = _repository.ObtenerPorId(id);
        if (existente == null)
        {
            return false;
        }

        return _repository.Eliminar(id);
    }

    private void ValidarPersonaje(Personaje personaje)
    {
        if (string.IsNullOrWhiteSpace(personaje.Nombre))
        {
            throw new ArgumentException("El nombre del personaje es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(personaje.Clase))
        {
            throw new ArgumentException("La clase del personaje es obligatoria.");
        }
    }
}
