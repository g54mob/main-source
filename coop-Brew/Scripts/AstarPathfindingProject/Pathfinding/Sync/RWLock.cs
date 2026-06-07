using System;
using Unity.Jobs;

namespace Pathfinding.Sync
{
	public class RWLock
	{
		public readonly struct CombinedReadLockAsync
		{
			private readonly RWLock lock1;

			private readonly RWLock lock2;

			public readonly JobHandle dependency;

			public CombinedReadLockAsync(ReadLockAsync lock1, ReadLockAsync lock2)
			{
				this.lock1 = null;
				this.lock2 = null;
				dependency = default(JobHandle);
			}

			public void UnlockAfter(JobHandle handle)
			{
			}
		}

		public readonly struct ReadLockAsync
		{
			internal readonly RWLock inner;

			public readonly JobHandle dependency;

			public ReadLockAsync(RWLock inner, JobHandle dependency)
			{
				this.inner = null;
				this.dependency = default(JobHandle);
			}

			public void UnlockAfter(JobHandle handle)
			{
			}
		}

		public readonly struct WriteLockAsync
		{
			private readonly RWLock inner;

			public readonly JobHandle dependency;

			public WriteLockAsync(RWLock inner, JobHandle dependency)
			{
				this.inner = null;
				this.dependency = default(JobHandle);
			}

			public void UnlockAfter(JobHandle handle)
			{
			}
		}

		public readonly struct LockSync : IDisposable
		{
			private readonly RWLock inner;

			public LockSync(RWLock inner)
			{
				this.inner = null;
			}

			public void Unlock()
			{
			}

			void IDisposable.Dispose()
			{
			}
		}

		private JobHandle lastWrite;

		private JobHandle lastRead;

		private void AddPendingSync()
		{
		}

		private void RemovePendingSync()
		{
		}

		private void AddPendingAsync()
		{
		}

		private void RemovePendingAsync()
		{
		}

		public LockSync ReadSync()
		{
			return default(LockSync);
		}

		public ReadLockAsync Read()
		{
			return default(ReadLockAsync);
		}

		public LockSync WriteSync()
		{
			return default(LockSync);
		}

		public WriteLockAsync Write()
		{
			return default(WriteLockAsync);
		}
	}
}
