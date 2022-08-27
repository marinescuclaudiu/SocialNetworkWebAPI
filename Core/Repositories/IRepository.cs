namespace Core.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);

        IEnumerable<T> GetAll(int offset, int limit);

        Task<T?> FindById(int userId);

        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
