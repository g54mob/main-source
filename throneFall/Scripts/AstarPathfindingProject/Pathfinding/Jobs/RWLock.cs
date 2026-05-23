using System;
using Unity.Jobs;

namespace Pathfinding.Jobs
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
				this.lock1 = lock1.inner;
				this.lock2 = lock2.inner;
				dependency = JobHandle.CombineDependencies(lock1.dependency, lock2.dependency);
			}

			public void UnlockAfter(JobHandle handle)
			{
				if (lock1 != null)
				{
					lock1.RemovePendingAsync();
					lock1.lastRead = JobHandle.CombineDependencies(lock1.lastRead, handle);
				}
				if (lock2 != null)
				{
					lock2.RemovePendingAsync();
					lock2.lastRead = JobHandle.CombineDependencies(lock2.lastRead, handle);
				}
			}
		}

		public readonly struct ReadLockAsync
		{
			internal readonly RWLock inner;

			public readonly JobHandle dependency;

			public ReadLockAsync(RWLock inner, JobHandle dependency)
			{
				this.inner = inner;
				this.dependency = dependency;
			}

			public void UnlockAfter(JobHandle handle)
			{
				if (inner != null)
				{
					inner.RemovePendingAsync();
					inner.lastRead = JobHandle.CombineDependencies(inner.lastRead, handle);
				}
			}
		}

		public readonly struct WriteLockAsync
		{
			private readonly RWLock inner;

			public readonly JobHandle dependency;

			public WriteLockAsync(RWLock inner, JobHandle dependency)
			{
				this.inner = inner;
				this.dependency = dependency;
			}

			public void UnlockAfter(JobHandle handle)
			{
				if (inner != null)
				{
					inner.RemovePendingAsync();
					inner.lastWrite = handle;
				}
			}
		}

		public readonly struct LockSync : IDisposable
		{
			private readonly RWLock inner;

			public LockSync(RWLock inner)
			{
				this.inner = inner;
			}

			public void Unlock()
			{
				if (inner != null)
				{
					inner.RemovePendingSync();
				}
			}

			void IDisposable.Dispose()
			{
				Unlock();
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
			AddPendingSync();
			lastWrite.Complete();
			lastWrite = default(JobHandle);
			return new LockSync(this);
		}

		public ReadLockAsync Read()
		{
			AddPendingAsync();
			return new ReadLockAsync(this, lastWrite);
		}

		public LockSync WriteSync()
		{
			AddPendingSync();
			lastWrite.Complete();
			lastWrite = default(JobHandle);
			lastRead.Complete();
			return new LockSync(this);
		}

		public WriteLockAsync Write()
		{
			AddPendingAsync();
			return new WriteLockAsync(this, JobHandle.CombineDependencies(lastRead, lastWrite));
		}
	}
}
