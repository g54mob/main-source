using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
	internal sealed class NetConnectRequestPacket
	{
		public const int HeaderSize = 18;

		public readonly long ConnectionTime;

		public byte ConnectionNumber;

		public readonly byte[] TargetAddress;

		public readonly NetDataReader Data;

		public readonly int PeerId;

		private NetConnectRequestPacket(long connectionTime, byte connectionNumber, int localId, byte[] targetAddress, NetDataReader data)
		{
		}

		public static int GetProtocolId(NetPacket packet)
		{
			return 0;
		}

		public static NetConnectRequestPacket FromData(NetPacket packet)
		{
			return null;
		}

		public static NetPacket Make(NetDataWriter connectData, SocketAddress addressBytes, long connectTime, int localId)
		{
			return null;
		}
	}
}
