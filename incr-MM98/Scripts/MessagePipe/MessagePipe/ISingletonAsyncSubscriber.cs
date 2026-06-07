namespace MessagePipe
{
	public interface ISingletonAsyncSubscriber<TMessage> : IAsyncSubscriber<TMessage>
	{
	}
	public interface ISingletonAsyncSubscriber<TKey, TMessage> : IAsyncSubscriber<TKey, TMessage>
	{
	}
}
