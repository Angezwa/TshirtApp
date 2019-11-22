using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TshirtWebApp.Models
{
    public class TeesContext : DbContext
    {
        public TeesContext(DbContextOptions<TeesContext> options)
           : base(options)
        {
        }

        public DbSet<Tee> Tees { get; set; }
    }
}
