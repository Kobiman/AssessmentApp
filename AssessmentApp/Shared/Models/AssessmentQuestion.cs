using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Shared.Models
{
    public class AssessmentQuestion
    {
        public string AssessmentQuestionId { get; set; } = Guid.NewGuid().ToString();
        public string Subject { get; set; }
        public string Program { get; set; }
        public string Question { get; set; }
        public string Class { get; set; }
    }
}
