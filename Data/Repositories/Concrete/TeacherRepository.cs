using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        static int id;
        public List<Teacher> GetAll()
        {
            return DbContext.Teachers;        }
        public Teacher Get(int Id)
        {
            return DbContext.Teachers.FirstOrDefault(t => t.Id == id);
        }
        public void Add(Teacher teacher)
        {
            id++;
            teacher.Id = id;
DbContext.Teachers.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            var dbTeacher = DbContext.Teachers.FirstOrDefault(t => t.Id == teacher.Id);
            if (dbTeacher != null)
            {
                dbTeacher.Name = teacher.Name;
                dbTeacher.SurName = teacher.SurName;
                dbTeacher.BirthDate = teacher.BirthDate;
                dbTeacher.Speciality = teacher.Speciality;




            }
        }
        public void Delete(Teacher teacher)
        {
            DbContext.Teachers.Remove(teacher);        }



    }
}
