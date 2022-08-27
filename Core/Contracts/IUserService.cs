using Core.Models;

namespace Core.Contracts
{
    public interface IUserService
    {
        List<UserModel> GetAll(int offset, int limit);

        Task<UserModel> CreateUser(string firstName, string lastName, string username);

        Task<UserModel> UpdateUser(int userId, string firstName, string lastName);
        Task<UserModel?> GetById(int userId);

        Task DeleteUser(int userId);
    }
}
