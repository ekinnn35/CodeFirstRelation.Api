using System.Collections.Generic;

namespace CodeFirstRelation.Api.Entities
{
    public class User
    {
        public int Id { get; set; }  // Primary Key
        public string Username { get; set; } // Kullanıcı adı
        public string Email { get; set; } // E-posta adresi

        // Navigation Property - Bir kullanıcının birden çok gönderisi olabilir.
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
