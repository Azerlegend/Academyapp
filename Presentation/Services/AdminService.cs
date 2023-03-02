using Core.Entities;
using Core.Helpers;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;
        public AdminService()
        {
_adminRepository= new AdminRepository();
        }
        
        
        public Admin Authorize()
        {
           LoginDesc: ConsoleHelper.WriteWithColor("Please Login", ConsoleColor.Blue);
            ConsoleHelper.WriteWithColor("Enter UserName", ConsoleColor.Cyan);
            string username = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter password", ConsoleColor.Cyan);
            string password = Console.ReadLine();
            var admin = _adminRepository.GetbyUsernameAndPassword(username, password);
       if(admin is null)
            { ConsoleHelper.WriteWithColor("Username or password isn't correct", ConsoleColor.Red);

                goto LoginDesc; 
            }
       return admin;


        }
    }
}
