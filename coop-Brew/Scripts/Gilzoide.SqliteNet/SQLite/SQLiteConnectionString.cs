using System;
using System.Globalization;

namespace SQLite
{
	public class SQLiteConnectionString
	{
		private const string DateTimeSqliteDefaultFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff";

		public string UniqueKey { get; }

		public string DatabasePath { get; }

		public bool StoreDateTimeAsTicks { get; }

		public bool StoreTimeSpanAsTicks { get; }

		public string DateTimeStringFormat { get; }

		public DateTimeStyles DateTimeStyle { get; }

		public object Key { get; }

		public SQLiteOpenFlags OpenFlags { get; }

		public Action<SQLiteConnection> PreKeyAction { get; }

		public Action<SQLiteConnection> PostKeyAction { get; }

		public string VfsName { get; }

		public SQLiteConnectionString(string databasePath, bool storeDateTimeAsTicks = true)
		{
		}

		public SQLiteConnectionString(string databasePath, bool storeDateTimeAsTicks, object key = null, Action<SQLiteConnection> preKeyAction = null, Action<SQLiteConnection> postKeyAction = null, string vfsName = null)
		{
		}

		public SQLiteConnectionString(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks, object key = null, Action<SQLiteConnection> preKeyAction = null, Action<SQLiteConnection> postKeyAction = null, string vfsName = null, string dateTimeStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff", bool storeTimeSpanAsTicks = true)
		{
		}
	}
}
