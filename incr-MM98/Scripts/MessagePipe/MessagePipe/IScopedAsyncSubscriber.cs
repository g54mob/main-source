namespace MessagePipe
{
	public interface IScopedAsyncSubscriber<TMessage> : IAsyncSubscriber<TMessage>
	{
	}
	public interface IScopedAsyncSubscriber<TKey, TMessage> : IAsyncSubscriber<TKey, TMessage>
	{
	}
}
