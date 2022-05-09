using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Usuarios.Domain.Interfaces
{
    public interface IUserRepository<UserEntity>
    {
        Task<UserEntity> createUser(UserEntity user);

        Task<bool> deleteUser(Guid idUser);

        Task<UserEntity> updateUser(UserEntity user);

        Task<bool> existsUser(Guid idUser);

        Task<UserEntity> selectUser(Guid idUser);

        Task<IEnumerable<UserEntity>> selectAllUser();
    }
}
