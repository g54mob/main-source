using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cysharp.Threading.Tasks
{
	public static class AddressablesAsyncExtensions
	{
		public struct AsyncOperationHandleAwaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			private AsyncOperationHandle handle;

			private Action<AsyncOperationHandle> continuationAction;

			public bool IsCompleted => false;

			public AsyncOperationHandleAwaiter(AsyncOperationHandle handle)
			{
				this.handle = default(AsyncOperationHandle);
				continuationAction = null;
			}

			public void GetResult()
			{
			}

			public void OnCompleted(Action continuation)
			{
			}

			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		private sealed class AsyncOperationHandleConfiguredSource : IUniTaskSource, IPlayerLoopItem, ITaskPoolNode<AsyncOperationHandleConfiguredSource>
		{
			private static TaskPool<AsyncOperationHandleConfiguredSource> pool;

			private AsyncOperationHandleConfiguredSource nextNode;

			private readonly Action<AsyncOperationHandle> continuationAction;

			private AsyncOperationHandle handle;

			private CancellationToken cancellationToken;

			private IProgress<float> progress;

			private bool completed;

			private UniTaskCompletionSourceCore<AsyncUnit> core;

			public ref AsyncOperationHandleConfiguredSource NextNode
			{
				get
				{
					throw null;
				}
			}

			static AsyncOperationHandleConfiguredSource()
			{
			}

			private AsyncOperationHandleConfiguredSource()
			{
			}

			public static IUniTaskSource Create(AsyncOperationHandle handle, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, out short token)
			{
				token = default(short);
				return null;
			}

			private void Continuation(AsyncOperationHandle _)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			private bool TryReturn()
			{
				return false;
			}
		}

		private sealed class AsyncOperationHandleConfiguredSource<T> : IUniTaskSource<T>, IUniTaskSource, IPlayerLoopItem, ITaskPoolNode<AsyncOperationHandleConfiguredSource<T>>
		{
			private static TaskPool<AsyncOperationHandleConfiguredSource<T>> pool;

			private AsyncOperationHandleConfiguredSource<T> nextNode;

			private readonly Action<AsyncOperationHandle<T>> continuationAction;

			private AsyncOperationHandle<T> handle;

			private CancellationToken cancellationToken;

			private IProgress<float> progress;

			private bool completed;

			private UniTaskCompletionSourceCore<T> core;

			public ref AsyncOperationHandleConfiguredSource<T> NextNode
			{
				get
				{
					throw null;
				}
			}

			static AsyncOperationHandleConfiguredSource()
			{
			}

			private AsyncOperationHandleConfiguredSource()
			{
			}

			public static IUniTaskSource<T> Create(AsyncOperationHandle<T> handle, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, out short token)
			{
				token = default(short);
				return null;
			}

			private void Continuation(AsyncOperationHandle<T> argHandle)
			{
			}

			public T GetResult(short token)
			{
				return default(T);
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			private bool TryReturn()
			{
				return false;
			}
		}

		public static UniTask.Awaiter GetAwaiter(this AsyncOperationHandle handle)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask WithCancellation(this AsyncOperationHandle handle, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static UniTask ToUniTask(this AsyncOperationHandle handle, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask<T>.Awaiter GetAwaiter<T>(this AsyncOperationHandle<T> handle)
		{
			return default(UniTask<T>.Awaiter);
		}

		public static UniTask<T> WithCancellation<T>(this AsyncOperationHandle<T> handle, CancellationToken cancellationToken)
		{
			return default(UniTask<T>);
		}

		public static UniTask<T> ToUniTask<T>(this AsyncOperationHandle<T> handle, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<T>);
		}
	}
}
