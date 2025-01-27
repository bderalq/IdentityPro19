namespace IdentityPro19.Models
{
    public class Student
    {
        public int StudentId {  get; set; }

        public string StudentName { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
