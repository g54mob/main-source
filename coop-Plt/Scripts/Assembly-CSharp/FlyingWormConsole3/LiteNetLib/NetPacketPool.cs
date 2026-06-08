using System;
using System.Threading;

namespace FlyingWormConsole3.LiteNetLib
{
	internal sealed class NetPacketPool
	{
		private NetPacket _head;

		private int _count;

		private readonly object _lock = new object();

		public NetPacket GetWithData(PacketProperty property, byte[] data, int start, int length)
		{
			int headerSize = NetPacket.GetHeaderSize(property);
			NetPacket packet = GetPacket(length + headerSize);
			packet.Property = property;
			Buffer.BlockCopy(data, start, packet.RawData, headerSize, length);
			return packet;
		}

		public NetPacket GetWithProperty(PacketProperty property, int size)
		{
			NetPacket packet = GetPacket(size + NetPacket.GetHeaderSize(property));
			packet.Property = property;
			return packet;
		}

		public NetPacket GetWithProperty(PacketProperty property)
		{
			NetPacket packet = GetPacket(NetPacket.GetHeaderSize(property));
			packet.Property = property;
			return packet;
		}

		public NetPacket GetPacket(int size)
		{
			if (size > NetConstants.MaxPacketSize)
			{
				return new NetPacket(size);
			}
			NetPacket head;
			lock (_lock)
			{
				head = _head;
				if (head == null)
				{
					return new NetPacket(size);
				}
				_head = _head.Next;
			}
			Interlocked.Decrement(ref _count);
			head.Size = size;
			if (head.RawData.Length < size)
			{
				head.RawData = new byte[size];
			}
			return head;
		}

		public void Recycle(NetPacket packet)
		{
			if (packet.RawData.Length > NetConstants.MaxPacketSize || _count >= 1000)
			{
				return;
			}
			Interlocked.Increment(ref _count);
			packet.RawData[0] = 0;
			lock (_lock)
			{
				packet.Next = _head;
				_head = packet;
			}
		}
	}
}
