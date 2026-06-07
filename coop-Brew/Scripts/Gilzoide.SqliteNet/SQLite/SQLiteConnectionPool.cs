using System.Collections.Generic;

namespace SQLite
{
	internal class SQLiteConnectionPool
	{
		private class Entry
		{
			public SQLiteConnectionWithLock Connection { get; private set; }

			public SQLiteConnectionString ConnectionString { get; }

			public object TransactionLock { get; }

			public Entry(SQLiteConnectionString connectionString)
			{
			}

			public void Close()
			{
			}
		}

		private readonly Dictionary<string, Entry> _entries;

		private readonly object _entriesLock;

		private static readonly SQLiteConnectionPool _shared;

		public static SQLiteConnectionPool Shared => null;

		public SQLiteConnectionWithLock GetConnection(SQLiteConnectionString connectionString)
		{
			return null;
		}

		public SQLiteConnectionWithLock GetConnectionAndTransactionLock(SQLiteConnectionString connectionString, out object transactionLock)
		{
			transactionLock = null;
			return null;
		}

		public void CloseConnection(SQLiteConnectionString connectionString)
		{
		}

		public void Reset()
		{
		}
	}
}
