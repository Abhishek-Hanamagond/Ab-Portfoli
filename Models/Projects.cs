namespace portfolio.Models
{
    public class Projects
    {
        public int ID { get; set; }  // Primary Key
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageHint { get; set; }
        public string? LiveURL { get; set; }
        public string? SourceURL { get; set; }
        public List<string>? Tags { get; set; }
    }
}
