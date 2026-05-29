namespace LiteNetLib
{
	internal sealed class SequencedChannel : BaseChannel
	{
		private int _localSequence;

		private ushort _remoteSequence;

		private readonly bool _reliable;

		private NetPacket _lastPacket;

		private readonly NetPacket _ackPacket;

		private bool _mustSendAck;

		private readonly byte _id;

		private long _lastPacketSendTime;

		public SequencedChannel(NetPeer peer, bool reliable, byte id)
			: base(null)
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
