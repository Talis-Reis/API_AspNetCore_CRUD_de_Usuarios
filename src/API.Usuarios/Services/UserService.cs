using System;
using System.Threading.Tasks;
using API.Usuarios.Data.Repository;
using API.Usuarios.Domain.Entities;
using API.Usuarios.Domain.Interfaces;
using API.Usuarios.Domain.Interfaces.Services.User;

namespace API.Usuarios.Services
{
    public class UserService : IUserService
    {

        private IUserRepository<UserEntity> _repository;

        public UserService(IUserRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> deleteUser(Guid idUser)
        {
            return await _repository.deleteUser(idUser);
        }

        public async Task<bool> existsUser(Guid idUser)
        {
            return await _repository.existsUser(idUser);
        }

        public async Task<System.Collections.Generic.IEnumerable<UserEntity>> getAllUsers()
        {
            return await _repository.selectAllUser();
        }

        public async Task<UserEntity> getUser(Guid idUser)
        {
            return await _repository.selectUser(idUser);
        }

        public async Task<UserEntity> postUser(UserEntity user)
        {
            return await _repository.createUser(user);
        }

        public async Task<UserEntity> putUser(UserEntity user)
        {
            return await _repository.updateUser(user);
        }
    }
}
