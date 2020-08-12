using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Data
{
    public class MyFirstMvcAppDbContext : DbContext
    {
        public MyFirstMvcAppDbContext (DbContextOptions<MyFirstMvcAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyFirstMvcApp.Models.ContactListEntry> ContactListEntry { get; set; }
    }
}
