using System.Collections.Concurrent;

namespace LiteNetLib
{
	internal abstract class BaseChannel
	{
		protected readonly NetPeer Peer;

		protected readonly ConcurrentQueue<NetPacket> OutgoingQueue;

		private int _isAddedToPeerChannelSendQueue;

		public int PacketsInQueue => 0;

		protected BaseChannel(NetPeer peer)
		{
		}

		public void AddToQueue(NetPacket packet)
		{
		}

		protected void AddToPeerChannelSendQueue()
		{
		}

		public bool SendAndCheckQueue()
		{
			return false;
		}

		protected abstract bool SendNextPackets();

		public abstract bool ProcessPacket(NetPacket packet);
	}
}
