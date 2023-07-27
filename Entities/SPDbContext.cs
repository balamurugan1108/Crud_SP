using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SPDbContext:DbContext
    {
        public SPDbContext(DbContextOptions<SPDbContext> options) : base(options)
        {

        }
        public DbSet<SPModel> Players { get; set; }
    }
}
