using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LiteNetLib;
using LiteNetLib.Layers;

namespace FishNet.Transporting.Tugboat.Server
{
	public class ServerSocket : CommonSocket
	{
		private ushort _port;

		private int _maximumClients;

		private int _mtu;

		private ConcurrentQueue<LocalConnectionState> _localConnectionStates;

		private ConcurrentQueue<Packet> _incoming;

		private Queue<Packet> _outgoing;

		private ConcurrentQueue<RemoteConnectionEvent> _remoteConnectionEvents;

		private string _key;

		private int _timeout;

		private string _ipv4BindAddress;

		private string _ipv6BindAddress;

		private PacketLayerBase _packetLayer;

		private readonly object _stopLock;

		internal RemoteConnectionState GetConnectionState(int connectionId)
		{
			return default(RemoteConnectionState);
		}

		~ServerSocket()
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ThreadedSocket()
		{
		}

		private void StopSocketOnThread()
		{
		}

		internal string GetConnectionAddress(int connectionId)
		{
			return null;
		}

		private NetPeer GetNetPeer(int connectionId, bool connectedOnly)
		{
			return null;
		}

		internal bool StartConnection(ushort port, int maximumClients, string ipv4BindAddress, string ipv6BindAddress)
		{
			return false;
		}

		internal bool StopConnection()
		{
			return false;
		}

		internal bool StopConnection(int connectionId)
		{
			return false;
		}

		private void ResetQueues()
		{
		}

		private void Listener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
		{
		}

		private void Listener_PeerConnectedEvent(NetPeer peer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Listener_NetworkReceiveEvent(NetPeer fromPeer, NetPacketReader reader, byte channel, DeliveryMethod deliveryMethod)
		{
		}

		private void Listener_ConnectionRequestEvent(ConnectionRequest request)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DequeueOutgoing()
		{
		}

		internal void IterateOutgoing()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void IterateIncoming()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId)
		{
		}

		internal int GetMaximumClients()
		{
			return 0;
		}

		internal void SetMaximumClients(int value)
		{
		}
	}
}
