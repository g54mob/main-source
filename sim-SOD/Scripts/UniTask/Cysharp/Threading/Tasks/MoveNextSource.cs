using System;

namespace Cysharp.Threading.Tasks
{
	public abstract class MoveNextSource : IUniTaskSource<bool>, IUniTaskSource
	{
		protected UniTaskCompletionSourceCore<bool> completionSource;

		public bool GetResult(short token)
		{
			return false;
		}

		public UniTaskStatus GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		public void OnCompleted(Action<object> continuation, object state, short token)
		{
		}

		public UniTaskStatus UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		void IUniTaskSource.GetResult(short token)
		{
		}
	}
}
