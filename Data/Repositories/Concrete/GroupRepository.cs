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
    public class GroupRepository : IGroupRepository
    {
        public List<Group> GetAll()
        {
            return DbContext.Groups;
        }

        static int id;
        public Group Get(int Id)
        {
            return DbContext.Groups.FirstOrDefault(g => g.Id == Id);
        }
        public void Add(Group group)
        {
            id++;
            group.Id = id;
            group.CreatedAt = DateTime.Now;
            DbContext.Groups.Add(group);
        }
        public void Update(Group group)
        {
            throw new NotImplementedException();
        }
        public void Delete(Group group)
        {
            DbContext.Groups.Remove(group);
        }

        public Group GetByName(string name)
        {
            return DbContext.Groups.FirstOrDefault(g => g.Name.ToLower() == name.ToLower());
        }


    }
}
