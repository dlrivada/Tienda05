using System;
using System.Collections.Generic;
using TiendaRepository.Models;

namespace TiendaRepository.ViewModel
{
    public class ViewModelProducto:IViewModel<Producto>
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public decimal PvP { get; set; }
        public decimal PvC { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }
        public List<ViewModelAlmacen> Almacenes { get; set; }

        public Producto ToBaseDatos()
        {
            return new Producto()
            {
                IdProducto = IdProducto,
                Nombre = Nombre,
                Fabricante = Fabricante,
                PvP = PvP,
                PvC = PvC,
                IdCategoria = IdCategoria
            };
        }

        public void FromBaseDatos(Producto modelo)
        {
            IdProducto = modelo.IdProducto;
            Nombre = modelo.Nombre;
            Fabricante = modelo.Fabricante;
            PvP = modelo.PvP;
            PvC = modelo.PvC;
            IdCategoria = modelo.IdCategoria;
            try
            {
                foreach (ProductoAlmacen productoAlmacen in modelo.ProductoAlmacen)
                {
                    ViewModelAlmacen modeloAlmacen = new ViewModelAlmacen();
                    modeloAlmacen.FromBaseDatos(productoAlmacen.Almacen);
                    Almacenes.Add(modeloAlmacen);

                    Cantidad += productoAlmacen.Cantidad;
                }
            }
            catch (Exception e)
            {
                Cantidad = 0;
            }
        }

        public void UpdateDatos(Producto modelo)
        {
            modelo.IdProducto = IdProducto;
            modelo.Nombre = Nombre;
            modelo.Fabricante = Fabricante;
            modelo.PvP = PvP;
            modelo.PvC = PvC;
            modelo.IdCategoria = IdCategoria;
        }

        public object[] GetKeys() => new object[] {IdProducto};
    }
}
