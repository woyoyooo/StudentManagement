using StudentManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Service
{
    public class InMemoryRepository : IRepository<Student>
    {
        private readonly List<Student> _Student;

        public InMemoryRepository()
        {
            _Student = new List<Student> {
                new Student
                {
                    Id=1,
                    FirstName="Nick1",
                    LastName="Carter1",
                    BirthDay=new System.DateTime(1990,1,2)
                },
                new Student
                {
                    Id=2,
                    FirstName="Nick2",
                    LastName="Carter2",
                    BirthDay=new System.DateTime(1990,4,2)
                },
                new Student
                {
                    Id=3,
                    FirstName="Nick3",
                    LastName="Carter3",
                    BirthDay=new System.DateTime(1990,8,23)
                }
            };
        }
        public IEnumerable<Student> GetAll()
        {
            return _Student;
        }

        public Student GetById(int Id)
        {
            return _Student.FirstOrDefault(x => x.Id == Id);
        }
    }
}
