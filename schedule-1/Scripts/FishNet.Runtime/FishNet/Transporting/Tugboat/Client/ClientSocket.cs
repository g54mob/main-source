using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LiteNetLib;
using LiteNetLib.Layers;

namespace FishNet.Transporting.Tugboat.Client
{
	public class ClientSocket : CommonSocket
	{
		private string _address;

		private ushort _port;

		private int _mtu;

		private ConcurrentQueue<LocalConnectionState> _localConnectionStates;

		private ConcurrentQueue<Packet> _incoming;

		private Queue<Packet> _outgoing;

		private int _timeout;

		private PacketLayerBase _packetLayer;

		private readonly object _stopLock;

		~ClientSocket()
		{
		}

		internal void Initialize(Transport t, int unreliableMTU, PacketLayerBase packetLayer)
		{
		}

		internal void UpdateTimeout(int timeout)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void PollSocket()
		{
		}

		private void ThreadedSocket()
		{
		}

		private void StopSocketOnThread()
		{
		}

		internal bool StartConnection(string address, ushort port)
		{
			return false;
		}

		internal bool StopConnection(DisconnectInfo? info = null)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ResetQueues()
		{
		}

		private void Listener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
		{
		}

		private void Listener_PeerConnectedEvent(NetPeer peer)
		{
		}

		private void Listener_NetworkReceiveEvent(NetPeer fromPeer, NetPacketReader reader, byte channel, DeliveryMethod deliveryMethod)
		{
		}

		private void DequeueOutgoing()
		{
		}

		internal void IterateOutgoing()
		{
		}

		internal void IterateIncoming()
		{
		}

		internal void SendToServer(byte channelId, ArraySegment<byte> segment)
		{
		}
	}
}
