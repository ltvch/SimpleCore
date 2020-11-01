using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCore.Models
{
    public class OfficeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public OfficeContext(DbContextOptions<OfficeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
