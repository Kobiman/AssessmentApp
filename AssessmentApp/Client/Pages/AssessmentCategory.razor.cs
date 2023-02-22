using AssessmentApp.Client.Events;
using AssessmentApp.Client.Service;
using AssessmentApp.Shared.Models.Dtos;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace AssessmentApp.Client.Pages
{
    public partial class AssessmentCategory : IAssementFormObserver
    {
        [Inject]
        IAssementFormNotifier? Notifier { get; set; }
        [Inject]
        IAssementService? AssementService { get; set; }

        [Parameter]
        public IEnumerable<QuestionDto>? Questions { get; set; }

        public List<ResponseDto> response { get; set; }

        protected override void OnInitialized()
        {
            response = Questions.Select(x => new ResponseDto { QuestionId = x.Id, Question = x.Question, Weight = 1 }).ToList();
            Notifier?.Subscribe(this);
        }

        void NotifyParent()
        {
            AssementService?.Add(response);
        }
        public void Update(IList<ResponseDto> data)
        {
           NotifyParent(); 
        }
    }
}
