using System.Collections;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A,B,C,D,E,F
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}