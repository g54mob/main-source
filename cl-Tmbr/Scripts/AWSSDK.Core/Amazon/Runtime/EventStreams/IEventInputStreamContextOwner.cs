namespace Amazon.Runtime.EventStreams
{
	public interface IEventInputStreamContextOwner
	{
		void SetEventInputStreamContext(EventInputStreamContext context);
	}
}
