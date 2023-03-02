using Core.Constants;
using Core.Entities;
using Core.Extensions;
using Core.Helpers;
using Data;
using Data.Contexts;
using Data.Repositories.Concrete;
using Presentation.Services;
using System.Globalization;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Presentation
{
    public static class  Program
    {
        private readonly static GroupServices _groupService;
        private readonly static StudentService _studentService;
        private readonly static AdminService _adminService;
        private readonly static TeacherService _teacherService;
        private readonly static GroupFieldService _groupFieldService;
        static Program()
        {
            _groupService = new GroupServices();
            _studentService = new StudentService();
            _teacherService= new TeacherService();
            _adminService = new AdminService();
            _groupFieldService = new GroupFieldService();
            DbInitializer.SeedAdmins();
        }
        public static object DateTimeStyle { get; private set; }

        static void Main()
        {Console.OutputEncoding = Encoding.UTF8;
           
            ConsoleHelper.WriteWithColor("-- Welcome --", ConsoleColor.Cyan);
            Authorize: var admin = _adminService.Authorize();
            if(admin != null )
            {
                ConsoleHelper.WriteWithColor($"-- Welcome ,{admin.Username}--", ConsoleColor.Cyan);

                while (true)
            {
        MainMenuDesc: ConsoleHelper.WriteWithColor("1-Groups", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("2-Students", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("3-Teachers", ConsoleColor.DarkYellow);

                    ConsoleHelper.WriteWithColor("0-Logout", ConsoleColor.DarkYellow);

            int number;
            bool isSucceded = int.TryParse(Console.ReadLine(), out number);
            if (!isSucceded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto MainMenuDesc;
            }
            else
            {
               switch (number)
                    {
                        case (int) MainMenuOptions.Groups:
                            while (true)
                            {

                            GroupDesc: Console.WriteLine("     ");
                                ConsoleHelper.WriteWithColor("0) Back to main menu", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("1) Create Group", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("2) Update Group", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("3) Delete Group", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("4) Get All Groups", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("5) Get Group By Id", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("6) Get Group By Name", ConsoleColor.DarkYellow);
                                Console.WriteLine("                  ");

                                ConsoleHelper.WriteWithColor("--Select Option--", ConsoleColor.Cyan);
                                bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);

                                }
                                else
                                {

                                    switch (number)
                                    {
                                        case (int)GroupOptions.CreateGroup:
                                           
                                            _groupService.Create(admin );
                                            break;
                                        case (int)GroupOptions.UpdateGroup:
                                            _groupService.Update(admin);
                                            break;
                                        case (int)GroupOptions.DeleteGroup:
                                            _groupService.Delete();
                                            break;
                                        case (int)GroupOptions.GetAllGroups:
                                            _groupService.GetAll();
                                            break;
                                        case (int)GroupOptions.GetGroupById:
                                            _groupService.GetGroupById(admin);
                                            break;
                                        case (int)GroupOptions.GetGroupByName:
                                            _groupService.GetGroupByName();
                                            break;
                                        case (int)GroupOptions.BacktoMainMenu:
                                            goto MainMenuDesc;
                                            break;
                                        default:
                                            ConsoleHelper.WriteWithColor("Inputed number is not exist", ConsoleColor.Red);
                                            goto GroupDesc;
                                    }
                                }

                            }

                                      
                        case (int)MainMenuOptions.Students:
                            while (true)
                            {
                               
                                ConsoleHelper.WriteWithColor("1) Create Student", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("2) Update Student", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("3) Delete Student", ConsoleColor.DarkYellow);

                                ConsoleHelper.WriteWithColor("4) Get All Students", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("5) Get All Students by Group", ConsoleColor.DarkYellow);
                                ConsoleHelper.WriteWithColor("6) Go to Main Menu", ConsoleColor.DarkYellow);
                                bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);

                                }
                                else
                                {

                                    switch (number)
                                    {
                                        case (int)StudentOptions.CreateStudent:
                                            _studentService.Create(admin);

                                            break;
                                            case (int)StudentOptions.UpdateStudent:
                                            break;
                                            case (int)StudentOptions.DeleteStudent:
                                            _studentService.Delete();
                                            break;
                                            case (int)StudentOptions.GetAllStudents:
                                            _studentService.GetAll();
                                            break;
                                            case (int)StudentOptions.GetAllStudentsbyGroup:
                                            _studentService.GetAllByGroup();
                                            break;
                                            case (int)StudentOptions.BackToMainMenu:
                                            goto MainMenuDesc;



                                    }










                                }


                            }
                            case (int)MainMenuOptions.Teachers:
                                while(true)
                                {
                                   TeacherDesc: ConsoleHelper.WriteWithColor("1) Create Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2) Update Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3) Delete Teacher", ConsoleColor.DarkYellow);

                                    ConsoleHelper.WriteWithColor("4) Get All Teachers", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("0) Go to Main Menu", ConsoleColor.DarkYellow);
                                    bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                    if (!isSucceeded)
                                    {
                                        ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);

                                    }
                                    else
                                    {

                                        switch (number)
                                        {
                                            case (int)TeacherOptions.CreateTeacher:
                                                _teacherService.Create();                                                break;
                                            case (int)TeacherOptions.UpdateTeacher:
                                                _teacherService.Update();
                                                break;
                                            case (int)TeacherOptions.DeleteTeacher:
                                                _teacherService.Delete();
                                                break;
                                            case (int)TeacherOptions.GetallTeachers:
                                                _teacherService.GetAll();
                                                break;
                                            
                                            case (int)StudentOptions.BackToMainMenu:
                                                goto MainMenuDesc;



                                        }










                                    }

                                }
                            case (int)MainMenuOptions.GroupFields:
                                while(true)
                                {GroupFieldDesc:
                                    ConsoleHelper.WriteWithColor("1- Create Group Field", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2- Delete Group Field", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3- Get All Group Fields", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("0- Go to Main Menu", ConsoleColor.DarkYellow);
                                    int desc;
                                    bool isSucceeded = int.TryParse(Console.ReadLine(), out desc);
                                    if (!isSucceeded)
                                    {
                                        ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                                        goto GroupFieldDesc;
                                    }
                                    else
                                    {
                                        switch (desc)
                                        {
                                            case (int)GroupFieldOptions.AddGroupField:
                                                break;
                                                _groupFieldService.Create();
                                                break;
                                            case (int)GroupFieldOptions.RemoveGroupField:
                                                _groupFieldService.Remove();
                                                break;
                                            case (int)GroupFieldOptions.GetAllGroupField:
                                                _groupFieldService.GetAll();
                                                break;

                                            case (int)GroupFieldOptions.MainMenu:
                                                goto MainMenuDesc;

                                            case (int)GroupFieldOptions.UpdateGroupField:
                                                _groupFieldService.Update();
                                                break;
                                            default:
                                                ConsoleHelper.WriteWithColor("Inputed number is not exist!", ConsoleColor.Red);
                                                break;
                                        }
                                    }

                                }
                            case (int)MainMenuOptions.Logout:
                                goto Authorize;

                        default:
                            ConsoleHelper.WriteWithColor("Inputed number is not true",ConsoleColor.Red); 
                            goto MainMenuDesc;

                    }
            }

            }

            }
            


            






        }






    }






}
