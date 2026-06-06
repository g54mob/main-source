using System;

namespace SQLite
{
	public static class ISQLiteConnectionExtensions
	{
		public static int Insert<T>(this ISQLiteConnection connection, ref T obj)
		{
			return 0;
		}

		public static int Insert<T>(this ISQLiteConnection connection, ref T obj, Type objType)
		{
			return 0;
		}

		public static int Insert<T>(this ISQLiteConnection connection, ref T obj, string extra)
		{
			return 0;
		}

		public static int Insert<T>(this ISQLiteConnection connection, ref T obj, string extra, Type objType)
		{
			return 0;
		}
	}
}
