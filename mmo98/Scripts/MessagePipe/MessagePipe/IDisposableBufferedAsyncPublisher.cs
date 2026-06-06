using System;

namespace MessagePipe
{
	public interface IDisposableBufferedAsyncPublisher<TMessage> : IBufferedAsyncPublisher<TMessage>, IDisposable
	{
	}
}
