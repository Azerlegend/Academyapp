using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            Students= new List<Student>();
        }
        public string Name { get; set; }
        public int MaxSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students{ get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public GroupField Field { get; set; }
        public int FieldId { get; set; }
    }
}
