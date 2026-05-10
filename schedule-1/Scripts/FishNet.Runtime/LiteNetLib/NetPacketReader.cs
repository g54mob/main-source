using LiteNetLib.Utils;

namespace LiteNetLib
{
	public sealed class NetPacketReader : NetDataReader
	{
		private NetPacket _packet;

		private readonly NetManager _manager;

		private readonly NetEvent _evt;

		internal NetPacketReader(NetManager manager, NetEvent evt)
		{
		}

		internal void SetSource(NetPacket packet, int headerSize)
		{
		}

		internal void Recycle_Internal()
		{
		}

		public void Recycle()
		{
		}
	}
}
