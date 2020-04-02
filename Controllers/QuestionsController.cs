using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_Backend.Context;
using Quiz_Backend.Models;

namespace Quiz_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase 
    {
        readonly QuizContext context;
        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            var quiz = context.Quiz.SingleOrDefault(q => q.Id == question.QuizId);

            if (quiz == null)
                return NotFound();

            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return context.Questions;
        }

        [HttpGet("{quizId}")]
        public IEnumerable<Question> Get([FromRoute] int quizId)
        {
            return context.Questions.Where(q => q.QuizId == quizId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question question)
        {
            if (id != question.Id)
                return BadRequest();
            context.Entry(question).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);
        }
    }
}