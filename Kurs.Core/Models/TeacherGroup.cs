using Kurs.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Core.Models
{
    public class TeacherGroup:BaseEntity
    {
        public string SubjectName { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
    }
}
