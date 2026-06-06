using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class FirstAsyncAsyncMessageHandler<TKey, TMessage> : IAsyncMessageHandler<TMessage>, IUniTaskSource<TMessage>, IUniTaskSource, IValueTaskSource, IValueTaskSource<TMessage>
	{
		private int handleCalled;

		private IDisposable subscription;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<TMessage> core;

		private static readonly Action<object> cancelCallback = Cancel;

		public FirstAsyncAsyncMessageHandler(IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, CancellationToken cancellationToken, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				core.TrySetException(new OperationCanceledException(cancellationToken));
				return;
			}
			try
			{
				subscription = subscriber.Subscribe(key, this, filters);
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
			FirstAsyncAsyncMessageHandler<TKey, TMessage> firstAsyncAsyncMessageHandler = (FirstAsyncAsyncMessageHandler<TKey, TMessage>)state;
			firstAsyncAsyncMessageHandler.subscription?.Dispose();
			firstAsyncAsyncMessageHandler.core.TrySetException(new OperationCanceledException(firstAsyncAsyncMessageHandler.cancellationToken));
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
	internal sealed class FirstAsyncAsyncMessageHandler<TMessage> : IAsyncMessageHandler<TMessage>, IUniTaskSource<TMessage>, IUniTaskSource, IValueTaskSource, IValueTaskSource<TMessage>
	{
		private int handleCalled;

		private IDisposable subscription;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<TMessage> core;

		private static readonly Action<object> cancelCallback = Cancel;

		public FirstAsyncAsyncMessageHandler(IAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, AsyncMessageHandlerFilter<TMessage>[] filters)
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
			FirstAsyncAsyncMessageHandler<TMessage> firstAsyncAsyncMessageHandler = (FirstAsyncAsyncMessageHandler<TMessage>)state;
			firstAsyncAsyncMessageHandler.subscription?.Dispose();
			firstAsyncAsyncMessageHandler.core.TrySetException(new OperationCanceledException(firstAsyncAsyncMessageHandler.cancellationToken));
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
