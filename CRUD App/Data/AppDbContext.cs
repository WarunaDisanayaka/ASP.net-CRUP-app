using Microsoft.EntityFrameworkCore;
using CRUD_App.Models;

namespace CRUD_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Student { get; set; }


    }
 }

