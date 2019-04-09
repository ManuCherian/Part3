using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class DbModel : DbContext
    {
        public DbModel(DbContextOptions<DbModel> options) : base(options)
        {

        }
        public DbSet<MyEvent> MyEvents { get; set; }
    }
}
