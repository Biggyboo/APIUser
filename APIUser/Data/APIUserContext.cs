using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIUser.Models
{
    public class APIUserContext : DbContext
    {
        public APIUserContext (DbContextOptions<APIUserContext> options)
            : base(options)
        {
        }

        public DbSet<APIUser.Models.User> User { get; set; }
    }
}
