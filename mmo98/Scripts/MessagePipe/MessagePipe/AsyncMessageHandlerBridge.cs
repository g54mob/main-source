using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncMessageHandlerBridge<T> : IAsyncMessageHandler<T>
	{
		private readonly IMessageHandler<T> handler;

		public AsyncMessageHandlerBridge(IMessageHandler<T> handler)
		{
			this.handler = handler;
		}

		public UniTask HandleAsync(T message, CancellationToken cancellationToken)
		{
			handler.Handle(message);
			return default(UniTask);
		}
	}
}
