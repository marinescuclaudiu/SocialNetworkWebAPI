namespace DatabaseAccess.Repositories
{
    using Core.Repositories;
    using DatabaseAccess.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PostRepository : IRepository<Post>
    {
        public void Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> FindById(int userId)
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post entity)
        {
            throw new NotImplementedException();
        }

        Task<Post> IRepository<Post>.Add(Post entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Post>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Post> IRepository<Post>.Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
