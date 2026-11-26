using StudentMS.Models;
namespace StudentMS.Repositories
{
    interface IStudentRepository : IRepository<Student>
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetPassingStudents();
        IEnumerable<Student> GetFailingStudents();
        IEnumerable<Student> GetGradeStudents(int grade);
        IEnumerable<IGrouping<int, Student>> GetStudentsByGrade();
    }
}