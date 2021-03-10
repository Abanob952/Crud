using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public StoreDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
