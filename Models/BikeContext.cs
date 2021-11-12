using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycles.WebAPI.Models
{
    public class BikeContext : DbContext
    {
        public DbSet<Bike> Bicycles { get; set; }

        public BikeContext(DbContextOptions<BikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
