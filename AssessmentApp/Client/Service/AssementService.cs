using AssessmentApp.Shared.Models.Dtos;

namespace AssessmentApp.Client.Service
{
    public interface IAssementService
    {
        IList<ResponseDto> Response { get; }

        void Add(IList<ResponseDto> response);
    }

    public class AssementService : IAssementService
    {
        public IList<ResponseDto> Response { get; } = new List<ResponseDto>();
        public void Add(IList<ResponseDto> response)
        {
            foreach (var item in response)
            {
                var result = Response.FirstOrDefault(x => x.QuestionId == item.QuestionId);
                if (result != null)
                {
                    Response.Remove(item);
                }
                Response.Add(item);
            }
        }
    }
}
