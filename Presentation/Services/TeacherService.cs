using Core.Entities;
using Core.Helpers;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }
        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count== 0)
            {
                ConsoleHelper.WriteWithColor("There is no any teacher", ConsoleColor.Red);
            }
            foreach (var teacher in teachers)
            {
                ConsoleHelper.WriteWithColor($"Id: {teacher.Id}  Fullname: {teacher.Name}{teacher.SurName},Speciality :{teacher.Speciality}", ConsoleColor.Cyan);
                if(teacher.Groups.Count == 0)
                {
                    ConsoleHelper.WriteWithColor("There is no any groups in this teacher", ConsoleColor.Red);

                }
                foreach (var group in teacher.Groups)
                {
                    ConsoleHelper.WriteWithColor($"Id: {group.Id}  Fullname: {group.Name}", ConsoleColor.Cyan);
                }
                Console.WriteLine();

            }
        }
        public void Create()
        {
            ConsoleHelper.WriteWithColor("Enter Teacher Name", ConsoleColor.Cyan);
            string name = Console.ReadLine();

            ConsoleHelper.WriteWithColor("Enter Teacher SurName", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
            
        BirthDateDescription: ConsoleHelper.WriteWithColor("--Enter BirthDate--", ConsoleColor.DarkCyan);
            DateTime birthDate;
           bool  isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Birthdate is not correct format!", ConsoleColor.Red);
                Thread.Sleep(1000);
                goto BirthDateDescription;
            }
            ConsoleHelper.WriteWithColor("Enter Teacher speciality", ConsoleColor.Cyan);
            string speciality = Console.ReadLine();
            var teacher = new Teacher
            {
                Name = name,
                SurName = surname,
                BirthDate = birthDate,
                Speciality = speciality,
                CreatedAt = DateTime.Now,
            };
            _teacherRepository.Add(teacher);
            string teacherBirthDate =teacher.BirthDate.ToString("dddd MMMM yyyy");
            ConsoleHelper.WriteWithColor($"Name :{teacher.Name} , Surname:{teacher.SurName},Speciality : {teacher.Speciality},birthdate :{teacherBirthDate},", ConsoleColor.Green);
        }
        public void Update()
        {
            GetAll();
        EnterUpdateDesc: ConsoleHelper.WriteWithColor("Enter Id for Update", ConsoleColor.Cyan);
            int id;
            bool isSuceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSuceeded)
            {
                ConsoleHelper.WriteWithColor("Input is not true format", ConsoleColor.Red);
                goto EnterUpdateDesc;

            }
            var teacher = _teacherRepository.Get(id);
            if(teacher is null )
            {
                ConsoleHelper.WriteWithColor("There is no any teacher in this id", ConsoleColor.Red);
                goto EnterUpdateDesc;

            }
            ConsoleHelper.WriteWithColor("Enter Name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter SurName", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
        BirthDateDescription: ConsoleHelper.WriteWithColor("--Enter BirthDate--", ConsoleColor.DarkCyan);
            DateTime birthDate;
            bool isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Birthdate is not correct format!", ConsoleColor.Red);
                Thread.Sleep(1000);
                goto BirthDateDescription;
            }
            ConsoleHelper.WriteWithColor("Enter Speciality", ConsoleColor.Cyan);
            string speciality = Console.ReadLine();

            teacher.Name = name;
            teacher.SurName = surname;
            teacher.BirthDate = birthDate;
            teacher.Speciality = speciality;
            _teacherRepository.Update(teacher);
            ConsoleHelper.WriteWithColor($"{teacher.Name}{teacher.SurName} is succesfully Updated", ConsoleColor.Green);




        }
        public void Delete()
        {
            List: GetAll();
            if (_teacherRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("There is no teacher", ConsoleColor.Red);
                Create();
            }
            else
            {

            ConsoleHelper.WriteWithColor("Enter Teacher Id", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Id is not correct format", ConsoleColor.Red);
                goto List;
            }
            var teacher = _teacherRepository.Get(id);
                if (teacher is null) 
                {
                    ConsoleHelper.WriteWithColor("There is no any teacher in this id", ConsoleColor.Red);

                }
                _teacherRepository.Delete(teacher);
                ConsoleHelper.WriteWithColor($"{teacher.Name} {teacher.SurName}is succesfully deleted", ConsoleColor.Green);

            }

        }
    }
}
