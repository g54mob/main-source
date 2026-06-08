using System;
using System.ComponentModel;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class NoOpUpgradeableLock : IUpgradeableLockHolder, ILockHolder, IDisposable
	{
		public static readonly IUpgradeableLockHolder Lock = new NoOpUpgradeableLock();

		public bool LockAcquired => true;

		public void Dispose()
		{
		}

		public ILockHolder Upgrade()
		{
			return NoOpLock.Lock;
		}

		public ILockHolder Upgrade(bool waitForLock)
		{
			return NoOpLock.Lock;
		}
	}
}
