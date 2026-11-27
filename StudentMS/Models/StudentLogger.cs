namespace StudentMS.Models
{
    public class StudentLogger
    {
        public async Task LogErrorAsync(Exception ex, string filePath)
        {
            using StreamWriter w = new StreamWriter(filePath, true);
            await w.WriteLineAsync($"{DateTime.Now}: {ex.Message} {ex.GetType().Name}");
        }
    }
}
