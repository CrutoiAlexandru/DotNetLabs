using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crutoi_Alexandru_Lab2.Models;

namespace Crutoi_Alexandru_Lab2.Data
{
    public class Crutoi_Alexandru_Lab2Context : DbContext
    {
        public Crutoi_Alexandru_Lab2Context (DbContextOptions<Crutoi_Alexandru_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Crutoi_Alexandru_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Crutoi_Alexandru_Lab2.Models.Publisher> Publisher { get; set; }
    }
}
