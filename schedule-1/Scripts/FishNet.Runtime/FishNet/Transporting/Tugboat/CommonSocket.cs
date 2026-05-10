using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using LiteNetLib;

namespace FishNet.Transporting.Tugboat
{
	public abstract class CommonSocket
	{
		private LocalConnectionState _connectionState;

		protected Transport Transport;

		protected NetManager NetManager;

		internal LocalConnectionState GetConnectionState()
		{
			return default(LocalConnectionState);
		}

		protected void SetConnectionState(LocalConnectionState connectionState, bool asServer)
		{
		}

		internal void Send(ref Queue<Packet> queue, byte channelId, ArraySegment<byte> segment, int connectionId, int mtu)
		{
		}

		protected void UpdateTimeout(NetManager netManager, int timeout)
		{
		}

		internal void ClearGenericQueue<T>(ref ConcurrentQueue<T> queue)
		{
		}

		internal void ClearPacketQueue(ref ConcurrentQueue<Packet> queue)
		{
		}

		internal void ClearPacketQueue(ref Queue<Packet> queue)
		{
		}

		internal virtual void Listener_NetworkReceiveEvent(ConcurrentQueue<Packet> queue, NetPeer fromPeer, NetPacketReader reader, DeliveryMethod deliveryMethod, int mtu)
		{
		}

		internal void PollSocket(NetManager nm)
		{
		}

		internal ushort? GetPort()
		{
			return null;
		}
	}
}
