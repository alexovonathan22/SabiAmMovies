using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SabiAmMovies.WebAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SabiAmMovies.WebAPI.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        protected DataContext Context;
        private readonly ILogger<Repository<T>> _logger;

        #endregion

        public Repository(DataContext context, ILogger<Repository<T>> log)
        {
            _logger = log;
            Context = context;
        }

        #region Repository's Public Methods

        public async Task<T> LoadById(int id) => await Context.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<T> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(Insert)} entity cannot be null");
            try
            {
                await Context.Set<T>().AddAsync(entity);
                await Context.SaveChangesAsync();
                _logger.LogInformation($"Successfully Saved {entity}");
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                throw new Exception($"{nameof(entity)} could not be saved: {ex}");
            }
        }
        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(Update)} entity cannot be null");
            // In case AsNoTracking is used
            try
            {
                //Context.Attach(entity);
                //Context.Entry(entity).State = EntityState.Modified;
                //Context.Set<T>().Update(entity);

                Context.Update(entity);
                await Context.SaveChangesAsync();

                _logger.LogInformation($"Successfully Updated {entity}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
            }
        }

        public async Task UpdateLists(List<T> entities)
        {
            if (entities == null) throw new ArgumentNullException($"{nameof(Update)} entities cannot be null");
            // In case AsNoTracking is used
            try
            {
                //Context.Attach(entity);
                //Context.Entry(entity).State = EntityState.Modified;
                //Context.Set<T>().Update(entity);

                Context.UpdateRange(entities);
                await Context.SaveChangesAsync();

                _logger.LogInformation($"Successfully Updated {entities.Count}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
            }
        }

        public async Task Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(Remove)} entity cannot be null");
            _logger.LogInformation($"Tryiing to  Delete {entity}");
            Context.Set<T>().Remove(entity);
            _logger.LogInformation($"Successfully Deleted {entity}");
            await Context.SaveChangesAsync();
        }

        public async Task<List<T>> LoadAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");

                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        // TODO: Implement methods with AsNoTracking for when retreieval of data is the goal and not making changes.
        public async Task<List<T>> LoadWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().AsNoTracking().CountAsync(predicate);



        #endregion

    }
}
