using System;

namespace MessagePipe
{
	internal class DisposablePublisher<TMessage> : IDisposablePublisher<TMessage>, IPublisher<TMessage>, IDisposable
	{
		private readonly MessageBrokerCore<TMessage> core;

		public DisposablePublisher(MessageBrokerCore<TMessage> core)
		{
			this.core = core;
		}

		public void Publish(TMessage message)
		{
			core.Publish(message);
		}

		public void Dispose()
		{
			core.Dispose();
		}
	}
}
