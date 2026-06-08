using System.Net.Sockets;

namespace FlyingWormConsole3.LiteNetLib
{
	public struct DisconnectInfo
	{
		public DisconnectReason Reason;

		public SocketError SocketErrorCode;

		public NetPacketReader AdditionalData;
	}
}
