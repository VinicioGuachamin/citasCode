using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pruebaBackendPry.Models;

namespace pruebaBackendPry
{
    public class AplicationDbContext: DbContext
    {
        private DbSet<Test> PruebaDB { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
