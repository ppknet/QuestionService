using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionService.Models
{
    public class Quiz
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

      //  public ICollection<Question> Questions { get; set; }
    }
}
