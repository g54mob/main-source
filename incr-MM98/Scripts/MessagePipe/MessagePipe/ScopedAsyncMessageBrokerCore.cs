using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class ScopedAsyncMessageBrokerCore<TMessage> : AsyncMessageBrokerCore<TMessage>
	{
		[Preserve]
		public ScopedAsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnostics, MessagePipeOptions options)
			: base(diagnostics, options)
		{
		}
	}
	[Preserve]
	public class ScopedAsyncMessageBrokerCore<TKey, TMessage> : AsyncMessageBrokerCore<TKey, TMessage>
	{
		public ScopedAsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
			: base(diagnotics, options)
		{
		}
	}
}
