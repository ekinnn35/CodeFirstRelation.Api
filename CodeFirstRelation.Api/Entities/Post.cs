namespace CodeFirstRelation.Api.Entities
{
    public class Post
    {
        public int Id { get; set; }  // Primary Key
        public string Title { get; set; } // Gönderi başlığı
        public string Content { get; set; } // Gönderi içeriği
        public int UserId { get; set; }  // Foreign Key

        // Navigation Property - Bir post yalnızca bir kullanıcıya aittir.
        public User User { get; set; }
    }
}
