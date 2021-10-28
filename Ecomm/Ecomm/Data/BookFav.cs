using SQLite;

namespace Ecomm
{
    public class BookFav
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string isbn13 { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string image { get; set; }

        public BookFav()
        {
        }
    }
}
