using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Service
{
    public interface IRepository<T> where T:class
    {
        public IEnumerable<T> GetAll();

        public T GetById(int Id);
    }
}
