using ANK13Identity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ANK13Identity.Models;
using ANK13Identity.Entities;

namespace ANK13Identity.Areas.Identity.Data;

public class ANK13IdentityContext : IdentityDbContext<ANK13IdentityUser>
{
    public ANK13IdentityContext(DbContextOptions<ANK13IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ANK13Identity.Entities.Lesson>? Lesson { get; set; }

    // public DbSet<ANK13Identity.Models.RoleViewModel>? RoleViewModel { get; set; }

    public DbSet<StudentLesson> StudentLessons { get; set; }
}
