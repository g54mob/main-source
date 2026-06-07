using System;
using System.Threading;
using Unity.Burst.Intrinsics;

namespace Pathfinding.Jobs
{
	public struct SpinLock
	{
		private volatile int locked;

		public void Lock()
		{
			while (Interlocked.CompareExchange(ref locked, 1, 0) != 0)
			{
				Common.Pause();
			}
			Thread.MemoryBarrier();
		}

		public void Unlock()
		{
			Thread.MemoryBarrier();
			if (Interlocked.Exchange(ref locked, 0) == 0)
			{
				throw new InvalidOperationException("Trying to unlock a lock which is not locked");
			}
		}
	}
}
