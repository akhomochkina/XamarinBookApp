using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecomm
{
    public interface SQLiteDBInterface
    {
        SQLiteConnection createSQLiteDB();
    }
}
