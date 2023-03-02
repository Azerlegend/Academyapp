using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    internal interface IGroupRepository : IRepository<Group>
    {
        Group GetByName(string name);

    }
}
