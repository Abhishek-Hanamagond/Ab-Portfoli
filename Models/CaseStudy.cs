namespace portfolio.Models
{
    public class CaseStudy
    {
        public int Id { get; set; }
        public required string title { get; set; }
        public string? problem { get; set; }
        public string? solution { get; set; }
        public string? outcome { get; set; }
        public string? imageUrl { get; set; }
        public string? imageHint { get; set; }
        public List<string>? tags { get; set; }
    }
}
