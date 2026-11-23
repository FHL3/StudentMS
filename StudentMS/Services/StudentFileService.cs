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
        public void LoadStudents()
        {
            var lines = File.ReadAllLines(_filePath);
            var studentLine = lines[0];
            var parts = studentLine.Split('|');

            if (parts.Length != 6)
            {
                throw new StudentException("Invalid student record");
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
            string age = parts[3];
            if (string.IsNullOrWhiteSpace(age))
            {
                throw new StudentException("Student age cannot be empty");
            }
            string grade = parts[4];
            if (string.IsNullOrWhiteSpace(grade))
            {
                throw new StudentException("Student grade cannot be empty");
            }
            string avgMark = parts[5];
            if (string.IsNullOrWhiteSpace(avgMark))
            {
                throw new StudentException("Student average marks cannot be empty");
            }
        }

    }
}
