namespace portfolio.Models
{
    public class Projects
    {
        public int ID { get; set; }  // Primary Key
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
