namespace NewsApplication2.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public string SourceUrl { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
