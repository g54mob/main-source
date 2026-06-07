using System;

namespace SQLite
{
	public class SQLiteException : Exception
	{
		public SQLite3.Result Result { get; private set; }

		protected SQLiteException(SQLite3.Result r, string message)
		{
		}

		public static SQLiteException New(SQLite3.Result r, string message)
		{
			return null;
		}
	}
}
