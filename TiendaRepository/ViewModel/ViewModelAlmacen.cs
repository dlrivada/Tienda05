using System.Collections.Generic;
using TiendaRepository.Models;

namespace TiendaRepository.ViewModel
{
    public class ViewModelAlmacen:IViewModel<Almacen>
    {
        public int IdAlmacen { get; set; }
        public string Ciudad { get; set; }
        public string CP { get; set; }
        public List<ViewModelProducto> Productos { get; set; }

        public Almacen ToBaseDatos()
        {
            return new Almacen()
            {
                IdAlmacen = IdAlmacen,
                Ciudad = Ciudad,
                CP = CP
            };
        }

        public void FromBaseDatos(Almacen modelo)
        {
            IdAlmacen = modelo.IdAlmacen;
            Ciudad = modelo.Ciudad;
            CP = modelo.CP;
            foreach (ProductoAlmacen productoAlmacen in modelo.ProductoAlmacen)
            {
                ViewModelProducto modeloProducto = new ViewModelProducto();
                modeloProducto.FromBaseDatos(productoAlmacen.Producto);
                Productos.Add(modeloProducto);
            } 
        }

        public void UpdateDatos(Almacen modelo)
        {
            modelo.IdAlmacen = IdAlmacen;
            modelo.Ciudad = Ciudad;
            modelo.CP = CP;
        }

        public object[] GetKeys() => new object[] {IdAlmacen};
    }
}
