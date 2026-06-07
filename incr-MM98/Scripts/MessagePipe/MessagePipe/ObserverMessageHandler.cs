using System;

namespace MessagePipe
{
	internal sealed class ObserverMessageHandler<TMessage> : IMessageHandler<TMessage>
	{
		private readonly IObserver<TMessage> observer;

		public ObserverMessageHandler(IObserver<TMessage> observer)
		{
			this.observer = observer;
		}

		public void Handle(TMessage message)
		{
			observer.OnNext(message);
		}
	}
}
