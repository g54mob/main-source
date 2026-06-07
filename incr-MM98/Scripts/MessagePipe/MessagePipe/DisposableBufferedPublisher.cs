using System;

namespace MessagePipe
{
	internal class DisposableBufferedPublisher<TMessage> : IDisposableBufferedPublisher<TMessage>, IBufferedPublisher<TMessage>, IDisposable
	{
		private readonly BufferedMessageBroker<TMessage> broker;

		private readonly IDisposable disposable;

		public DisposableBufferedPublisher(BufferedMessageBroker<TMessage> broker, IDisposable disposable)
		{
			this.broker = broker;
			this.disposable = disposable;
		}

		public void Publish(TMessage message)
		{
			broker.Publish(message);
		}

		public void Dispose()
		{
			disposable.Dispose();
		}
	}
}
