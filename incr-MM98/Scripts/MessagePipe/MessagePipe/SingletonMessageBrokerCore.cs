using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class SingletonMessageBrokerCore<TMessage> : MessageBrokerCore<TMessage>
	{
		[Preserve]
		public SingletonMessageBrokerCore(MessagePipeDiagnosticsInfo diagnostics, MessagePipeOptions options)
			: base(diagnostics, options)
		{
		}
	}
	[Preserve]
	public class SingletonMessageBrokerCore<TKey, TMessage> : MessageBrokerCore<TKey, TMessage>
	{
		public SingletonMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
			: base(diagnotics, options)
		{
		}
	}
}
