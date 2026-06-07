namespace MessagePipe
{
	public interface ISingletonPublisher<TMessage> : IPublisher<TMessage>
	{
	}
	public interface ISingletonPublisher<TKey, TMessage> : IPublisher<TKey, TMessage>
	{
	}
}
