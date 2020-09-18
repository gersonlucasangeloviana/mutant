using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Database
{
    public class DesafioMutantDbContext : DbContext
    {
        public DesafioMutantDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
