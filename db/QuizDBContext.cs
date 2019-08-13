using Microsoft.EntityFrameworkCore;
using QuestionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionService.DB
{
    public class QuizDBContext:DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options):base(options)
        {

        }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}
