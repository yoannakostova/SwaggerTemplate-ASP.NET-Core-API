using Microsoft.EntityFrameworkCore;
using SwaggerTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerTemplate.Database
{
    public class SwaggerTemplateDbContext : DbContext
    {
        public SwaggerTemplateDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
