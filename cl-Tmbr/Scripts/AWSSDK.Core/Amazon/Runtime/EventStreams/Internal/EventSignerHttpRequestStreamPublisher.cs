using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.EventStreams.Internal
{
	internal class EventSignerHttpRequestStreamPublisher : IHttpRequestStreamPublisher
	{
		private readonly IEventStreamPublisher _eventPublisher;

		private readonly IEventSigner _eventSigner;

		public EventSignerHttpRequestStreamPublisher(IEventStreamPublisher eventPublisher, IEventSigner eventSigner)
		{
			_eventPublisher = eventPublisher;
			_eventSigner = eventSigner;
		}

		public async Task<byte[]> NextBytesAsync()
		{
			IEventStreamMessage eventStreamMessage = await _eventPublisher.NextEventAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (eventStreamMessage == null)
			{
				return null;
			}
			return await _eventSigner.SignEventAsync(eventStreamMessage.ToByteArray()).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
