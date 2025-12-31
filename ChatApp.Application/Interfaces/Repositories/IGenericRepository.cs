namespace ChatApp.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<bool> ExistsAsync(int id);

        Task AddAsync(T entity,IFormFile? file=default,string? email=default);
        //Task UpdateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        void Delete(T entity);
    }
}
