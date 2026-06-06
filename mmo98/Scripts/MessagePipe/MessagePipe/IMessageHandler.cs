namespace MessagePipe
{
	public interface IMessageHandler<TMessage>
	{
		void Handle(TMessage message);
	}
}
