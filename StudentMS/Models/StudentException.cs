namespace StudentMS.Models
{
    public class StudentException : Exception
    {
        public int stdId { get; }
        public StudentException()
        {
            
        }
        public StudentException(string message) : base(message) 
        {
            
        }
        public StudentException(string message, Exception innerException) : base(message, innerException) 
        {
            
        }
        public StudentException(string message, int studId) : base(message)
        {
            stdId = studId;
        }
    }
}
