using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LiteNetLib.Layers;
using LiteNetLib.Utils;

namespace LiteNetLib
{
	public class NetManager : IEnumerable<NetPeer>, IEnumerable
	{
		private class IPEndPointComparer : IEqualityComparer<IPEndPoint>
		{
			public bool Equals(IPEndPoint x, IPEndPoint y)
			{
				return false;
			}

			public int GetHashCode(IPEndPoint obj)
			{
				return 0;
			}
		}

		public struct NetPeerEnumerator : IEnumerator<NetPeer>, IEnumerator, IDisposable
		{
			private readonly NetPeer _initialPeer;

			private NetPeer _p;

			public NetPeer Current => null;

			object IEnumerator.Current => null;

			public NetPeerEnumerator(NetPeer p)
			{
				_initialPeer = null;
				_p = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		private Thread _logicThread;

		private bool _manualMode;

		private readonly AutoResetEvent _updateTriggerEvent;

		private Queue<NetEvent> _netEventsProduceQueue;

		private Queue<NetEvent> _netEventsConsumeQueue;

		private NetEvent _netEventPoolHead;

		private readonly INetEventListener _netEventListener;

		private readonly IDeliveryEventListener _deliveryEventListener;

		private readonly INtpEventListener _ntpEventListener;

		private readonly IPeerAddressChangedListener _peerAddressChangedListener;

		private readonly Dictionary<IPEndPoint, NetPeer> _peersDict;

		private readonly Dictionary<IPEndPoint, ConnectionRequest> _requestsDict;

		private readonly Dictionary<IPEndPoint, NtpRequest> _ntpRequests;

		private readonly ReaderWriterLockSlim _peersLock;

		private NetPeer _headPeer;

		private int _connectedPeersCount;

		private readonly List<NetPeer> _connectedPeerListCache;

		private NetPeer[] _peersArray;

		private readonly PacketLayerBase _extraPacketLayer;

		private int _lastPeerId;

		private ConcurrentQueue<int> _peerIds;

		private byte _channelsCount;

		private readonly object _eventLock;

		public bool UnconnectedMessagesEnabled;

		public bool NatPunchEnabled;

		public int UpdateTime;

		public int PingInterval;

		public int DisconnectTimeout;

		public bool SimulatePacketLoss;

		public bool SimulateLatency;

		public int SimulationPacketLossChance;

		public int SimulationMinLatency;

		public int SimulationMaxLatency;

		public bool UnsyncedEvents;

		public bool UnsyncedReceiveEvent;

		public bool UnsyncedDeliveryEvent;

		public bool BroadcastReceiveEnabled;

		public int ReconnectDelay;

		public int MaxConnectAttempts;

		public bool ReuseAddress;

		public readonly NetStatistics Statistics;

		public bool EnableStatistics;

		public readonly NatPunchModule NatPunchModule;

		public bool AutoRecycle;

		public IPv6Mode IPv6Mode;

		public int MtuOverride;

		public bool UseSafeMtu;

		public bool UseNativeSockets;

		public bool DisconnectOnUnreachable;

		public bool AllowPeerAddressChange;

		private NetPacket _poolHead;

		private int _poolCount;

		private readonly object _poolLock;

		public int PacketPoolSize;

		private const int ReceivePollingTime = 500000;

		private Socket _udpSocketv4;

		private Socket _udpSocketv6;

		private Thread _threadv4;

		private Thread _threadv6;

		private IPEndPoint _bufferEndPointv4;

		private IPEndPoint _bufferEndPointv6;

		[ThreadStatic]
		private static byte[] _sendToBuffer;

		[ThreadStatic]
		private static byte[] _endPointBuffer;

		private readonly Dictionary<NativeAddr, IPEndPoint> _nativeAddrMap;

		private const int SioUdpConnreset = -1744830452;

		private static readonly IPAddress MulticastAddressV6;

		public static readonly bool IPv6Support;

		public int MaxPacketsReceivePerUpdate;

		public bool IsRunning { get; private set; }

		public int LocalPort { get; private set; }

		public NetPeer FirstPeer => null;

		public byte ChannelsCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<NetPeer> ConnectedPeerList => null;

		public int ConnectedPeersCount => 0;

		public int ExtraPacketSizeForLayer => 0;

		public bool IsClient { get; private set; }

		public int PoolCount => 0;

		public short Ttl
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public NetPeer GetPeerById(int id)
		{
			return null;
		}

		public bool TryGetPeerById(int id, out NetPeer peer)
		{
			peer = null;
			return false;
		}

		private bool TryGetPeer(IPEndPoint endPoint, out NetPeer peer)
		{
			peer = null;
			return false;
		}

		private void AddPeer(NetPeer peer)
		{
		}

		private void RemovePeer(NetPeer peer)
		{
		}

		private void RemovePeer_Internal(NetPeer peer)
		{
		}

		public NetManager(INetEventListener listener, PacketLayerBase extraPacketLayer = null)
		{
		}

		internal void ConnectionLatencyUpdated(NetPeer fromPeer, int latency)
		{
		}

		internal void MessageDelivered(NetPeer fromPeer, object userData)
		{
		}

		internal void DisconnectPeerForce(NetPeer peer, DisconnectReason reason, SocketError socketErrorCode, NetPacket eventData)
		{
		}

		private void DisconnectPeer(NetPeer peer, DisconnectReason reason, SocketError socketErrorCode, bool force, byte[] data, int start, int count, NetPacket eventData)
		{
		}

		private void CreateEvent(NetEvent.EType type, NetPeer peer = null, IPEndPoint remoteEndPoint = null, SocketError errorCode = SocketError.Success, int latency = 0, DisconnectReason disconnectReason = DisconnectReason.ConnectionFailed, ConnectionRequest connectionRequest = null, DeliveryMethod deliveryMethod = DeliveryMethod.Unreliable, byte channelNumber = 0, NetPacket readerSource = null, object userData = null)
		{
		}

		private void ProcessEvent(NetEvent evt)
		{
		}

		internal void RecycleEvent(NetEvent evt)
		{
		}

		private void UpdateLogic()
		{
		}

		[Conditional("DEBUG")]
		private void ProcessDelayedPackets()
		{
		}

		private void ProcessNtpRequests(int elapsedMilliseconds)
		{
		}

		public void ManualUpdate(int elapsedMilliseconds)
		{
		}

		internal NetPeer OnConnectionSolved(ConnectionRequest request, byte[] rejectData, int start, int length)
		{
			return null;
		}

		private int GetNextPeerId()
		{
			return 0;
		}

		private void ProcessConnectRequest(IPEndPoint remoteEndPoint, NetPeer netPeer, NetConnectRequestPacket connRequest)
		{
		}

		private void OnMessageReceived(NetPacket packet, IPEndPoint remoteEndPoint)
		{
		}

		internal void CreateReceiveEvent(NetPacket packet, DeliveryMethod method, byte channelNumber, int headerSize, NetPeer fromPeer)
		{
		}

		public void SendToAll(NetDataWriter writer, DeliveryMethod options)
		{
		}

		public void SendToAll(byte[] data, DeliveryMethod options)
		{
		}

		public void SendToAll(byte[] data, int start, int length, DeliveryMethod options)
		{
		}

		public void SendToAll(NetDataWriter writer, byte channelNumber, DeliveryMethod options)
		{
		}

		public void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options)
		{
		}

		public void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options)
		{
		}

		public void SendToAll(NetDataWriter writer, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public void SendToAll(byte[] data, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public void SendToAll(byte[] data, int start, int length, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public void SendToAll(NetDataWriter writer, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
		}

		public bool Start()
		{
			return false;
		}

		public bool Start(IPAddress addressIPv4, IPAddress addressIPv6, int port)
		{
			return false;
		}

		public bool Start(string addressIPv4, string addressIPv6, int port)
		{
			return false;
		}

		public bool Start(int port)
		{
			return false;
		}

		public bool StartInManualMode(IPAddress addressIPv4, IPAddress addressIPv6, int port)
		{
			return false;
		}

		public bool StartInManualMode(string addressIPv4, string addressIPv6, int port)
		{
			return false;
		}

		public bool StartInManualMode(int port)
		{
			return false;
		}

		public bool SendUnconnectedMessage(byte[] message, IPEndPoint remoteEndPoint)
		{
			return false;
		}

		public bool SendUnconnectedMessage(NetDataWriter writer, string address, int port)
		{
			return false;
		}

		public bool SendUnconnectedMessage(NetDataWriter writer, IPEndPoint remoteEndPoint)
		{
			return false;
		}

		public bool SendUnconnectedMessage(byte[] message, int start, int length, IPEndPoint remoteEndPoint)
		{
			return false;
		}

		public void TriggerUpdate()
		{
		}

		public void PollEvents()
		{
		}

		public NetPeer Connect(string address, int port, string key)
		{
			return null;
		}

		public NetPeer Connect(string address, int port, NetDataWriter connectionData)
		{
			return null;
		}

		public NetPeer Connect(IPEndPoint target, string key)
		{
			return null;
		}

		public NetPeer Connect(IPEndPoint target, NetDataWriter connectionData)
		{
			return null;
		}

		public void Stop()
		{
		}

		public void Stop(bool sendDisconnectMessages)
		{
		}

		public int GetPeersCount(ConnectionState peerState)
		{
			return 0;
		}

		public void GetPeersNonAlloc(List<NetPeer> peers, ConnectionState peerState)
		{
		}

		public void DisconnectAll()
		{
		}

		public void DisconnectAll(byte[] data, int start, int count)
		{
		}

		public void DisconnectPeerForce(NetPeer peer)
		{
		}

		public void DisconnectPeer(NetPeer peer)
		{
		}

		public void DisconnectPeer(NetPeer peer, byte[] data)
		{
		}

		public void DisconnectPeer(NetPeer peer, NetDataWriter writer)
		{
		}

		public void DisconnectPeer(NetPeer peer, byte[] data, int start, int count)
		{
		}

		public void CreateNtpRequest(IPEndPoint endPoint)
		{
		}

		public void CreateNtpRequest(string ntpServerAddress, int port)
		{
		}

		public void CreateNtpRequest(string ntpServerAddress)
		{
		}

		public NetPeerEnumerator GetEnumerator()
		{
			return default(NetPeerEnumerator);
		}

		IEnumerator<NetPeer> IEnumerable<NetPeer>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private NetPacket PoolGetWithData(PacketProperty property, byte[] data, int start, int length)
		{
			return null;
		}

		private NetPacket PoolGetWithProperty(PacketProperty property, int size)
		{
			return null;
		}

		private NetPacket PoolGetWithProperty(PacketProperty property)
		{
			return null;
		}

		internal NetPacket PoolGetPacket(int size)
		{
			return null;
		}

		internal void PoolRecycle(NetPacket packet)
		{
		}

		public bool SocketActive(bool ipv4)
		{
			return false;
		}

		static NetManager()
		{
		}

		private bool IsActive()
		{
			return false;
		}

		private void RegisterEndPoint(IPEndPoint ep)
		{
		}

		private void UnregisterEndPoint(IPEndPoint ep)
		{
		}

		private bool ProcessError(SocketException ex)
		{
			return false;
		}

		private void ManualReceive(Socket socket, EndPoint bufferEndPoint)
		{
		}

		private void NativeReceiveLogic(object state)
		{
		}

		private void ReceiveLogic(object state)
		{
		}

		public bool Start(IPAddress addressIPv4, IPAddress addressIPv6, int port, bool manualMode)
		{
			return false;
		}

		private bool BindSocket(Socket socket, IPEndPoint ep)
		{
			return false;
		}

		internal int SendRawAndRecycle(NetPacket packet, IPEndPoint remoteEndPoint)
		{
			return 0;
		}

		internal int SendRaw(NetPacket packet, IPEndPoint remoteEndPoint)
		{
			return 0;
		}

		internal int SendRaw(byte[] message, int start, int length, IPEndPoint remoteEndPoint)
		{
			return 0;
		}

		public bool SendBroadcast(NetDataWriter writer, int port)
		{
			return false;
		}

		public bool SendBroadcast(byte[] data, int port)
		{
			return false;
		}

		public bool SendBroadcast(byte[] data, int start, int length, int port)
		{
			return false;
		}

		internal void CloseSocket(bool suspend)
		{
		}
	}
}
