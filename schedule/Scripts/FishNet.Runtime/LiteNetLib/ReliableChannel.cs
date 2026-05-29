namespace LiteNetLib
{
	internal sealed class ReliableChannel : BaseChannel
	{
		private struct PendingPacket
		{
			private NetPacket _packet;

			private long _timeStamp;

			private bool _isSent;

			public override string ToString()
			{
				return null;
			}

			public void Init(NetPacket packet)
			{
			}

			public bool TrySend(long currentTime, NetPeer peer)
			{
				return false;
			}

			public bool Clear(NetPeer peer)
			{
				return false;
			}
		}

		private readonly NetPacket _outgoingAcks;

		private readonly PendingPacket[] _pendingPackets;

		private readonly NetPacket[] _receivedPackets;

		private readonly bool[] _earlyReceived;

		private int _localSeqence;

		private int _remoteSequence;

		private int _localWindowStart;

		private int _remoteWindowStart;

		private bool _mustSendAcks;

		private readonly DeliveryMethod _deliveryMethod;

		private readonly bool _ordered;

		private readonly int _windowSize;

		private const int BitsInByte = 8;

		private readonly byte _id;

		public ReliableChannel(NetPeer peer, bool ordered, byte id)
			: base(null)
		{
		}

		private void ProcessAck(NetPacket packet)
		{
		}

		protected override bool SendNextPackets()
		{
			return false;
		}

		public override bool ProcessPacket(NetPacket packet)
		{
			return false;
		}
	}
}
