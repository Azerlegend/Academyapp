using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public static class DbContext
    {
        static DbContext()
        {
           Groups = new List<Group>();
            GroupFields = new List<GroupField>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Admins = new List<Admin>();



        }
        public static List<Group> Groups{ get; set; }
        public static List<GroupField>  GroupFields{ get; set; }
        public static List<Student> Students { get; set; }
        public static List<Teacher> Teachers { get; set; }
        public static List<Admin> Admins { get; set; }

    }
}
