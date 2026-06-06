using System;
using Unity.Jobs;

namespace Pathfinding.Sync
{
	public struct Promise<T> : IProgress, IDisposable where T : IProgress, IDisposable
	{
		public JobHandle handle;

		private T result;

		public bool IsCompleted => false;

		public float Progress => 0f;

		public Promise(JobHandle handle, T result)
		{
			this.handle = default(JobHandle);
			this.result = default(T);
		}

		public T GetValue()
		{
			return default(T);
		}

		public T Complete()
		{
			return default(T);
		}

		public void Dispose()
		{
		}
	}
}
