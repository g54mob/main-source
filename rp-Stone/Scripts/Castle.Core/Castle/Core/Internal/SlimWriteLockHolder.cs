using System;
using System.ComponentModel;
using System.Threading;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class SlimWriteLockHolder : ILockHolder, IDisposable
	{
		private readonly ReaderWriterLockSlim locker;

		private bool lockAcquired;

		public bool LockAcquired => lockAcquired;

		public SlimWriteLockHolder(ReaderWriterLockSlim locker, bool waitForLock)
		{
			this.locker = locker;
			if (waitForLock)
			{
				locker.EnterWriteLock();
				lockAcquired = true;
			}
			else
			{
				lockAcquired = locker.TryEnterWriteLock(0);
			}
		}

		public void Dispose()
		{
			if (LockAcquired)
			{
				locker.ExitWriteLock();
				lockAcquired = false;
			}
		}
	}
}
