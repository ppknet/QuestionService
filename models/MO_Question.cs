using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionService.Models
{
    public class Question
    {
        public int ID { get; set; }
        [Required]
        public int QuizId { get; set; }

        [Required]
        [DataType("nvarchar(300)")]
        public string text { get; set; }
        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

    }
}
