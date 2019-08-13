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
    public class QuestionController : ControllerBase
    {
        public QuizDBContext _context { get; set; }
        public QuestionController(QuizDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            if (!_context.Quizzes.Any(q => q.ID == question.QuizId))
                return NotFound("quiz id not found");

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _context.Questions;
        }

        [HttpGet("{quizid}")]
        public IEnumerable<Question> Get(int quizid)
        {        

            return _context.Questions.Where(q=>q.QuizId==quizid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question question)
        {
            if (question.ID != id)
                return BadRequest();

            _context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(question);
        }
    }
}