using Kurs.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Core.Models
{
    public  class Group:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
