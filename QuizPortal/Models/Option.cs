namespace QuizPortal.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; } // Foreign key referencing the question to which this option belongs
        public string OptionText { get; set; }
        public string ImageUrl { get; set; }

        // Navigation property for the question to which this option belongs
        public Question Question { get; set; }
    }
}
