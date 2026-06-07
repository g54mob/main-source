using System;

namespace SQLite
{
	internal class PreparedSqlLiteInsertCommand : IDisposable
	{
		private bool Initialized;

		private SQLiteConnection Connection;

		private string CommandText;

		private IntPtr Statement;

		private static readonly IntPtr NullStatement;

		public PreparedSqlLiteInsertCommand(SQLiteConnection conn, string commandText)
		{
		}

		public int ExecuteNonQuery(object[] source)
		{
			return 0;
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		~PreparedSqlLiteInsertCommand()
		{
		}
	}
}
