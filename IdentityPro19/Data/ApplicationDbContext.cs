using IdentityPro19.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityPro19.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        DbSet<ApplicationUser> Gender { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; } 
        DbSet<StudentCourse> StudentCourses { get; set; }   

    }
}
