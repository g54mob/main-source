using System;
using System.ComponentModel;

namespace Castle.Core.Internal
{
	[Obsolete("Consider using `System.Threading.ReaderWriterLockSlim` instead of `Lock` and related types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ILockHolder : IDisposable
	{
		bool LockAcquired { get; }
	}
}
