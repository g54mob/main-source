using System;
using System.Threading.Tasks;

namespace Amazon.Runtime.EventStreams.Internal
{
	public interface IEventOutputStream<T, TE> : IDisposable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		int BufferSize { get; set; }

		event EventHandler<EventStreamEventReceivedArgs<T>> EventReceived;

		event EventHandler<EventStreamExceptionReceivedArgs<TE>> ExceptionReceived;

		void StartProcessing();

		Task StartProcessingAsync();
	}
}
