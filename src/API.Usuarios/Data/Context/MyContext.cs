using API.Usuarios.Data.Mapping;
using API.Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Usuarios.Data.Context
{
    public class MyContext : DbContext
    {
        DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
