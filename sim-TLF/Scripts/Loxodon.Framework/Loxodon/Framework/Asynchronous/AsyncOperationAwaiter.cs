using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Loxodon.Framework.Asynchronous
{
	public struct AsyncOperationAwaiter : IAwaiter, ICriticalNotifyCompletion, INotifyCompletion
	{
		private AsyncOperation asyncOperation;

		private Action<AsyncOperation> continuationAction;

		public bool IsCompleted => asyncOperation.isDone;

		public AsyncOperationAwaiter(AsyncOperation asyncOperation)
		{
			this.asyncOperation = asyncOperation;
			continuationAction = null;
		}

		public void GetResult()
		{
			if (!IsCompleted)
			{
				throw new Exception("The task is not finished yet");
			}
			if (continuationAction != null)
			{
				asyncOperation.completed -= continuationAction;
			}
			continuationAction = null;
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			if (continuation == null)
			{
				throw new ArgumentNullException("continuation");
			}
			if (asyncOperation.isDone)
			{
				continuation();
				return;
			}
			continuationAction = delegate
			{
				continuation();
			};
			asyncOperation.completed += continuationAction;
		}
	}
	public struct AsyncOperationAwaiter<T, TResult> : IAwaiter<TResult>, ICriticalNotifyCompletion, INotifyCompletion where T : AsyncOperation
	{
		private T asyncOperation;

		private Func<T, TResult> getter;

		private Action<AsyncOperation> continuationAction;

		public bool IsCompleted => asyncOperation.isDone;

		public AsyncOperationAwaiter(T asyncOperation, Func<T, TResult> getter)
		{
			this.asyncOperation = asyncOperation ?? throw new ArgumentNullException("asyncOperation");
			this.getter = getter ?? throw new ArgumentNullException("getter");
			continuationAction = null;
		}

		public TResult GetResult()
		{
			if (!IsCompleted)
			{
				throw new Exception("The task is not finished yet");
			}
			if (continuationAction != null)
			{
				asyncOperation.completed -= continuationAction;
				continuationAction = null;
			}
			return getter(asyncOperation);
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			if (continuation == null)
			{
				throw new ArgumentNullException("continuation");
			}
			if (asyncOperation.isDone)
			{
				continuation();
				return;
			}
			continuationAction = delegate
			{
				continuation();
			};
			asyncOperation.completed += continuationAction;
		}
	}
}
