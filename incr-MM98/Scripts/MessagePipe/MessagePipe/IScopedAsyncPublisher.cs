namespace MessagePipe
{
	public interface IScopedAsyncPublisher<TMessage> : IAsyncPublisher<TMessage>
	{
	}
	public interface IScopedAsyncPublisher<TKey, TMessage> : IAsyncPublisher<TKey, TMessage>
	{
	}
}
