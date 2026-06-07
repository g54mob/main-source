using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class FirstAsyncBufferedMessageHandler<TMessage> : IMessageHandler<TMessage>, IUniTaskSource<TMessage>, IUniTaskSource, IValueTaskSource, IValueTaskSource<TMessage>
	{
		private int handleCalled;

		private IDisposable subscription;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<TMessage> core;

		private static readonly Action<object> cancelCallback = Cancel;

		public FirstAsyncBufferedMessageHandler(IBufferedSubscriber<TMessage> subscriber, CancellationToken cancellationToken, MessageHandlerFilter<TMessage>[] filters)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				core.TrySetException(new OperationCanceledException(cancellationToken));
				return;
			}
			try
			{
				subscription = subscriber.Subscribe(this, filters);
			}
			catch (Exception error)
			{
				core.TrySetException(error);
				return;
			}
			if (handleCalled != 0)
			{
				subscription?.Dispose();
			}
			else if (cancellationToken.CanBeCanceled)
			{
				this.cancellationToken = cancellationToken;
				cancellationTokenRegistration = cancellationToken.Register(cancelCallback, this, useSynchronizationContext: false);
			}
		}

		private static void Cancel(object state)
		{
			FirstAsyncBufferedMessageHandler<TMessage> firstAsyncBufferedMessageHandler = (FirstAsyncBufferedMessageHandler<TMessage>)state;
			firstAsyncBufferedMessageHandler.subscription?.Dispose();
			firstAsyncBufferedMessageHandler.core.TrySetException(new OperationCanceledException(firstAsyncBufferedMessageHandler.cancellationToken));
		}

		public void Handle(TMessage message)
		{
			if (Interlocked.Increment(ref handleCalled) == 1)
			{
				try
				{
					core.TrySetResult(message);
				}
				finally
				{
					subscription?.Dispose();
					cancellationTokenRegistration.Dispose();
				}
			}
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
