using Microsoft.EntityFrameworkCore;
using PDVApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDVApi.Context
{
    public class PDVContext : DbContext
    {
        public PDVContext(DbContextOptions<PDVContext> options ) : base(options)
        { 
        
        }

        public DbSet<PDV> PDVS { get; set; }
    }
}
