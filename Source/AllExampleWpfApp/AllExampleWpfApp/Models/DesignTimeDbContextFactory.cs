using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExampleWpfApp.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionBuilder.UseSqlite("Data Source=products.db");
            return new ProductContext(optionBuilder.Options);
        }
    }
}
