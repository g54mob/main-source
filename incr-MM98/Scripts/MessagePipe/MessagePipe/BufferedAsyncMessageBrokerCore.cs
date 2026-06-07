using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class BufferedAsyncMessageBrokerCore<TMessage>
	{
		private static readonly bool IsValueType = typeof(TMessage).IsValueType;

		private readonly AsyncMessageBrokerCore<TMessage> core;

		private TMessage lastMessage;

		[Preserve]
		public BufferedAsyncMessageBrokerCore(AsyncMessageBrokerCore<TMessage> core)
		{
			this.core = core;
			lastMessage = default(TMessage);
		}

		public void Publish(TMessage message, CancellationToken cancellationToken)
		{
			lastMessage = message;
			core.Publish(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, CancellationToken cancellationToken)
		{
			lastMessage = message;
			return core.PublishAsync(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			lastMessage = message;
			return core.PublishAsync(message, publishStrategy, cancellationToken);
		}

		public async UniTask<IDisposable> SubscribeAsync(IAsyncMessageHandler<TMessage> handler, CancellationToken cancellationToken)
		{
			if (IsValueType || lastMessage != null)
			{
				await handler.HandleAsync(lastMessage, cancellationToken);
			}
			return core.Subscribe(handler);
		}
	}
}
