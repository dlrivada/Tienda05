using TiendaRepository.Models;

namespace TiendaRepository.ViewModel
{
    public class ViewModelEtiqueta:IViewModel<Etiqueta>
    {
        public int IdEtiqueta { get; set; }
        public string Texto { get; set; }

        public Etiqueta ToBaseDatos()
        {
            return new Etiqueta()
            {
                IdEtiqueta = IdEtiqueta,
                Texto = Texto
            };
        }

        public void FromBaseDatos(Etiqueta modelo)
        {
            IdEtiqueta = modelo.IdEtiqueta;
            Texto = modelo.Texto;
        }

        public void UpdateDatos(Etiqueta modelo)
        {
            modelo.IdEtiqueta = IdEtiqueta;
            modelo.Texto = Texto;
        }

        public object[] GetKeys() => new object[] {IdEtiqueta};
    }
}
