using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Usuarios.Domain.Entities;

namespace API.Usuarios.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> getUser(Guid idUser);

        Task<IEnumerable<UserEntity>> getAllUsers();

        Task<UserEntity> postUser(UserEntity user);

        Task<UserEntity> putUser(UserEntity user);

        Task<bool> deleteUser(Guid idUser);

        Task<bool> existsUser(Guid idUser);
    }
}
