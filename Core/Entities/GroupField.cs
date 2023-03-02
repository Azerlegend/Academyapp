using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GroupField : BaseEntity
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}
