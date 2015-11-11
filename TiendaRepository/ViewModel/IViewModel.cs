namespace TiendaRepository.ViewModel
{
    /// <summary>
    /// Interfaz TViewModel para el Modelo de Datos
    /// </summary>
    /// <typeparam name="TModel">Tipo Modelo de Datos</typeparam>
    public interface IViewModel<TModel> where TModel : class 
    {
        TModel ToBaseDatos();

        void FromBaseDatos(TModel modelo);

        void UpdateDatos(TModel modelo);

        object[] GetKeys();
    }
}
