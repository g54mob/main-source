using System;
using kcp2k;

namespace GRP.Net
{
	public class KcpTransport : NetTransport
	{
		public KcpConfig config;

		public KcpServer server;

		public KcpClient client;

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientConnect(string address, ushort port)
		{
		}

		public override void ClientSend(ArraySegment<byte> segment, NetChannel channel)
		{
		}

		public override void ClientDisconnect()
		{
		}

		public override void ClientEarlyUpdate()
		{
		}

		public override void ClientLateUpdate()
		{
		}

		public override bool ServerActive()
		{
			return false;
		}

		public override void ServerStart(ushort port)
		{
		}

		public override void ServerSend(int connectionId, ArraySegment<byte> segment, NetChannel channel)
		{
		}

		public override void ServerDisconnect(int connectionId)
		{
		}

		public override void ServerStop()
		{
		}

		public override void ServerEarlyUpdate()
		{
		}

		public override void ServerLateUpdate()
		{
		}

		public override int GetMaxPacketSize(NetChannel channel)
		{
			return 0;
		}

		public static NetChannel FromKcpChannel(KcpChannel channel)
		{
			return default(NetChannel);
		}

		public static KcpChannel ToKcpChannel(NetChannel channel)
		{
			return default(KcpChannel);
		}

		public static TransportError ToTransportError(ErrorCode error)
		{
			return default(TransportError);
		}
	}
}
