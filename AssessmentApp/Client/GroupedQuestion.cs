using AssessmentApp.Shared.Models.Dtos;

namespace AssessmentApp.Client
{
    internal sealed record GroupedQuestion(string Category, List<QuestionDto> Questions);
}
