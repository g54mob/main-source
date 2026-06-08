using System;
using System.ComponentModel;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class NoOpLock : ILockHolder, IDisposable
	{
		public static readonly ILockHolder Lock = new NoOpLock();

		public bool LockAcquired => true;

		public void Dispose()
		{
		}
	}
}
