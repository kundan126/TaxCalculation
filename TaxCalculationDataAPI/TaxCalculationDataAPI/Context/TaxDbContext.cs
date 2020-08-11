using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationDataAPI.Context
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions  dbContextOptions) : base(dbContextOptions)
        {

        }
       public DbSet<Tax> Taxes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tax>().HasData(new Tax
            {
                TaxId = 2,
                MunicipalityName = "Copenhagen",
                Date ="2016.07.10",
                TaxRate =0.2

            }, new Tax
            {
                TaxId = 3,
                MunicipalityName = "Copenhagen",
                Date = "2016.05.02",
                TaxRate = 0.4
            }, new Tax
            {
                TaxId = 4,
                MunicipalityName = "Copenhagen",
                Date = "2016.01.01",
                TaxRate = 0.1
            });
        }
    }
}
