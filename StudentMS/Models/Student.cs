namespace StudentMS.Models
{
    public class Student
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public List<Subject> subjects { get; set; }
        //public decimal AvgMark { get;}

        public Student(int id, string name, string surname, int age, int grade, List<Subject> subjects)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Age = age;
            Grade = grade;
            this.subjects = subjects;
            //AvgMark = avgMark;
        }
    }
}
