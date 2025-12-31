
using ChatApp.Application.Interfaces.Repositories;

namespace ChatApp.Persistence.Repositories
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext,
                                      IFileService _fileService) : IGenericRepository<T> where T : class,IEntity,IHasImage
    {
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext
                    .Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == id);//.FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id")==id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                    .Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext
                    .Set<T>()
                    .AsNoTracking()
                    .AnyAsync(t => t.Id == id);
        }


        public async Task AddAsync(T entity, IFormFile? file = null, string? email = null)
        {
            ArgumentNullException.ThrowIfNull(entity);

            if (file is not null && file.Length > 0 && entity is IHasImage imageEntity)
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException(nameof(email));

                var filePath = await _fileService.SaveImageAsync(file, email);
                imageEntity.ImageUrl = filePath;
            }

            await _dbContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await _dbContext.Set<T>().FirstOrDefaultAsync(c=>c.Id ==id);

            //if (entity is null)
            //    return false;

            Delete(entity);
            //return true;
        }
       
    }
}
