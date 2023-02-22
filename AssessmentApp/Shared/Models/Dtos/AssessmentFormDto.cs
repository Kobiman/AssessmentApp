using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Shared.Models.Dtos
{
    public sealed class AssessmentFormDto
    {
        public string? Id { get; set; }
        public string? Subject { get; set; }
        public string? Program { get; set; }
        public string? Class { get; set; }
        public IList<ResponseDto> Response = new List<ResponseDto>();
    }
    public sealed class ResponseDto
    {
        public string? QuestionId { get; set; }
        public string? Question { get; set; }
        public int Weight { get; set; }
    }
}
