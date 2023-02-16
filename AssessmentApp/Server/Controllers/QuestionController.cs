using AssessmentApp.Server.Services;
using AssessmentApp.Shared.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        [Route("AddQuestion")]
        public IActionResult AddQuestion([FromBody]QuestionDto questionDto)
        {
            _questionService.AddQuestion(questionDto);
            return Ok();
        }

        [HttpGet]
        [Route("GetQuestions")]
        public IActionResult GetQuestions()
        {
            return Ok(_questionService.GetAllQuestions());
        }
    }
}
