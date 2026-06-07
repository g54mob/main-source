using System;

namespace MessagePipe
{
	public interface IDisposableAsyncPublisher<TMessage> : IAsyncPublisher<TMessage>, IDisposable
	{
	}
}
