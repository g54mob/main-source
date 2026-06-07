namespace MessagePipe
{
	public interface IPublisher<TMessage>
	{
		void Publish(TMessage message);
	}
	public interface IPublisher<TKey, TMessage>
	{
		void Publish(TKey key, TMessage message);
	}
}
