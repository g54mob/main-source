using System;
using System.ComponentModel;
using System.Threading;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class Lock
	{
		public abstract IUpgradeableLockHolder ForReadingUpgradeable();

		public abstract ILockHolder ForReading();

		public abstract ILockHolder ForWriting();

		public abstract IUpgradeableLockHolder ForReadingUpgradeable(bool waitForLock);

		public abstract ILockHolder ForReading(bool waitForLock);

		public abstract ILockHolder ForWriting(bool waitForLock);

		public static Lock Create()
		{
			return new SlimReadWriteLock();
		}

		internal static Lock CreateFor(ReaderWriterLockSlim underlyingLock)
		{
			return new SlimReadWriteLock(underlyingLock);
		}
	}
}
