using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class DisposableBufferedAsyncPublisher<TMessage> : IDisposableBufferedAsyncPublisher<TMessage>, IBufferedAsyncPublisher<TMessage>, IDisposable
	{
		private readonly BufferedAsyncMessageBroker<TMessage> broker;

		private readonly IDisposable disposable;

		public DisposableBufferedAsyncPublisher(BufferedAsyncMessageBroker<TMessage> broker, IDisposable disposable)
		{
			this.broker = broker;
			this.disposable = disposable;
		}

		public void Publish(TMessage message, CancellationToken cancellationToken)
		{
			broker.Publish(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, CancellationToken cancellationToken)
		{
			return broker.PublishAsync(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			return broker.PublishAsync(message, publishStrategy, cancellationToken);
		}

		public void Dispose()
		{
			disposable.Dispose();
		}
	}
}
