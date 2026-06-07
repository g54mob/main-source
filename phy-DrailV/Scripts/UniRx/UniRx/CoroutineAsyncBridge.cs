using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace UniRx
{
	public class CoroutineAsyncBridge : INotifyCompletion
	{
		private Action continuation;

		public bool IsCompleted { get; private set; }

		private CoroutineAsyncBridge()
		{
			IsCompleted = false;
		}

		public static CoroutineAsyncBridge Start<T>(T awaitTarget)
		{
			CoroutineAsyncBridge coroutineAsyncBridge = new CoroutineAsyncBridge();
			MainThreadDispatcher.StartCoroutine(coroutineAsyncBridge.Run(awaitTarget));
			return coroutineAsyncBridge;
		}

		private IEnumerator Run<T>(T target)
		{
			yield return target;
			IsCompleted = true;
			continuation();
		}

		public void OnCompleted(Action continuation)
		{
			this.continuation = continuation;
		}

		public void GetResult()
		{
			if (!IsCompleted)
			{
				throw new InvalidOperationException("coroutine not yet completed");
			}
		}
	}
	public class CoroutineAsyncBridge<T> : INotifyCompletion
	{
		private readonly T result;

		private Action continuation;

		public bool IsCompleted { get; private set; }

		private CoroutineAsyncBridge(T result)
		{
			IsCompleted = false;
			this.result = result;
		}

		public static CoroutineAsyncBridge<T> Start(T awaitTarget)
		{
			CoroutineAsyncBridge<T> coroutineAsyncBridge = new CoroutineAsyncBridge<T>(awaitTarget);
			MainThreadDispatcher.StartCoroutine(coroutineAsyncBridge.Run(awaitTarget));
			return coroutineAsyncBridge;
		}

		private IEnumerator Run(T target)
		{
			yield return target;
			IsCompleted = true;
			continuation();
		}

		public void OnCompleted(Action continuation)
		{
			this.continuation = continuation;
		}

		public T GetResult()
		{
			if (!IsCompleted)
			{
				throw new InvalidOperationException("coroutine not yet completed");
			}
			return result;
		}
	}
}
