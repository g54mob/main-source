namespace MessagePipe
{
	public interface IBufferedPublisher<TMessage>
	{
		void Publish(TMessage message);
	}
}
