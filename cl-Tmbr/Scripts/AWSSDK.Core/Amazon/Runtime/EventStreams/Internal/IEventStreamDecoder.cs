using System;

namespace Amazon.Runtime.EventStreams.Internal
{
	public interface IEventStreamDecoder : IDisposable
	{
		event EventHandler<EventStreamMessageReceivedEventArgs> MessageReceived;

		void ProcessData(byte[] data, int offset, int length);
	}
}
