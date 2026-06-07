using System;

namespace MessagePipe
{
	public interface IBufferedSubscriber<TMessage>
	{
		IDisposable Subscribe(IMessageHandler<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters);
	}
}
