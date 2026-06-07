using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncPredicateFilter<T> : AsyncMessageHandlerFilter<T>
	{
		private readonly Func<T, bool> predicate;

		public AsyncPredicateFilter(Func<T, bool> predicate)
		{
			this.predicate = predicate;
			base.Order = int.MinValue;
		}

		public override UniTask HandleAsync(T message, CancellationToken cancellationToken, Func<T, CancellationToken, UniTask> next)
		{
			if (predicate(message))
			{
				return next(message, cancellationToken);
			}
			return default(UniTask);
		}
	}
}
