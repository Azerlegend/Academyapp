using Core.Entities;
using Core.Extensions;
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
    public class StudentService
    {private readonly GroupServices _groupService;
        private readonly GroupRepository _groupRepository;
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _groupService= new GroupServices();
            _groupRepository= new GroupRepository();
            _studentRepository= new StudentRepository();
        }
        public void GetAll()
        { 
            var students = _studentRepository.GetAll();
            ConsoleHelper.WriteWithColor("--All Students", ConsoleColor.Cyan);
            foreach (var student in students)
            {
                ConsoleHelper.WriteWithColor($"Id : {student.Id},Full Name : {student.Name} {student.SurName},Email : {student.Email} Group :{student.Group?.Name}",ConsoleColor.Magenta);

            }
        }
        public void GetAllByGroup()
        {
            _groupService.GetAll();
        GroupDesc: ConsoleHelper.WriteWithColor("Enter group Id", ConsoleColor.Cyan);
            int groupId;
            bool isSucceded = int.TryParse(Console.ReadLine(), out groupId);
            if (!isSucceded)
            {
                ConsoleHelper.WriteWithColor("Group id is not correct format", ConsoleColor.Red);
                goto GroupDesc;
            }
            var group=_groupRepository.Get(groupId);
            if (group is null )
            {
                ConsoleHelper.WriteWithColor("There is not any group in this id",ConsoleColor.Red);
               
            }
            if (group.Students.Count==0)
            {
                ConsoleHelper.WriteWithColor("There is no student in this group", ConsoleColor.Red);

            }
            else
            {
                foreach (var student in group.Students)
                {
                    ConsoleHelper.WriteWithColor($"Id : {student.Id},Full Name : {student.Name} {student.SurName},Email : {student.Email} ", ConsoleColor.Magenta);

                }
            }
            
        }
        public void Create(Admin admin)
        {
            if(_groupRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("You must create group first", ConsoleColor.Red);
                return;

            }
            ConsoleHelper.WriteWithColor("Enter Student Name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Student SurName", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
        EmailDesc: ConsoleHelper.WriteWithColor("Enter Student Email", ConsoleColor.Cyan);
            string email = Console.ReadLine();
            if (email.IsEmail())
            {
                ConsoleHelper.WriteWithColor("Email is not correct format", ConsoleColor.Red);
                goto EmailDesc;
            }
            if (_studentRepository.isDuplicateEmail(email))
            {
                ConsoleHelper.WriteWithColor("This email is already used",ConsoleColor.Red);
            }
        BirthDateDescription: ConsoleHelper.WriteWithColor("--Enter BirthDate--", ConsoleColor.DarkCyan);
            DateTime birthDate;
            bool isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Birthdate is not correct format!", ConsoleColor.Red);
                Thread.Sleep(1000);
                goto BirthDateDescription;
            }
        GroupDesc: _groupService.GetAll();
            ConsoleHelper.WriteWithColor("Ente group id", ConsoleColor.Cyan);
            int groupId;
            bool isSucceded = int.TryParse(Console.ReadLine(), out groupId);
            if (!isSucceded)
            {
                ConsoleHelper.WriteWithColor("Group id is not correct format", ConsoleColor.Red);
                goto GroupDesc;
            }
            var group = _groupRepository.Get(groupId);
            if (group is null)
            {
                ConsoleHelper.WriteWithColor("Group is not exist in this id", ConsoleColor.Red);
                goto GroupDesc;
            }
            if (group.MaxSize <= group.Students.Count)
            {
                ConsoleHelper.WriteWithColor("This group is full",ConsoleColor.Red);
                goto GroupDesc;
            }
            var student = new Student
            {
                Name = name,
                SurName = surname,
                Email= email,
                BirthDate = birthDate,
                Group = group,
                GroupId = group.Id,
                CreatedBy= admin.Username

            };
            group.Students.Add(student);
            _studentRepository.Add(student);
            ConsoleHelper.WriteWithColor($"{student.Name} {student.SurName}is successfully added", ConsoleColor.Green);
        }
        public void Update()
        {
            GetAll();
        StudentDesc: ConsoleHelper.WriteWithColor("Enter student id :", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed id is not correct format", ConsoleColor.Red);
                goto StudentDesc;
            }
            var student = _studentRepository.Get(id);
            if (student is null)
            {
                ConsoleHelper.WriteWithColor("There is no any student in this id", ConsoleColor.Red);
                goto StudentDesc;

            }
            ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new surname", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
        BirthDateDescription: ConsoleHelper.WriteWithColor("--Enter BirthDate--", ConsoleColor.DarkCyan);
            DateTime birthDate;
            isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Birthdate is not correct format!", ConsoleColor.Red);
                Thread.Sleep(1000);
                goto BirthDateDescription;
            }

           Groupdesc: _groupService.GetAll();
            ConsoleHelper.WriteWithColor("Enter new group id", ConsoleColor.Cyan);
            int groupid;
            isSucceeded = int.TryParse(Console.ReadLine(), out groupid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Group id  is not correct format", ConsoleColor.Red);
                goto Groupdesc;

            }
var group = _groupRepository.Get(groupid);
            if (group is null)
            {
                ConsoleHelper.WriteWithColor("There is no any group in this id", ConsoleColor.Red);
                goto Groupdesc;

            }
            student.Name = name;
            student.BirthDate = birthDate;
            student.SurName = surname;
            student.Group = group;
            student.GroupId= groupid;
            student.ModifiedBy= group.ModifiedBy;


            _studentRepository.Update(student);
            Console.WriteLine($"{student.Name} {student.SurName},Group : {student.Group.Name}succesfully updated");
        }
        public void Delete()
        {
            GetAll();
            EnterIdDesc: ConsoleHelper.WriteWithColor("Enter id", ConsoleColor.Cyan);

            int id;
            bool isSucceeded =int.TryParse(Console.ReadLine(), out id);
            if (isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Id is not correct format", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var student = _studentRepository.Get(id);
            if (student is null)
            {
                ConsoleHelper.WriteWithColor("There is not student in this id", ConsoleColor.Red);

            }
            _studentRepository.Delete(student);
            ConsoleHelper.WriteWithColor($"{student.Name},{student.SurName} is succesully added", ConsoleColor.Green);
        }
    }
}
