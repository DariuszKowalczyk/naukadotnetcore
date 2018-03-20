using Data.Dbmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
    }
}
