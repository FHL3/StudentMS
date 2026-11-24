using StudentMS.Models;

namespace StudentMS.Services
{
    public class StudentFileService
    {
        private readonly string _filePath;

        public StudentFileService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new StudentException("File path cannot be empty");

            }
            _filePath = filePath;
        }
        public Student LoadStudent()
        {
            try
            {
                var lines = File.ReadAllLines(_filePath);

                var studentLine = lines[0];

                var parts = studentLine.Split('|');

                var subjects = new List<Subject>();


                if (parts.Length != 6)
                {
                    throw new StudentException("Invalid student record");
                }

                int id = int.Parse(parts[0]);
                if (id <= 0)
                {
                    throw new StudentException("Student ID must be a positive integer");
                }

                string name = parts[1];
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new StudentException("Student name cannot be empty");
                }

                string surname = parts[2];
                if (string.IsNullOrWhiteSpace(surname))
                {
                    throw new StudentException("Student surname cannot be empty");
                }

                int age = int.Parse(parts[3]);
                if (age <= 0)
                {
                    throw new StudentException("Student age must be a positive integer");
                }

                int grade = int.Parse(parts[4]);
                if (grade < 0 || grade > 12)
                {
                    throw new StudentException("Student grade must be between 0 and 12");
                }

                decimal avgMark = decimal.Parse(parts[5]);
                if (avgMark < 0 || avgMark > 100)
                {
                    throw new StudentException("Student average marks must be between 0 and 100");
                }


                for (int i = 1; i < lines.Length; i++)
                {
                    var subjectParts = lines[i].Split(',');

                    if (subjectParts.Length != 2)
                    {
                        throw new StudentException("Invalid subject record");
                    }
                    string _name = subjectParts[0];
                    if (string.IsNullOrWhiteSpace(_name))
                    {
                        throw new StudentException("Subject name cannot be empty");
                    }
                    decimal _marks = decimal.Parse(subjectParts[1]);
                    if (_marks < 0 || _marks > 100)
                    {
                        throw new StudentException("Subject marks must be between 0 and 100");
                    }

                    subjects.Add(new Subject(_name, _marks));
                }
                return new Student(id, name, surname, age, grade, avgMark, subjects);
            }
            catch (StudentException ex)
            {
                LogError($"StudentException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                LogError($"Exception: {ex.Message}");
                throw new StudentException("An error occurred while loading the student data.", ex);
            }
        }
        private void LogError(string message)
        {
            File.AppendAllText("logs.txt", $"[{DateTime.Now}] {message}{Environment.NewLine}");
        }

    }
}