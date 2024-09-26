using Microsoft.EntityFrameworkCore;
using Person.Model;
using System.Collections.Generic;

namespace Person.APIContext
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<People> people { get; set; }
    }
}
