using StudentMS.Models;
namespace StudentMS.Repositories
{
    interface IStudentRepository : IRepository<Student>
    {
        void AddStudent(Student student);
    }
}