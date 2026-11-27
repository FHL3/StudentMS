namespace StudentMS.Models
{
    public class Student(int id, string name, string surname, int age, int grade, List<Subject> subjects)
    {

        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public int Age { get; set; } = age;
        public int Grade { get; set; } = grade;
        public List<Subject> Subjects { get; set; } = subjects;
        public decimal AvgMark => CalcAverage();

        public decimal CalcAverage()
        {
            if (subjects == null || subjects.Count == 0)

                return 0;

            decimal totalMarks = 0;

            int noSubjects = subjects.Count;

            foreach (var subject in subjects)
            {
                totalMarks += subject.marks;
            }

            decimal avg = totalMarks / noSubjects;

            return avg;
        }

        public string GetAcademic()
        {
            decimal Markresults = CalcAverage();

            return Markresults switch
            {
                >= 90 => "Distinction",
                >= 75 => "Merit",
                >= 50 => "Pass",
                _ => "Fail"
            };
        }

    }
}
