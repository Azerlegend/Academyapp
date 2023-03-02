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
    public class StudentRepository : IStudentRepository
    {
        static int id;
        public List<Student> GetAll()
        {
            return DbContext.Students;
        }
        public Student Get(int Id)
        {
          return DbContext.Students.FirstOrDefault(s => s.Id == Id);
        }


     
        public void Add(Student student)
        {
            id++;
            student.Id = id;
            DbContext.Students.Add(student);
        }



        public void Update(Student student)
        {
            var dbStudent = DbContext.Students.FirstOrDefault(s => s.Id == student.Id);
            if (dbStudent is not null)
            {
            dbStudent.Name = student.Name;
                dbStudent.SurName = student.SurName;
                dbStudent.BirthDate = student.BirthDate;
                dbStudent.Group= student.Group;
                dbStudent.GroupId= student.GroupId;



            }



        }       
        public void Delete(Student student)
        {
            DbContext.Students.Remove(student);
        }

        public bool isDuplicateEmail(string email)
        {
          return   DbContext.Students.Any(s => s.Email == email);
        }
    }
}
