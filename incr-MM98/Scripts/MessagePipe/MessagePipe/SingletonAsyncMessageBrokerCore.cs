using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class SingletonAsyncMessageBrokerCore<TMessage> : AsyncMessageBrokerCore<TMessage>
	{
		[Preserve]
		public SingletonAsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnostics, MessagePipeOptions options)
			: base(diagnostics, options)
		{
		}
	}
	[Preserve]
	public class SingletonAsyncMessageBrokerCore<TKey, TMessage> : AsyncMessageBrokerCore<TKey, TMessage>
	{
		public SingletonAsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
			: base(diagnotics, options)
		{
		}
	}
}
