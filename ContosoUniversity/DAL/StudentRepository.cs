using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class StudentRepository : Repository<Student>
    {
        public List<Student> GetStudentByName(string name)
        {
            return DbSet.Where(o => o.FirstMidName.Contains(name)).ToList();
        }
    }
}