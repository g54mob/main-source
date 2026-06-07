using System;
using System.Threading;

namespace BestHTTP.PlatformSupport.Threading
{
	public struct ReadLock : IDisposable
	{
		private ReaderWriterLockSlim rwLock;

		private bool locked;

		public ReadLock(ReaderWriterLockSlim rwLock)
		{
			this.rwLock = null;
			locked = false;
		}

		public void Dispose()
		{
		}
	}
}
