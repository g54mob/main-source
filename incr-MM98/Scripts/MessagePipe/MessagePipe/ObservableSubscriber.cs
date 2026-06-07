using System;

namespace MessagePipe
{
	internal sealed class ObservableSubscriber<TKey, TMessage> : IObservable<TMessage>
	{
		private readonly TKey key;

		private readonly ISubscriber<TKey, TMessage> subscriber;

		private readonly MessageHandlerFilter<TMessage>[] filters;

		public ObservableSubscriber(TKey key, ISubscriber<TKey, TMessage> subscriber, MessageHandlerFilter<TMessage>[] filters)
		{
			this.key = key;
			this.subscriber = subscriber;
			this.filters = filters;
		}

		public IDisposable Subscribe(IObserver<TMessage> observer)
		{
			return subscriber.Subscribe(key, new ObserverMessageHandler<TMessage>(observer), filters);
		}
	}
	internal sealed class ObservableSubscriber<TMessage> : IObservable<TMessage>
	{
		private readonly ISubscriber<TMessage> subscriber;

		private readonly MessageHandlerFilter<TMessage>[] filters;

		public ObservableSubscriber(ISubscriber<TMessage> subscriber, MessageHandlerFilter<TMessage>[] filters)
		{
			this.subscriber = subscriber;
			this.filters = filters;
		}

		public IDisposable Subscribe(IObserver<TMessage> observer)
		{
			return subscriber.Subscribe(new ObserverMessageHandler<TMessage>(observer), filters);
		}
	}
}
