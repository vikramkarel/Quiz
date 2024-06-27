using Microsoft.EntityFrameworkCore;
using QuizPortal.Models;
using System.Data;

namespace QuizPortal.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LoginSignUp> loginSignUp { get; set; }
        public DbSet<QuizzesTable> CreatedBy { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginSignUp>().HasData(
                new LoginSignUp() { User_Id = 1, UserName = "Vikram", Password = "VK", Email = "vikramkarel@gmail.com", Role = "SuperAdmin" }
                );

            /*modelBuilder.Entity<QuizzesTable>()
                .HasAlternateKey(x => x.Guid);*/

            modelBuilder.Entity<QuizzesTable>()
                .HasOne(q => q.Creator)  // A quiz is created by one user
                .WithMany(u => u.CreatedQuizzes)  // A user can create multiple quizzes
                .HasForeignKey(q => q.UserId);  // Foreign key in QuizzesTable referencing User


        }


    }
}

