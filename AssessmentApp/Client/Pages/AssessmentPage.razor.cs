using AssessmentApp.Client.Events;
using AssessmentApp.Client.Service;
using AssessmentApp.Shared.Models.Dtos;
using Blazored.TextEditor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using System.Net.Http.Json;

namespace AssessmentApp.Client.Pages
{
    public partial class AssessmentPage
    {
        [Inject]
        IAssementFormNotifier? Notifier { get; set; }
        [Inject]
        IAssementService? AssementService { get; set; }
        private IEnumerable<ProgramDto> programs { get; set; } = new List<ProgramDto>();
        bool success;
        string[] errors = { };
        string[] category;
        string[] nclass;
        string[] subject;
        public string TextValue { get; set; }
        BlazoredTextEditor QuillHtml;
        string QuillHTMLContent;
        string? Title;
        bool hasComment;

        private IEnumerable<QuestionDto> Questions = new List<QuestionDto>();
        private IEnumerable<QuestionDto> questions = new List<QuestionDto>();
        private IEnumerable<GroupedQuestion> groupedQuestions;
        IEnumerator<GroupedQuestion> enumerator;

        AssessmentFormDto model = new();

        private async void OnValidSubmit(EditContext context)
        {
           model.Response = AssementService?.Response;
            //QuillHTMLContent = await QuillHtml.GetHTML();
            //model.Response = QuillHTMLContent;
            //var response = await Http.PostAsJsonAsync("api/Question/AddQuestion", model);
        }
        protected override async Task OnInitializedAsync()
        {
            Title = "AssessmentPage";
            programs = new List<ProgramDto> {
            new ProgramDto { ProgramId = "General Science", Name = "General Science" },
            new ProgramDto { ProgramId = "Agriculture Science", Name = "Agriculture Science" } };
            nclass = new string[] { "S.H.S 1", "S.H.S 2", "S.H.S 3" };
            subject = new string[] { "English Language", "Mathematics", "Integrated Science" };

            var result = await Http.GetFromJsonAsync<List<QuestionDto>>("api/Question/GetQuestions");
            if (result is not null)
            {
                questions = result;
            }
            else
            {
                questions = new List<QuestionDto>();
            }
        }

        private void Start()
        {
            groupedQuestions = questions.Where(x => x.Program == model.Program && x.Subject == model.Subject && x.Class == model.Class)
            .GroupBy(x => x.Category)
            .Select(x => new GroupedQuestion(x.Key, x.ToList()))
            .ToList();
            enumerator = groupedQuestions.GetEnumerator();
            MoveNext();
        }

        private void MoveNext()
        {
            if (enumerator.MoveNext())
            {
                Title = enumerator.Current.Category;
                Questions = enumerator.Current.Questions;
                Notifier?.Notify(null);
            }
        }
    }
}
