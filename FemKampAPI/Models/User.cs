namespace FemKampAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Couple { get; set; }
        public int? ResourceId { get; set; }
        public string? CreateDate { get; set; }
    }
}
