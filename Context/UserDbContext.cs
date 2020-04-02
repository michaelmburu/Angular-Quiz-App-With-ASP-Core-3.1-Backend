using Microsoft.EntityFrameworkCore;
using Quiz_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Backend.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }

        public DbSet<Credentials> Credentials { get; set; }
       
    }
}
