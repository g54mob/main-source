using System.Collections.Concurrent;
using BestHTTP.Extensions;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SignalRCore.Transports
{
	internal sealed class LongPollingTransport : TransportBase
	{
		private const int MaxRetries = 6;

		private ConcurrentQueue<BufferSegment> outgoingMessages;

		private int sendingInProgress;

		private BufferSegmentStream stream;

		public override TransportTypes TransportType => default(TransportTypes);

		internal LongPollingTransport(HubConnection con)
			: base(null)
		{
		}

		public override void StartConnect()
		{
		}

		public override void Send(BufferSegment msg)
		{
		}

		public override void StartClose()
		{
		}

		private void SendMessages()
		{
		}

		private void DoPoll()
		{
		}

		private void SendConnectionCloseRequest(int retryCount = 0)
		{
		}

		private void OnHandshakeRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void OnSendMessagesFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void OnPollRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void OnConnectionCloseRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}
	}
}
