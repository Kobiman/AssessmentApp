using AssessmentApp.Shared.Models;
using AssessmentApp.Shared.Models.Dtos;
using KMapper;
using System.Text.Json;

namespace AssessmentApp.Server.Services
{
    public interface IQuestionService
    {
        void AddQuestion(QuestionDto question);
        void UpdateQuestion(QuestionDto question);
        IEnumerable<QuestionDto> GetAllQuestions();
        void DeleteQuestion(string questionId);
    }
    public class QuestionService : IQuestionService
    {
        IList<AssessmentQuestion> questions;
        public QuestionService()
        {
            using FileStream openStream = File.OpenRead($"wwwroot/json/Questions.json");
            questions = JsonSerializer.DeserializeAsync<IList<AssessmentQuestion>>(openStream).Result;
        }
        public void AddQuestion(QuestionDto questionDto)
        {
            var question = questionDto.Map<AssessmentQuestion, QuestionDto>();
            questions.Add(question);
            using var sw = new StreamWriter($"wwwroot/json/Questions.json", false);
            var json = JsonSerializer.Serialize(questions);
            sw.Write(json);
        }

        public void DeleteQuestion(string questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            return questions.Select(x=>x.Map<QuestionDto, AssessmentQuestion>());
        }

        public void UpdateQuestion(QuestionDto question)
        {
            throw new NotImplementedException();
        }
    }
}
