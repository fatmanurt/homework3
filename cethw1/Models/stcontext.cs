using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace cethw1.Models
{
    public class stcontext : DbContext
    {
        public stcontext(DbContextOptions<stcontext> options) : base(options)
        {
           
        }
        public DbSet<student> Books { get; set; }
        public DbSet<cethw1.Models.department> departments { get; set; }

    }
}
