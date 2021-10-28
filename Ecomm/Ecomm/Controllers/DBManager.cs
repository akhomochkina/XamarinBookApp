using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Ecomm
{
    public class DBManager
    {
        SQLiteConnection sqlConnection;

        public DBManager()
        {
            sqlConnection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
            sqlConnection.CreateTable<User>();
            sqlConnection.CreateTable<BookFav>();
        }

        public IEnumerable<User> GetUsers()
        {
            return (from u in sqlConnection.Table<User>()
                    select u).ToList();
        }

        public IEnumerable<BookFav> GetBook()
        {
            return (from u in sqlConnection.Table<BookFav>()
                    select u).ToList();
        }

        public bool AddUser(User user)
        {
            var data = sqlConnection.Table<User>();
            var d1 = data.Where(x => x.email == user.email).FirstOrDefault();
            if (d1 == null)
            {
                sqlConnection.Insert(user);
                return true;
            }
            else
                return false;
        }

        public void AddBook(BookFav book)
        {       
            sqlConnection.Insert(book);           
        }

        public void DeleteBook(BookFav b)
        {           
           sqlConnection.Delete(b);                
        }

        public bool LoginValidate(string e, string p)
        {
            var data = sqlConnection.Table<User>();
            var d1 = data.Where(x => x.email == e && x.password == p).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
