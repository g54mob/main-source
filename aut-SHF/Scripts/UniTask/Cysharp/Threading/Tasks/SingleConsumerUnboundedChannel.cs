using System;
using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	internal class SingleConsumerUnboundedChannel<T> : Channel<T>
	{
		private sealed class SingleConsumerUnboundedChannelWriter : ChannelWriter<T>
		{
			private readonly SingleConsumerUnboundedChannel<T> parent;

			public SingleConsumerUnboundedChannelWriter(SingleConsumerUnboundedChannel<T> parent)
			{
			}

			public override bool TryWrite(T item)
			{
				return false;
			}

			public override bool TryComplete(Exception error = null)
			{
				return false;
			}
		}

		private sealed class SingleConsumerUnboundedChannelReader : ChannelReader<T>, IUniTaskSource<bool>, IUniTaskSource
		{
			private sealed class ReadAllAsyncEnumerable : IUniTaskAsyncEnumerable<T>, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable
			{
				private readonly Action<object> CancellationCallback1Delegate;

				private readonly Action<object> CancellationCallback2Delegate;

				private readonly SingleConsumerUnboundedChannelReader parent;

				private CancellationToken cancellationToken1;

				private CancellationToken cancellationToken2;

				private CancellationTokenRegistration cancellationTokenRegistration1;

				private CancellationTokenRegistration cancellationTokenRegistration2;

				private T current;

				private bool cacheValue;

				private bool running;

				public T Current => default(T);

				public ReadAllAsyncEnumerable(SingleConsumerUnboundedChannelReader parent, CancellationToken cancellationToken)
				{
				}

				public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
				{
					return null;
				}

				public UniTask<bool> MoveNextAsync()
				{
					return default(UniTask<bool>);
				}

				public UniTask DisposeAsync()
				{
					return default(UniTask);
				}

				private static void CancellationCallback1(object state)
				{
				}

				private static void CancellationCallback2(object state)
				{
				}
			}

			private readonly Action<object> CancellationCallbackDelegate;

			private readonly SingleConsumerUnboundedChannel<T> parent;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationTokenRegistration;

			private UniTaskCompletionSourceCore<bool> core;

			internal bool isWaiting;

			public override UniTask Completion => default(UniTask);

			public SingleConsumerUnboundedChannelReader(SingleConsumerUnboundedChannel<T> parent)
			{
			}

			public override bool TryRead(out T item)
			{
				item = default(T);
				return false;
			}

			public override UniTask<bool> WaitToReadAsync(CancellationToken cancellationToken)
			{
				return default(UniTask<bool>);
			}

			public void SingalContinuation()
			{
			}

			public void SingalCancellation(CancellationToken cancellationToken)
			{
			}

			public void SingalCompleted(Exception error)
			{
			}

			public override IUniTaskAsyncEnumerable<T> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken))
			{
				return null;
			}

			bool IUniTaskSource<bool>.GetResult(short token)
			{
				return false;
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			UniTaskStatus IUniTaskSource.GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			UniTaskStatus IUniTaskSource.UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			private static void CancellationCallback(object state)
			{
			}
		}

		private readonly Queue<T> items;

		private readonly SingleConsumerUnboundedChannelReader readerSource;

		private UniTaskCompletionSource completedTaskSource;

		private UniTask completedTask;

		private Exception completionError;

		private bool closed;
	}
}
