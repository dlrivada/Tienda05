using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TiendaRepository.ViewModel;

namespace TiendaRepository.Repository
{
    public class RepositoryViewModelEFModel<TModel, TViewModel> : IRepository<TModel, TViewModel> where TModel : class where TViewModel : IViewModel<TModel>, new()
    {
        private readonly DbContext _context;
        protected DbSet<TModel> DbSet { get { return _context.Set<TModel>(); } }
        public const int NoChanges = 0;

        public RepositoryViewModelEFModel(DbContext context)
        {
            _context = context;
        }

        public TViewModel Add(TViewModel model)
        {
            TModel m = model.ToBaseDatos();
            DbSet.Add(m);
            try
            {
                _context.SaveChanges();
                model.FromBaseDatos(m);
                return model;
            }
            catch (Exception e)
            {
                return default(TViewModel);
            }
        }

        public int Borrar(TViewModel model)
        {
            TModel m = DbSet.Find(model.GetKeys());
            DbSet.Remove(m);
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                return NoChanges;
            }
        }

        public int Borrar(Expression<Func<TModel, bool>> expression)
        {
            IQueryable<TModel> data = DbSet.Where(expression);
            DbSet.RemoveRange(data);

            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                return NoChanges;
            }
        }

        public int Actualizar(TViewModel model)
        {
            TModel m = DbSet.Find(model.GetKeys());
            model.UpdateDatos(m);

            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                return NoChanges;
            }
        }

        public ICollection<TViewModel> Get()
        {
            List<TViewModel> oViewModelsModels = new List<TViewModel>();
            TViewModel oViewModel;

            foreach (TModel model in DbSet)
            {
                oViewModel=new TViewModel();
                oViewModel.FromBaseDatos(model);
                oViewModelsModels.Add(oViewModel);
            }
            return oViewModelsModels;
        }

        public TViewModel Get(params object[] keys)
        {
            TModel oModel = DbSet.Find(keys);
            TViewModel oViewModel = new TViewModel();
            oViewModel.FromBaseDatos(oModel);
            return oViewModel;
        }

        public ICollection<TViewModel> Get(Expression<Func<TModel, bool>> expression)
        {
            IQueryable<TModel> oQueryableModels = DbSet.Where(expression);
            List<TViewModel> oViewModels = new List<TViewModel>();
            TViewModel oViewModel;

            foreach (TModel oQueryableModel in oQueryableModels)
            {
                oViewModel = new TViewModel();
                oViewModel.FromBaseDatos(oQueryableModel);
                oViewModels.Add(oViewModel);
            }
            return oViewModels;
        }
    }
}