using Microsoft.EntityFrameworkCore;
using System;
using TestforMappers.Model;

namespace TestforMappers.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}
