using System;
using Unity.Collections;

namespace SQLite
{
	public static class SQLiteConnectionExtensions
	{
		public static byte[] Serialize(this SQLiteConnection db, string schema = null)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, byte[] buffer, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, byte[] buffer, long usedSize, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, NativeArray<byte> buffer, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, NativeArray<byte> buffer, long usedSize, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, ReadOnlySpan<byte> buffer, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}

		public static SQLiteConnection Deserialize(this SQLiteConnection db, ReadOnlySpan<byte> buffer, long usedSize, string schema = null, SQLite3.DeserializeFlags flags = SQLite3.DeserializeFlags.None)
		{
			return null;
		}
	}
}
