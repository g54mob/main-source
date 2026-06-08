using System;
using System.ComponentModel;
using System.Threading;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class SlimUpgradeableReadLockHolder : IUpgradeableLockHolder, ILockHolder, IDisposable
	{
		private readonly ReaderWriterLockSlim locker;

		private bool lockAcquired;

		private SlimWriteLockHolder writerLock;

		private bool wasLockAlreadyHeld;

		public bool LockAcquired => lockAcquired;

		public SlimUpgradeableReadLockHolder(ReaderWriterLockSlim locker, bool waitForLock, bool wasLockAlreadyHelf)
		{
			this.locker = locker;
			if (wasLockAlreadyHelf)
			{
				lockAcquired = true;
				wasLockAlreadyHeld = true;
			}
			else if (waitForLock)
			{
				locker.EnterUpgradeableReadLock();
				lockAcquired = true;
			}
			else
			{
				lockAcquired = locker.TryEnterUpgradeableReadLock(0);
			}
		}

		public void Dispose()
		{
			if (writerLock != null && writerLock.LockAcquired)
			{
				writerLock.Dispose();
				writerLock = null;
			}
			if (LockAcquired)
			{
				if (!wasLockAlreadyHeld)
				{
					locker.ExitUpgradeableReadLock();
				}
				lockAcquired = false;
			}
		}

		public ILockHolder Upgrade()
		{
			return Upgrade(waitForLock: true);
		}

		public ILockHolder Upgrade(bool waitForLock)
		{
			if (locker.IsWriteLockHeld)
			{
				return NoOpLock.Lock;
			}
			writerLock = new SlimWriteLockHolder(locker, waitForLock);
			return writerLock;
		}
	}
}
