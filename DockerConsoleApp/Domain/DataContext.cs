using hw4Sber.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> Operations { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //    //options.UseNpgsql();
        //
        //}

        public DataContext() : base()
        {   
            Database.EnsureCreated();       
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
            Database.EnsureCreated();
        }


        /*
        public DataContext(DbContextOptions<DataContext> options,
            DbContextOptionsBuilder<DataContext> OptionsBuilder) : this(options)
        {
            this.OnConfiguring(OptionsBuilder);

            Database.EnsureCreated();
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {               
            optionsBuilder.UseNpgsql(Program.Config.GetConnectionString("db")
                , x => x.MigrationsHistoryTable("__MyMigrationsHistory", "public")
                );
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }   
}
