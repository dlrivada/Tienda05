using TiendaRepository.Models;

namespace TiendaRepository.ViewModel
{
    public class ViewModelCategoria:IViewModel<Categoria>
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public Categoria ToBaseDatos()
        {
            return new Categoria()
            {
                IdCategoria = IdCategoria,
                Nombre = Nombre
            };
        }

        public void FromBaseDatos(Categoria modelo)
        {
            IdCategoria = modelo.IdCategoria;
            Nombre = modelo.Nombre;
        }

        public void UpdateDatos(Categoria modelo)
        {
            modelo.IdCategoria = IdCategoria;
            modelo.Nombre = Nombre;
        }

        public object[] GetKeys() => new object[] {IdCategoria};
    }
}
