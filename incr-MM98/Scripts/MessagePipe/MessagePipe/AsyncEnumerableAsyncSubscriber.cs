using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal class AsyncEnumerableAsyncSubscriber<TMessage> : IUniTaskAsyncEnumerable<TMessage>
	{
		private readonly IAsyncSubscriber<TMessage> subscriber;

		private readonly AsyncMessageHandlerFilter<TMessage>[] filters;

		public AsyncEnumerableAsyncSubscriber(IAsyncSubscriber<TMessage> subscriber, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			this.subscriber = subscriber;
			this.filters = filters;
		}

		public IUniTaskAsyncEnumerator<TMessage> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			SingleAssignmentDisposable singleAssignmentDisposable = DisposableBag.CreateSingleAssignment();
			AsyncMessageHandlerEnumerator<TMessage> asyncMessageHandlerEnumerator = new AsyncMessageHandlerEnumerator<TMessage>(singleAssignmentDisposable, cancellationToken);
			singleAssignmentDisposable.Disposable = subscriber.Subscribe(asyncMessageHandlerEnumerator, filters);
			return asyncMessageHandlerEnumerator;
		}
	}
	internal class AsyncEnumerableAsyncSubscriber<TKey, TMessage> : IUniTaskAsyncEnumerable<TMessage>
	{
		private readonly TKey key;

		private readonly IAsyncSubscriber<TKey, TMessage> subscriber;

		private readonly AsyncMessageHandlerFilter<TMessage>[] filters;

		public AsyncEnumerableAsyncSubscriber(TKey key, IAsyncSubscriber<TKey, TMessage> subscriber, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			this.key = key;
			this.subscriber = subscriber;
			this.filters = filters;
		}

		public IUniTaskAsyncEnumerator<TMessage> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			SingleAssignmentDisposable singleAssignmentDisposable = DisposableBag.CreateSingleAssignment();
			AsyncMessageHandlerEnumerator<TMessage> asyncMessageHandlerEnumerator = new AsyncMessageHandlerEnumerator<TMessage>(singleAssignmentDisposable, cancellationToken);
			singleAssignmentDisposable.Disposable = subscriber.Subscribe(key, asyncMessageHandlerEnumerator, filters);
			return asyncMessageHandlerEnumerator;
		}
	}
}
