using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public abstract class AsyncMessageHandlerFilter<TMessage> : IAsyncMessageHandlerFilter, IMessagePipeFilter
	{
		public int Order { get; set; }

		public abstract UniTask HandleAsync(TMessage message, CancellationToken cancellationToken, Func<TMessage, CancellationToken, UniTask> next);
	}
}
