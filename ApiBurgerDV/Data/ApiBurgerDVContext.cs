using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiBurgerDV.Data.Models;

namespace ApiBurgerDV.Data
{
    public class ApiBurgerDVContext : DbContext
    {
        public ApiBurgerDVContext (DbContextOptions<ApiBurgerDVContext> options)
            : base(options)
        {
        }

        public DbSet<ApiBurgerDV.Data.Models.BurgerDv> BurgerDv { get; set; } = default!;
    }
}
