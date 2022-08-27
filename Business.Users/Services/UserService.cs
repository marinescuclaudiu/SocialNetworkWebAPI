using Core.Contracts;
using Core.Models;
using Core.Repositories;
using DatabaseAccess.Models;

namespace Business.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> CreateUser(string firstName, string lastName, string username)
        {
            var user = new User { FirstName = firstName, LastName = lastName, Username = username };

            _userRepository.Add(user);

            return new UserModel { FirstName = user.FirstName, LastName = user.LastName };
        }

        public List<UserModel> GetAll(int offset, int limit)
        {
            var listOfDALUsers = _userRepository.GetAll(offset, limit);

            return listOfDALUsers.Select(element => new UserModel
            {
                Id = element.Id,
                FirstName = element.FirstName,
                LastName = element.LastName
            }).ToList();
        }

        public async Task<UserModel> UpdateUser(int userId, string firstName, string lastName)
        {
            var user = await _userRepository.FindById(userId);
           
            if(user == null)
            {
                throw new InvalidOperationException("User was not found.");
            }

            user.FirstName = firstName;
            user.LastName = lastName;

            var updatedUser = await _userRepository.Update(user);

            return new UserModel { Id = updatedUser.Id, FirstName = updatedUser.FirstName, LastName = updatedUser.LastName }; ;
        }

        public async Task<UserModel?> GetById(int userId)
        {
            var user = await _userRepository.FindById(userId);
            if (user == null)
                return null;
            return new UserModel { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
        }

        public async Task DeleteUser(int userId)
        {
          await _userRepository.Delete(userId);
        }
    }
}
