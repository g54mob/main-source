using System;
using FlyingWormConsole3.LiteNetLib.Utils;

namespace FlyingWormConsole3.LiteNetLib
{
	public sealed class NetPacketReader : NetDataReader
	{
		private NetPacket _packet;

		private readonly NetManager _manager;

		private readonly NetEvent _evt;

		internal NetPacketReader(NetManager manager, NetEvent evt)
		{
			_manager = manager;
			_evt = evt;
		}

		internal void SetSource(NetPacket packet, int headerSize)
		{
			if (packet != null)
			{
				_packet = packet;
				SetSource(packet.RawData, headerSize, packet.Size);
			}
		}

		internal void RecycleInternal()
		{
			Clear();
			if (_packet != null)
			{
				_manager.NetPacketPool.Recycle(_packet);
			}
			_packet = null;
			_manager.RecycleEvent(_evt);
		}

		public void Recycle()
		{
			if (_manager.AutoRecycle)
			{
				throw new Exception("Recycle called with AutoRecycle enabled");
			}
			RecycleInternal();
		}
	}
}
