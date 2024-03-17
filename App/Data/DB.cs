using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
         public DbSet<CarClass> CarTable { get; set; }
    }
}
