using System;

namespace MessagePipe
{
	internal sealed class ObservableBufferedSubscriber<TMessage> : IObservable<TMessage>
	{
		private readonly IBufferedSubscriber<TMessage> subscriber;

		private readonly MessageHandlerFilter<TMessage>[] filters;

		public ObservableBufferedSubscriber(IBufferedSubscriber<TMessage> subscriber, MessageHandlerFilter<TMessage>[] filters)
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
