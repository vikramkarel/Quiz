namespace QuizPortal.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string QuestionText { get; set; }
        public string ImageUrl { get; set; }

        // Navigation property for Quiz
        public QuizzesTable QuizzesTable { get; set; }
        // Collection navigation property for options associated with this question
        public ICollection<Option> Options { get; set; }
    }
}
