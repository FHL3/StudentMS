using StudentMS.Models;
namespace StudentMS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _students = new();
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public Student GetById(int id)
        {
            return _students.Where(s => s.ID == id).FirstOrDefault();
        }
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
        public IEnumerable<Student> GetPassingStudents()
        {
            return _students.Where(p => p.GetAcademic() != "Fail");
        }
        public IEnumerable<Student> GetFailingStudents()
        {
            return _students.Where(f => f.GetAcademic() == "Fail");
        }
        public IEnumerable<Student> GetGradeStudents(int grade)
        {
            return _students.Where(f => f.Grade == grade);
        }
        public IEnumerable<IGrouping<int, Student>> GetStudentsByGrade()
        {
            return _students.GroupBy(g => g.Grade);
        }
        public IQueryable<Student> Query()
        {
            return _students.AsQueryable();
        }
        public void Add(Student value)
        {
            AddStudent(value);
        }
        public void Update(Student value)
        {
            var existingStudent = GetById(value.ID);
            if (existingStudent != null)
            {
                existingStudent.Name = value.Name;
                existingStudent.Surname = value.Surname;
                existingStudent.Age = value.Age;
                existingStudent.Grade = value.Grade;
                existingStudent.subjects = value.subjects;
            }
            else
            {
                throw new StudentException($"Student with ID {value.ID} not found.", value.ID);
            }
        }

        public void Delete(Student value)
        {
            var existingStudent = GetById(value.ID);
            if (existingStudent != null)
            {
                _students.Remove(existingStudent);
            }
            else
            {
                throw new StudentException($"Student with ID {value.ID} not found.", value.ID);
            }
        }
        public void ProcessStudents(IEnumerable<Student> students, Action<Student> action)
        {
            foreach (Student student in students)
            {
                action(student);
            }
        }
    }
}
