using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionService.DB;
using QuestionService.Models;

namespace QuestionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class QuizController : ControllerBase
    {
        public QuizDBContext _context { get; set; }
        public QuizController(QuizDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return Ok(quiz);
        }

        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            return _context.Quizzes;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Quiz quiz)
        {
            if (quiz.ID != id)
                return BadRequest();

            _context.Entry(quiz).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(quiz);
        }
    }
}