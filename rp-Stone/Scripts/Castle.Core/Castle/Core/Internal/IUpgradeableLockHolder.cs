using System;
using System.ComponentModel;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IUpgradeableLockHolder : ILockHolder, IDisposable
	{
		ILockHolder Upgrade();

		ILockHolder Upgrade(bool waitForLock);
	}
}
