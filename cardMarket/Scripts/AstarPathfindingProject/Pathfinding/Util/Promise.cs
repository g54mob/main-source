using System;
using Unity.Jobs;

namespace Pathfinding.Util
{
	public struct Promise<T> : IProgress, IDisposable where T : IProgress, IDisposable
	{
		public JobHandle handle;

		private T result;

		public bool IsCompleted => handle.IsCompleted;

		public float Progress => result.Progress;

		public Promise(JobHandle handle, T result)
		{
			this.handle = handle;
			this.result = result;
		}

		public T GetValue()
		{
			return result;
		}

		public T Complete()
		{
			handle.Complete();
			return result;
		}

		public void Dispose()
		{
			Complete();
			result.Dispose();
		}
	}
}
