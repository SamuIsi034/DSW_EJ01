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

    public List<Personaje> ObtenerPorVideojuego(string nombre)
    {
        return _repository.ObtenerTodos()
            .Where(p => p.Videojuego.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Personaje> ObtenerPorNivel(int nivel)
    {
        return _repository.ObtenerTodos()
            .Where(p => p.Nivel >= nivel)
            .ToList();
    }

    public Personaje? ObtenerPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public Personaje Agregar(Personaje nuevoPersonaje)
    {
        ValidarPersonaje(nuevoPersonaje);
        nuevoPersonaje.Disponible = true;

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
        if (string.IsNullOrWhiteSpace(personaje.Videojuego))
        {
            throw new ArgumentException("El videojuego del personaje es obligatorio.");
        }

        if (personaje.Nivel < 1 || personaje.Nivel > 100)
        {
            throw new ArgumentException("El nivel debe estar entre 1 y 100.");
        }

        if (personaje.Poder <= 0)
        {
            throw new ArgumentException("El poder debe ser mayor que cero.");
        }

        if (string.IsNullOrWhiteSpace(personaje.ImagenUrl) ||
        !Uri.TryCreate(personaje.ImagenUrl, UriKind.Absolute, out var uri) ||
        (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new ArgumentException("ImagenUrl debe ser una URL absoluta válida (HTTP o HTTPS).");
        }
    }
}
