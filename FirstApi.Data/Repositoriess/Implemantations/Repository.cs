using FirstApi.Data.Contexts;
using FirstApi.Core.Repositories1;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstApi.Data.Repositories.Implemantations
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApiDbContext apiDbContextt;
        public Repository(ApiDbContext apiDbContext)
        {
            apiDbContextt= apiDbContext;
        }

        public  async Task AddAsync(T entity)
        {
            await apiDbContextt.Set<T>().AddAsync(entity);   
        }

        public  IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return  apiDbContextt.Set<T>().Where(expression);
        }

        public async Task<T> GetBYId(Expression<Func<T, bool>> expression)
        {
            return  await apiDbContextt.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return    apiDbContextt.Set<T>().Where(expression).Count() > 0;    
        }

        public async Task Remove(T entity)
        {
           apiDbContextt.Remove(entity);    
        }

        public int Save()
        {
            return apiDbContextt.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await apiDbContextt.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            apiDbContextt.Update(entity);   
        }

       
    }
}
