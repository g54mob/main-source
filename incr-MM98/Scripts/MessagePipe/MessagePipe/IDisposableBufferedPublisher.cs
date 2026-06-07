using System;

namespace MessagePipe
{
	public interface IDisposableBufferedPublisher<TMessage> : IBufferedPublisher<TMessage>, IDisposable
	{
	}
}
