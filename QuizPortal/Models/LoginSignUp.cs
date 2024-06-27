using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuizPortal.Models
{
    public class LoginSignUp ()
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [ValidateNever]
        public string Email { get; set; }
        [Required]
        [ValidateNever]
        public string Role { get; set; }
        [ValidateNever]

        public ICollection<QuizzesTable> CreatedQuizzes { get; set; }


    }
}
