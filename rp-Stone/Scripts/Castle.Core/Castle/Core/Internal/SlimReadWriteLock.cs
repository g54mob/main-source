using System;
using System.ComponentModel;
using System.Threading;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class SlimReadWriteLock : Lock
	{
		private readonly ReaderWriterLockSlim locker;

		public bool IsReadLockHeld => locker.IsReadLockHeld;

		public bool IsUpgradeableReadLockHeld => locker.IsUpgradeableReadLockHeld;

		public bool IsWriteLockHeld => locker.IsWriteLockHeld;

		public SlimReadWriteLock()
		{
			locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
		}

		internal SlimReadWriteLock(ReaderWriterLockSlim underlyingLock)
		{
			locker = underlyingLock;
		}

		public override IUpgradeableLockHolder ForReadingUpgradeable()
		{
			return ForReadingUpgradeable(waitForLock: true);
		}

		public override ILockHolder ForReading()
		{
			return ForReading(waitForLock: true);
		}

		public override ILockHolder ForWriting()
		{
			return ForWriting(waitForLock: true);
		}

		public override IUpgradeableLockHolder ForReadingUpgradeable(bool waitForLock)
		{
			return new SlimUpgradeableReadLockHolder(locker, waitForLock, locker.IsUpgradeableReadLockHeld || locker.IsWriteLockHeld);
		}

		public override ILockHolder ForReading(bool waitForLock)
		{
			if (locker.IsReadLockHeld || locker.IsUpgradeableReadLockHeld || locker.IsWriteLockHeld)
			{
				return NoOpLock.Lock;
			}
			return new SlimReadLockHolder(locker, waitForLock);
		}

		public override ILockHolder ForWriting(bool waitForLock)
		{
			if (locker.IsWriteLockHeld)
			{
				return NoOpLock.Lock;
			}
			return new SlimWriteLockHolder(locker, waitForLock);
		}
	}
}
