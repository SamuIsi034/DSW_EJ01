using DSW_3P_EJ01.Data;
using DSW_3P_EJ01.Models;

namespace DSW_3P_EJ01.Repositories;

public class PersonajeSqlRepository : IPersonajeRepository
{
    private readonly AppDbContext _context;

    public PersonajeSqlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public List<Personaje> ObtenerTodos()
    {
        return _context.Personajes.ToList();
    }

    public Personaje? ObtenerPorId(int id)
    {
        return _context.Personajes.Find(id);
    }

    public Personaje Agregar(Personaje personaje)
    {
        personaje.Id = 0;

        _context.Personajes.Add(personaje);
        _context.SaveChanges();

        return personaje;
    }

    public bool Actualizar(int id, Personaje personaje)
    {
        var actual = _context.Personajes.Find(id);

        if(actual == null)
            return false;
        
        actual.Nombre = personaje.Nombre;
        actual.Clase = personaje.Clase;
        actual.Disponible = personaje.Disponible;

        _context.SaveChanges();

        return true;

    }

    public bool Eliminar(int id)
    {
        var personaje = _context.Personajes.Find(id);
        
        if(personaje == null)
            return false;
        
        _context.Personajes.Remove(personaje);
        _context.SaveChanges();
        return true;
    }
}