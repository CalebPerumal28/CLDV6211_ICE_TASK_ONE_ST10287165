using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICE_Task_One.Models;

namespace ICE_Task_One.Data
{
    public class ICE_Task_OneContext : DbContext
    {
        public ICE_Task_OneContext(DbContextOptions<ICE_Task_OneContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!; // Add this line
    }
}