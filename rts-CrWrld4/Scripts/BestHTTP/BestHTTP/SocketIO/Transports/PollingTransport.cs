using System.Collections.Generic;
using System.Text;

namespace BestHTTP.SocketIO.Transports
{
	public sealed class PollingTransport : ITransport
	{
		public enum PayloadTypes : byte
		{
			Text = 0,
			Binary = 1
		}

		private HTTPRequest LastRequest;

		private HTTPRequest PollRequest;

		private Packet PacketWithAttachment;

		private List<Packet> lonelyPacketList;

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

		public void Send(Packet packet)
		{
		}

		public void Send(List<Packet> packets)
		{
		}

		private void SendV3(List<Packet> packets, HTTPRequest request)
		{
		}

		private void SendV2(List<Packet> packets, HTTPRequest request)
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

		private void OnPacket(Packet packet)
		{
		}

		private SupportedSocketIOVersions GetServerVersion(HTTPResponse resp)
		{
			return default(SupportedSocketIOVersions);
		}

		private void ParseResponse(HTTPResponse resp)
		{
		}

		private void ParseResponseV3(HTTPResponse resp)
		{
		}

		private int FindNextRecordSeparator(byte[] data, int startIdx)
		{
			return 0;
		}

		private void ParseResponseV2(HTTPResponse resp)
		{
		}
	}
}
