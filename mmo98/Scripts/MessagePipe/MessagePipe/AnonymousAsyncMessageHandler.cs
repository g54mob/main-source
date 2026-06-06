using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AnonymousAsyncMessageHandler<TMessage> : IAsyncMessageHandler<TMessage>
	{
		private readonly Func<TMessage, CancellationToken, UniTask> handler;

		public AnonymousAsyncMessageHandler(Func<TMessage, CancellationToken, UniTask> handler)
		{
			this.handler = handler;
		}

		public UniTask HandleAsync(TMessage message, CancellationToken cancellationToken)
		{
			return handler(message, cancellationToken);
		}
	}
}
