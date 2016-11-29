using System;
using System.IO;
using SQLite.Net.Async;
using Xamarin.Forms;
using KenoTracker1.Droid;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace KenoTracker1.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{

			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");
			var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
			return new SQLiteAsyncConnection(connectionFactory);
		}
	}
}

