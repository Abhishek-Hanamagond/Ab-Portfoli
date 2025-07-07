namespace portfolio.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string slug { get; set; }
        public string title { get; set; } = string.Empty;

        public string? summary { get; set; }

        public string? imageUrl { get; set; }

        public string? imageHint { get; set; }

        public DateTime? publishedAt { get; set; }

        public string? author
        {
            get; set;
        }

        public List<string> skill { get; set; }

        public string  content { get; set; }
    }
}
