using System;
using SQLite;

namespace Synty.SidekickCharacters.Database
{
	public class DatabaseManager
	{
		private static string _databasePathCached;

		private readonly string _CURRENT_VERSION;

		private static SQLiteConnection _connection;

		private static int _connectionHash;

		private static string _DATABASE_PATH => null;

		public SQLiteConnection GetDbConnection(bool checkDbOnLoad = false)
		{
			return null;
		}

		public SQLiteConnection GetCurrentDbConnection()
		{
			return null;
		}

		public void CloseConnection()
		{
		}

		private void InitialiseDatabase(bool createTables = false)
		{
		}

		private bool IsDatabaseConfigured()
		{
			return false;
		}

		public Version GetDatabaseVersion()
		{
			return null;
		}
	}
}
