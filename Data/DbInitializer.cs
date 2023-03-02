using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DbInitializer
    {
        static int id;
        public static void SeedAdmins()
        { 
            var admins = new List<Admin>
            {
                new Admin
                { Id = ++id,
                    Username = "admin1",
                    Password= PasswordHasher.Encrypt("12345678"),
                    CreatedBy ="System"

                },
                new Admin
                { Id = ++id,
                    Username = "admin2",
                    Password= PasswordHasher.Encrypt("fty9"),
                    CreatedBy ="System"


                }
            };
            DbContext.Admins.AddRange(admins);
        }
    }
}
