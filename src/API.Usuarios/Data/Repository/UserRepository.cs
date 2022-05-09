using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Usuarios.Data.Context;
using API.Usuarios.Domain.Entities;
using API.Usuarios.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Usuarios.Data.Repository
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : UserEntity
    {
        protected readonly MyContext _context;

        private DbSet<TEntity> _dataset;

        public UserRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<TEntity>();
        }
        public async Task<TEntity> createUser(TEntity user)
        {
            try
            {
                if (user.Id == Guid.Empty)
                {
                    user.Id = Guid.NewGuid();
                }

                user.CreateAt = DateTime.UtcNow;
                user.UpdateAt = DateTime.UtcNow;
                _dataset.Add(user);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public async Task<bool> deleteUser(Guid idUser)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(user => user.Id.Equals(idUser));

                if (result != null)
                {
                    _dataset.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> existsUser(Guid idUser)
        {
            try
            {
                var result = await _dataset.AnyAsync(user => user.Id.Equals(idUser));
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> selectAllUser()
        {
            try
            {
                return await _dataset.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> selectUser(Guid idUser)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(user => user.Id.Equals(idUser));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> updateUser(TEntity user)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(u => u.Id.Equals(user.Id));
                if (result != null)
                {

                    user.UpdateAt = DateTime.UtcNow;
                    user.CreateAt = result.CreateAt;

                    _context.Entry(result).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}
