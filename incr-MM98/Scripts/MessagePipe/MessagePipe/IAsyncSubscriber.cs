using System;

namespace MessagePipe
{
	public interface IAsyncSubscriber<TMessage>
	{
		IDisposable Subscribe(IAsyncMessageHandler<TMessage> asyncHandler, params AsyncMessageHandlerFilter<TMessage>[] filters);
	}
	public interface IAsyncSubscriber<TKey, TMessage>
	{
		IDisposable Subscribe(TKey key, IAsyncMessageHandler<TMessage> asyncHandler, params AsyncMessageHandlerFilter<TMessage>[] filters);
	}
}
