using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Auth01.Models;

namespace Auth01.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Auth01.Models.FAQModel>? FAQModel { get; set; }
        public DbSet<Auth01.Models.FAQCat>? FAQCat { get; set; }
    }
}