namespace MessagePipe
{
	public interface IScopedSubscriber<TMessage> : ISubscriber<TMessage>
	{
	}
	public interface IScopedSubscriber<TKey, TMessage> : ISubscriber<TKey, TMessage>
	{
	}
}
