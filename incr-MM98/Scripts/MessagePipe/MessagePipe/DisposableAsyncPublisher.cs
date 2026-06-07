using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class DisposableAsyncPublisher<TMessage> : IDisposableAsyncPublisher<TMessage>, IAsyncPublisher<TMessage>, IDisposable
	{
		private readonly AsyncMessageBrokerCore<TMessage> core;

		public DisposableAsyncPublisher(AsyncMessageBrokerCore<TMessage> core)
		{
			this.core = core;
		}

		public void Publish(TMessage message, CancellationToken cancellationToken)
		{
			core.Publish(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, CancellationToken cancellationToken)
		{
			return core.PublishAsync(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			return core.PublishAsync(message, publishStrategy, cancellationToken);
		}

		public void Dispose()
		{
			core.Dispose();
		}
	}
}
