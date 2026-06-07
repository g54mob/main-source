using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FuryStudios.FurySDK.Internal
{
	public abstract class AsyncRequest : IAsyncRequest, IEnumerator
	{
		private float timeStarted;

		public AsyncRequestState State { get; private set; }

		public bool IsWaiting => false;

		public bool IsCompleted => false;

		public Exception Error { get; private set; }

		public object Current { get; }

		public virtual bool ExecuteIfPreviousFailed => false;

		public float Timeout { get; }

		public event Action OnComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public AsyncRequest()
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public virtual AsyncRequestChain Continue(IAsyncRequest nextRequest)
		{
			return null;
		}

		public void Start()
		{
		}

		public void Abort()
		{
		}

		public void Success()
		{
		}

		public void Fail(Exception error)
		{
		}

		public void Fail(string error)
		{
		}

		public virtual void Reset()
		{
		}

		protected virtual void OnStarted()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnCompleted()
		{
		}
	}
	public abstract class AsyncRequest<R> : AsyncRequest, IAsyncRequest<R>, IAsyncRequest, IEnumerator
	{
		public R Result { get; private set; }

		public void Success(R result)
		{
		}

		public AsyncRequest ContinueWith(AsyncRequestCallback<R> callback)
		{
			return null;
		}
	}
}
