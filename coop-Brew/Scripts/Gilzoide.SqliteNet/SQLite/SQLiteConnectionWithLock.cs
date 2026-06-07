using System;

namespace SQLite
{
	public class SQLiteConnectionWithLock : SQLiteConnection
	{
		private class LockWrapper : IDisposable
		{
			private object _lockPoint;

			public LockWrapper(object lockPoint)
			{
			}

			public void Dispose()
			{
			}
		}

		private class FakeLockWrapper : IDisposable
		{
			public void Dispose()
			{
			}
		}

		private readonly object _lockPoint;

		public bool SkipLock { get; set; }

		public SQLiteConnectionWithLock(SQLiteConnectionString connectionString)
			: base(null, storeDateTimeAsTicks: false)
		{
		}

		public IDisposable Lock()
		{
			return null;
		}
	}
}
