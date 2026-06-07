using System;
using System.Threading;

namespace BestHTTP.PlatformSupport.Threading
{
	public struct WriteLock : IDisposable
	{
		private ReaderWriterLockSlim rwLock;

		private bool locked;

		public WriteLock(ReaderWriterLockSlim rwLock)
		{
			this.rwLock = null;
			locked = false;
		}

		public void Dispose()
		{
		}
	}
}
