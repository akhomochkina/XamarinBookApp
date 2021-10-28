using SQLite;
using System.IO;
using Ecomm.Droid.Dependancies;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace Ecomm.Droid.Dependancies
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteConnection createSQLiteDB()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "bookDB.db3");
            return new SQLiteConnection(path);
        }
    }
}