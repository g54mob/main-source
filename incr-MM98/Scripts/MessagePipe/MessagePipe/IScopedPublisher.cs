namespace MessagePipe
{
	public interface IScopedPublisher<TMessage> : IPublisher<TMessage>
	{
	}
	public interface IScopedPublisher<TKey, TMessage> : IPublisher<TKey, TMessage>
	{
	}
}
