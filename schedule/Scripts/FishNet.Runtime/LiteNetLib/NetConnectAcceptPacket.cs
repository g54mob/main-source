namespace LiteNetLib
{
	internal sealed class NetConnectAcceptPacket
	{
		public const int Size = 15;

		public readonly long ConnectionTime;

		public readonly byte ConnectionNumber;

		public readonly int PeerId;

		public readonly bool PeerNetworkChanged;

		private NetConnectAcceptPacket(long connectionTime, byte connectionNumber, int peerId, bool peerNetworkChanged)
		{
		}

		public static NetConnectAcceptPacket FromData(NetPacket packet)
		{
			return null;
		}

		public static NetPacket Make(long connectTime, byte connectNum, int localPeerId)
		{
			return null;
		}

		public static NetPacket MakeNetworkChanged(NetPeer peer)
		{
			return null;
		}
	}
}
