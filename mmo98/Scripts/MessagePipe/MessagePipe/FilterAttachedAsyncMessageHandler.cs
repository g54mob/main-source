using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class FilterAttachedAsyncMessageHandler<T> : IAsyncMessageHandler<T>
	{
		private Func<T, CancellationToken, UniTask> handler;

		public FilterAttachedAsyncMessageHandler(IAsyncMessageHandler<T> body, IEnumerable<AsyncMessageHandlerFilter<T>> filters)
		{
			Func<T, CancellationToken, UniTask> next = body.HandleAsync;
			foreach (AsyncMessageHandlerFilter<T> item in filters.OrderByDescending((AsyncMessageHandlerFilter<T> x) => x.Order))
			{
				next = new AsyncMessageHandlerFilterRunner<T>(item, next).GetDelegate();
			}
			handler = next;
		}

		public UniTask HandleAsync(T message, CancellationToken cancellationToken)
		{
			return handler(message, cancellationToken);
		}
	}
}
