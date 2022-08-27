namespace DataAccess.User.Repository
{
    using Core.Repositories;
    using DatabaseAccess.Context;
    using DatabaseAccess.Models;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    public class UserRepository : IRepository<User>
    {
        private readonly SocialNetworkContext _socialNetworkContext;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(SocialNetworkContext socialNetworkContext, ILogger<UserRepository> logger)
        {
            _socialNetworkContext = socialNetworkContext;
            _logger = logger;
        }

        public async Task<User> Add(User entity)
        {
            _socialNetworkContext.Add(entity);
            await _socialNetworkContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var user = await _socialNetworkContext.Users.FindAsync(id);
            if (user != null)
            {
                _socialNetworkContext.Users.Remove(user);
                await _socialNetworkContext.SaveChangesAsync();
            }

        }

        public async Task<User?> FindById(int userId)
        {
            return await _socialNetworkContext.Users.FindAsync(userId);
        }

        public IEnumerable<User> GetAll(int offset, int limit)
        {
            _logger.LogInformation("Getting users with offset={offset} and limit={limit}", offset, limit);
            return _socialNetworkContext.Users.OrderBy(u => u.Id).Skip(offset - 1).Take(limit);
        }

        public async Task<User> Update(User entity)
        {
            _socialNetworkContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _socialNetworkContext.SaveChangesAsync();
            return entity;
        }
    }
}
