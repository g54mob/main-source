using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class ScopedMessageBrokerCore<TMessage> : MessageBrokerCore<TMessage>
	{
		[Preserve]
		public ScopedMessageBrokerCore(MessagePipeDiagnosticsInfo diagnostics, MessagePipeOptions options)
			: base(diagnostics, options)
		{
		}
	}
	[Preserve]
	public class ScopedMessageBrokerCore<TKey, TMessage> : MessageBrokerCore<TKey, TMessage>
	{
		public ScopedMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
			: base(diagnotics, options)
		{
		}
	}
}
