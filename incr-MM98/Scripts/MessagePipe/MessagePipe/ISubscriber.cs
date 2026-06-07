using System;

namespace MessagePipe
{
	public interface ISubscriber<TMessage>
	{
		IDisposable Subscribe(IMessageHandler<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters);
	}
	public interface ISubscriber<TKey, TMessage>
	{
		IDisposable Subscribe(TKey key, IMessageHandler<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters);
	}
}
