using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncMessageHandlerFilterBridge<T> : AsyncMessageHandlerFilter<T>
	{
		private readonly MessageHandlerFilter<T> filter;

		public AsyncMessageHandlerFilterBridge(MessageHandlerFilter<T> filter)
		{
			this.filter = filter;
			base.Order = filter.Order;
		}

		public override UniTask HandleAsync(T message, CancellationToken cancellationToken, Func<T, CancellationToken, UniTask> next)
		{
			filter.Handle(message, delegate(T x)
			{
				next(x, cancellationToken);
			});
			return default(UniTask);
		}
	}
}
