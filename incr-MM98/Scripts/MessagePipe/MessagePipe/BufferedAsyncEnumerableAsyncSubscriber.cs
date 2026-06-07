using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal class BufferedAsyncEnumerableAsyncSubscriber<TMessage> : IUniTaskAsyncEnumerable<TMessage>
	{
		private readonly IBufferedAsyncSubscriber<TMessage> subscriber;

		private readonly AsyncMessageHandlerFilter<TMessage>[] filters;

		public BufferedAsyncEnumerableAsyncSubscriber(IBufferedAsyncSubscriber<TMessage> subscriber, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			this.subscriber = subscriber;
			this.filters = filters;
		}

		public IUniTaskAsyncEnumerator<TMessage> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			SingleAssignmentDisposable singleAssignmentDisposable = DisposableBag.CreateSingleAssignment();
			AsyncMessageHandlerEnumerator<TMessage> asyncMessageHandlerEnumerator = new AsyncMessageHandlerEnumerator<TMessage>(singleAssignmentDisposable, cancellationToken);
			UniTask<IDisposable> task = subscriber.SubscribeAsync(asyncMessageHandlerEnumerator, filters);
			SetDisposableAsync(task, singleAssignmentDisposable);
			return asyncMessageHandlerEnumerator;
		}

		private async void SetDisposableAsync(UniTask<IDisposable> task, SingleAssignmentDisposable d)
		{
			d.Disposable = await task;
		}
	}
}
