using hw4.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace hw4Sber.Abstractions
{
    public class ControllerBase<T> where T : BaseEntity, new()
    {
        IRepository<T> Repository { get; set; }
        public ControllerBase(IRepository<T> repo)
        {
            Repository = repo;            
        }  
        
        async Task Add(T entity)
        {
            await Repository.AddAsync(entity);            
        }

        async Task Delete(Guid id)
        {
            await Repository.DeleteAsync(id);
        }
    }
}