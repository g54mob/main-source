using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using UnityEngine;

namespace Cysharp.Threading.Tasks
{
	public static class AsyncInstantiateOperationExtensions
	{
		private sealed class AsyncInstantiateOperationConfiguredSource : IUniTaskSource<UnityEngine.Object[]>, IUniTaskSource, IValueTaskSource, IValueTaskSource<UnityEngine.Object[]>, IPlayerLoopItem, ITaskPoolNode<AsyncInstantiateOperationConfiguredSource>
		{
			private static TaskPool<AsyncInstantiateOperationConfiguredSource> pool;

			private AsyncInstantiateOperationConfiguredSource nextNode;

			private AsyncInstantiateOperation asyncOperation;

			private IProgress<float> progress;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationTokenRegistration;

			private bool cancelImmediately;

			private bool completed;

			private UniTaskCompletionSourceCore<UnityEngine.Object[]> core;

			private Action<AsyncOperation> continuationAction;

			public ref AsyncInstantiateOperationConfiguredSource NextNode
			{
				get
				{
					throw null;
				}
			}

			static AsyncInstantiateOperationConfiguredSource()
			{
			}

			private AsyncInstantiateOperationConfiguredSource()
			{
			}

			public static IUniTaskSource<UnityEngine.Object[]> Create(AsyncInstantiateOperation asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
			{
				token = default(short);
				return null;
			}

			public UnityEngine.Object[] GetResult(short token)
			{
				return null;
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

			private void Continuation(AsyncOperation _)
			{
			}
		}

		private sealed class AsyncInstantiateOperationConfiguredSource<T> : IUniTaskSource<T[]>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T[]>, IPlayerLoopItem, ITaskPoolNode<AsyncInstantiateOperationConfiguredSource<T>> where T : UnityEngine.Object
		{
			private static TaskPool<AsyncInstantiateOperationConfiguredSource<T>> pool;

			private AsyncInstantiateOperationConfiguredSource<T> nextNode;

			private AsyncInstantiateOperation<T> asyncOperation;

			private IProgress<float> progress;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationTokenRegistration;

			private bool cancelImmediately;

			private bool completed;

			private UniTaskCompletionSourceCore<T[]> core;

			private Action<AsyncOperation> continuationAction;

			public ref AsyncInstantiateOperationConfiguredSource<T> NextNode
			{
				get
				{
					throw null;
				}
			}

			static AsyncInstantiateOperationConfiguredSource()
			{
			}

			private AsyncInstantiateOperationConfiguredSource()
			{
			}

			public static IUniTaskSource<T[]> Create(AsyncInstantiateOperation<T> asyncOperation, PlayerLoopTiming timing, IProgress<float> progress, CancellationToken cancellationToken, bool cancelImmediately, out short token)
			{
				token = default(short);
				return null;
			}

			public T[] GetResult(short token)
			{
				return null;
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

			private void Continuation(AsyncOperation _)
			{
			}
		}

		public static UniTask<UnityEngine.Object[]> WithCancellation<T>(this AsyncInstantiateOperation asyncOperation, CancellationToken cancellationToken)
		{
			return default(UniTask<UnityEngine.Object[]>);
		}

		public static UniTask<UnityEngine.Object[]> WithCancellation<T>(this AsyncInstantiateOperation asyncOperation, CancellationToken cancellationToken, bool cancelImmediately)
		{
			return default(UniTask<UnityEngine.Object[]>);
		}

		public static UniTask<UnityEngine.Object[]> ToUniTask(this AsyncInstantiateOperation asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false)
		{
			return default(UniTask<UnityEngine.Object[]>);
		}

		public static UniTask<T[]> WithCancellation<T>(this AsyncInstantiateOperation<T> asyncOperation, CancellationToken cancellationToken) where T : UnityEngine.Object
		{
			return default(UniTask<T[]>);
		}

		public static UniTask<T[]> WithCancellation<T>(this AsyncInstantiateOperation<T> asyncOperation, CancellationToken cancellationToken, bool cancelImmediately) where T : UnityEngine.Object
		{
			return default(UniTask<T[]>);
		}

		public static UniTask<T[]> ToUniTask<T>(this AsyncInstantiateOperation<T> asyncOperation, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken), bool cancelImmediately = false) where T : UnityEngine.Object
		{
			return default(UniTask<T[]>);
		}
	}
}
