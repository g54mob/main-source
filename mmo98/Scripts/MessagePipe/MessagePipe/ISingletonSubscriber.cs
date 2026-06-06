namespace MessagePipe
{
	public interface ISingletonSubscriber<TMessage> : ISubscriber<TMessage>
	{
	}
	public interface ISingletonSubscriber<TKey, TMessage> : ISubscriber<TKey, TMessage>
	{
	}
}
