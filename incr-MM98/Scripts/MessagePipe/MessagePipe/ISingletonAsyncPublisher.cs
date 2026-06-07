namespace MessagePipe
{
	public interface ISingletonAsyncPublisher<TMessage> : IAsyncPublisher<TMessage>
	{
	}
	public interface ISingletonAsyncPublisher<TKey, TMessage> : IAsyncPublisher<TKey, TMessage>
	{
	}
}
