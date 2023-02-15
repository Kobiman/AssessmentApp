using AssessmentApp.Shared.Models;
using AssessmentApp.Shared.Models.Dtos;
using KMapper;

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
            questions = new List<AssessmentQuestion>();
        }
        public void AddQuestion(QuestionDto questionDto)
        {
            var question = questionDto.Map<AssessmentQuestion, QuestionDto>();
            questions.Add(question);
        }

        public void DeleteQuestion(string questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(QuestionDto question)
        {
            throw new NotImplementedException();
        }
    }
}
