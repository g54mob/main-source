namespace MessagePipe
{
	public class MessagePipeBuilder : IMessagePipeBuilder
	{
		public IServiceCollection Services { get; }

		public MessagePipeBuilder(IServiceCollection services)
		{
			Services = services;
		}
	}
}
