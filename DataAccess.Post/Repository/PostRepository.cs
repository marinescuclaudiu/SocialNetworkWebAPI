using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Post.Repository
{
    using Core.Repositories;
    using DataAccess.Post.DataTransferObjects;
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

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
