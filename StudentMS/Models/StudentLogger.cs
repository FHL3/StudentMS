namespace StudentMS.Models
{
    public class StudentLogger
    {
        public void LogError(Exception ex, string filePath)
        {
            using StreamWriter w = new StreamWriter(filePath, true);
            w.WriteLine($"{DateTime.Now}: {ex.Message} {ex.GetType().Name}");
        }
    }
}
