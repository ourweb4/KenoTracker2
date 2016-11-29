using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Async;
using Xamarin.Forms;
using KenoTracker1.iOS;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace KenoTracker1.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformIOS(), new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));

            return new SQLiteAsyncConnection(connectionFactory);
        }
    }
}

