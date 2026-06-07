using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe.Internal
{
	internal class AsyncHandlerWhenAll<T> : ICriticalNotifyCompletion, INotifyCompletion
	{
		internal class AwaiterNode : IPoolStackNode<AwaiterNode>
		{
			private AwaiterNode nextNode;

			private AsyncHandlerWhenAll<T> parent;

			private UniTask.Awaiter awaiter;

			private readonly Action continuation;

			private static PoolStack<AwaiterNode> pool;

			public ref AwaiterNode NextNode => ref nextNode;

			public AwaiterNode()
			{
				continuation = OnCompleted;
			}

			public static void RegisterUnsafeOnCompleted(AsyncHandlerWhenAll<T> parent, UniTask.Awaiter awaiter)
			{
				if (!pool.TryPop(out var result))
				{
					result = new AwaiterNode();
				}
				result.parent = parent;
				result.awaiter = awaiter;
				result.awaiter.UnsafeOnCompleted(result.continuation);
			}

			private void OnCompleted()
			{
				AsyncHandlerWhenAll<T> asyncHandlerWhenAll = parent;
				UniTask.Awaiter awaiter = this.awaiter;
				parent = null;
				this.awaiter = default(UniTask.Awaiter);
				pool.TryPush(this);
				try
				{
					awaiter.GetResult();
				}
				catch (Exception source)
				{
					asyncHandlerWhenAll.exception = ExceptionDispatchInfo.Capture(source);
					asyncHandlerWhenAll.TryInvokeContinuation();
					return;
				}
				asyncHandlerWhenAll.IncrementSuccessfully();
			}
		}

		private readonly int taskCount;

		private int completedCount;

		private ExceptionDispatchInfo exception;

		private Action continuation = ContinuationSentinel.AvailableContinuation;

		public bool IsCompleted
		{
			get
			{
				if (exception == null)
				{
					return completedCount == taskCount;
				}
				return true;
			}
		}

		public AsyncHandlerWhenAll(IAsyncMessageHandler<T>[] handlers, T message, CancellationToken cancellationtoken)
		{
			taskCount = handlers.Length;
			foreach (IAsyncMessageHandler<T> asyncMessageHandler in handlers)
			{
				if (asyncMessageHandler == null)
				{
					IncrementSuccessfully();
					continue;
				}
				try
				{
					UniTask.Awaiter awaiter = asyncMessageHandler.HandleAsync(message, cancellationtoken).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						awaiter.GetResult();
						goto IL_0074;
					}
					AwaiterNode.RegisterUnsafeOnCompleted(this, awaiter);
				}
				catch (Exception source)
				{
					exception = ExceptionDispatchInfo.Capture(source);
					TryInvokeContinuation();
					break;
				}
				continue;
				IL_0074:
				IncrementSuccessfully();
			}
		}

		private void IncrementSuccessfully()
		{
			if (Interlocked.Increment(ref completedCount) == taskCount)
			{
				TryInvokeContinuation();
			}
		}

		private void TryInvokeContinuation()
		{
			Action action = Interlocked.Exchange(ref continuation, ContinuationSentinel.CompletedContinuation);
			if (action != ContinuationSentinel.AvailableContinuation && action != ContinuationSentinel.CompletedContinuation)
			{
				action();
			}
		}

		public AsyncHandlerWhenAll<T> GetAwaiter()
		{
			return this;
		}

		public void GetResult()
		{
			if (exception != null)
			{
				exception.Throw();
			}
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			if (Interlocked.CompareExchange(ref this.continuation, continuation, ContinuationSentinel.AvailableContinuation) == ContinuationSentinel.CompletedContinuation)
			{
				continuation();
			}
		}
	}
}
