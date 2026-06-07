using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class FirstAsyncAsyncBufferedMessageHandler<TMessage> : IAsyncMessageHandler<TMessage>, IUniTaskSource<TMessage>, IUniTaskSource, IValueTaskSource, IValueTaskSource<TMessage>
	{
		private int handleCalled;

		private IDisposable subscription;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<TMessage> core;

		private static readonly Action<object> cancelCallback = Cancel;

		public static async UniTask<FirstAsyncAsyncBufferedMessageHandler<TMessage>> CreateAsync(IBufferedAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			FirstAsyncAsyncBufferedMessageHandler<TMessage> self = new FirstAsyncAsyncBufferedMessageHandler<TMessage>();
			if (cancellationToken.IsCancellationRequested)
			{
				self.core.TrySetException(new OperationCanceledException(cancellationToken));
				return self;
			}
			try
			{
				FirstAsyncAsyncBufferedMessageHandler<TMessage> firstAsyncAsyncBufferedMessageHandler = self;
				firstAsyncAsyncBufferedMessageHandler.subscription = await subscriber.SubscribeAsync(self, filters).ConfigureAwait(_: false);
			}
			catch (Exception error)
			{
				self.core.TrySetException(error);
				return self;
			}
			if (self.handleCalled != 0)
			{
				self.subscription?.Dispose();
				return self;
			}
			if (cancellationToken.CanBeCanceled)
			{
				self.cancellationToken = cancellationToken;
				self.cancellationTokenRegistration = cancellationToken.Register(cancelCallback, self, useSynchronizationContext: false);
			}
			return self;
		}

		private static void Cancel(object state)
		{
			FirstAsyncAsyncBufferedMessageHandler<TMessage> firstAsyncAsyncBufferedMessageHandler = (FirstAsyncAsyncBufferedMessageHandler<TMessage>)state;
			firstAsyncAsyncBufferedMessageHandler.subscription?.Dispose();
			firstAsyncAsyncBufferedMessageHandler.core.TrySetException(new OperationCanceledException(firstAsyncAsyncBufferedMessageHandler.cancellationToken));
		}

		public UniTask HandleAsync(TMessage message, CancellationToken cancellationToken)
		{
			if (Interlocked.Increment(ref handleCalled) == 1)
			{
				try
				{
					if (cancellationToken.IsCancellationRequested)
					{
						core.TrySetException(new OperationCanceledException(cancellationToken));
					}
					else
					{
						core.TrySetResult(message);
					}
				}
				finally
				{
					subscription?.Dispose();
					cancellationTokenRegistration.Dispose();
				}
			}
			return default(UniTask);
		}

		void IUniTaskSource.GetResult(short token)
		{
			GetResult(token);
		}

		public UniTaskStatus UnsafeGetStatus()
		{
			return core.UnsafeGetStatus();
		}

		public UniTaskStatus GetStatus(short token)
		{
			return core.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token)
		{
			core.OnCompleted(continuation, state, token);
		}

		public TMessage GetResult(short token)
		{
			return core.GetResult(token);
		}
	}
}
