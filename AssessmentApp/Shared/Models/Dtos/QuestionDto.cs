using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Shared.Models.Dtos
{
    public class QuestionDto
    {
        public string? Id { get; set; }
        public string Subject { get; set; }
        public string Program { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Class { get; set; }
    }
}
