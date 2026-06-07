using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncMessageHandlerFilterRunner<T>
	{
		private readonly AsyncMessageHandlerFilter<T> filter;

		private readonly Func<T, CancellationToken, UniTask> next;

		public AsyncMessageHandlerFilterRunner(AsyncMessageHandlerFilter<T> filter, Func<T, CancellationToken, UniTask> next)
		{
			this.filter = filter;
			this.next = next;
		}

		public Func<T, CancellationToken, UniTask> GetDelegate()
		{
			return HandleAsync;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private UniTask HandleAsync(T message, CancellationToken cancellationToken)
		{
			return filter.HandleAsync(message, cancellationToken, next);
		}
	}
}
