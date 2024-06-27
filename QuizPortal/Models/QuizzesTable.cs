using System.ComponentModel.DataAnnotations;

namespace QuizPortal.Models
{
    public class QuizzesTable
    {
        [Key]
        public int QuizId { get; set; }
        [Required]
        [StringLength(20)]
        public string QuizName { get; set; }
        [Required]
        [StringLength(20)]
        public int CreatedBy { get; set; }
        [Required]
        public int Duration { get; set; }

        public DateTime StartTime { get; set; } // Assuming you want to track when the quiz starts

        // Navigation property for the user who created the quiz
        public LoginSignUp Creator { get; set; }

        // Foreign key property
        public int UserId { get; set; }

        // Collection navigation property for questions in this quiz
        public ICollection<Question> Questions { get; set; }
    }
}
