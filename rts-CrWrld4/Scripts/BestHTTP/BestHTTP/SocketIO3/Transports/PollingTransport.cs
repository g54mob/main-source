using System.Collections.Generic;
using System.Text;

namespace BestHTTP.SocketIO3.Transports
{
	public sealed class PollingTransport : ITransport
	{
		private HTTPRequest LastRequest;

		private HTTPRequest PollRequest;

		private List<OutgoingPacket> lonelyPacketList;

		private StringBuilder sendBuilder;

		public TransportTypes Type => default(TransportTypes);

		public TransportStates State { get; private set; }

		public SocketManager Manager { get; private set; }

		public bool IsRequestInProgress => false;

		public bool IsPollingInProgress => false;

		public PollingTransport(SocketManager manager)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void Send(OutgoingPacket packet)
		{
		}

		public void Send(List<OutgoingPacket> packets)
		{
		}

		private void EncodePackets(List<OutgoingPacket> packets, HTTPRequest request)
		{
		}

		private void OnRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		public void Poll()
		{
		}

		private void OnPollRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void OnPacket(IncomingPacket packet)
		{
		}

		private void ParseResponse(HTTPResponse resp)
		{
		}

		private int FindNextRecordSeparator(byte[] data, int startIdx)
		{
			return 0;
		}
	}
}
