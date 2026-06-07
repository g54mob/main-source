using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe.Internal
{
	internal class AsyncRequestHandlerWhenAll<TRequest, TResponse> : ICriticalNotifyCompletion, INotifyCompletion
	{
		internal class AwaiterNode : IPoolStackNode<AwaiterNode>
		{
			private AwaiterNode nextNode;

			private AsyncRequestHandlerWhenAll<TRequest, TResponse> parent;

			private UniTask<TResponse>.Awaiter awaiter;

			private int index = -1;

			private readonly Action continuation;

			private static PoolStack<AwaiterNode> pool;

			public ref AwaiterNode NextNode => ref nextNode;

			public AwaiterNode()
			{
				continuation = OnCompleted;
			}

			public static void RegisterUnsafeOnCompleted(AsyncRequestHandlerWhenAll<TRequest, TResponse> parent, UniTask<TResponse>.Awaiter awaiter, int index)
			{
				if (!pool.TryPop(out var result))
				{
					result = new AwaiterNode();
				}
				result.parent = parent;
				result.awaiter = awaiter;
				result.index = index;
				result.awaiter.UnsafeOnCompleted(result.continuation);
			}

			private void OnCompleted()
			{
				AsyncRequestHandlerWhenAll<TRequest, TResponse> asyncRequestHandlerWhenAll = parent;
				UniTask<TResponse>.Awaiter awaiter = this.awaiter;
				int num = index;
				parent = null;
				this.awaiter = default(UniTask<TResponse>.Awaiter);
				index = -1;
				pool.TryPush(this);
				try
				{
					asyncRequestHandlerWhenAll.result[num] = awaiter.GetResult();
				}
				catch (Exception source)
				{
					asyncRequestHandlerWhenAll.exception = ExceptionDispatchInfo.Capture(source);
					asyncRequestHandlerWhenAll.TryInvokeContinuation();
					return;
				}
				asyncRequestHandlerWhenAll.IncrementSuccessfully();
			}
		}

		private int completedCount;

		private ExceptionDispatchInfo exception;

		private Action continuation = ContinuationSentinel.AvailableContinuation;

		private readonly TResponse[] result;

		public bool IsCompleted
		{
			get
			{
				if (exception == null)
				{
					return completedCount == result.Length;
				}
				return true;
			}
		}

		public AsyncRequestHandlerWhenAll(IAsyncRequestHandlerCore<TRequest, TResponse>[] handlers, TRequest request, CancellationToken cancellationtoken)
		{
			result = new TResponse[handlers.Length];
			for (int i = 0; i < handlers.Length; i++)
			{
				try
				{
					UniTask<TResponse>.Awaiter awaiter = handlers[i].InvokeAsync(request, cancellationtoken).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						result[i] = awaiter.GetResult();
						goto IL_0076;
					}
					AwaiterNode.RegisterUnsafeOnCompleted(this, awaiter, i);
				}
				catch (Exception source)
				{
					exception = ExceptionDispatchInfo.Capture(source);
					TryInvokeContinuation();
					break;
				}
				continue;
				IL_0076:
				IncrementSuccessfully();
			}
		}

		private void IncrementSuccessfully()
		{
			if (Interlocked.Increment(ref completedCount) == result.Length)
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

		public AsyncRequestHandlerWhenAll<TRequest, TResponse> GetAwaiter()
		{
			return this;
		}

		public TResponse[] GetResult()
		{
			if (exception != null)
			{
				exception.Throw();
			}
			return result;
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
