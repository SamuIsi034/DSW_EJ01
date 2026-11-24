using DSW_3P_EJ01.Models;

namespace DSW_3P_EJ01.Services;

public interface IPersonajeService
{
    List<Personaje> ObtenerTodos();
    List<Personaje> ObtenerPorVideojuego(string nombre);
    List<Personaje> ObtenerPorNivel(int nivel); 
    Personaje? ObtenerPorId(int id);
    Personaje Agregar(Personaje nuevoPersonaje);
    bool Actualizar(int id, Personaje personaje);
    bool Eliminar(int id);
}