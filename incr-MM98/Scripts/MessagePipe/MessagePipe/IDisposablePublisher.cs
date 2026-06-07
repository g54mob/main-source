using System;

namespace MessagePipe
{
	public interface IDisposablePublisher<TMessage> : IPublisher<TMessage>, IDisposable
	{
	}
}
