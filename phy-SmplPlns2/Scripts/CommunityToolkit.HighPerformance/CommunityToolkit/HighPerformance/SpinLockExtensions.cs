using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CommunityToolkit.HighPerformance
{
	public static class SpinLockExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public readonly ref struct UnsafeLock
		{
			private unsafe readonly SpinLock* spinLock;

			private readonly bool lockTaken;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe UnsafeLock(SpinLock* spinLock)
			{
				this.spinLock = spinLock;
				lockTaken = false;
				spinLock->Enter(ref lockTaken);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe void Dispose()
			{
				if (lockTaken)
				{
					spinLock->Exit();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use SpinLockExtensions.Enter(ref SpinLock) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe static UnsafeLock Enter(SpinLock* spinLock)
		{
			return new UnsafeLock(spinLock);
		}
	}
}
