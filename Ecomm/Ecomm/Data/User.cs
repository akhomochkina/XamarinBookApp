using SQLite;
using System.Collections.ObjectModel;

namespace Ecomm
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string email { get; set; } 
        public string name { get; set; }
        [MaxLength(12)]
        public string password { get; set; }

        public User()
        {
        }
    }
}
