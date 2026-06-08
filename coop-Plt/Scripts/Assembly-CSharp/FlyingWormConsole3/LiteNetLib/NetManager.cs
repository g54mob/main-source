using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FlyingWormConsole3.LiteNetLib.Layers;
using FlyingWormConsole3.LiteNetLib.Utils;

namespace FlyingWormConsole3.LiteNetLib
{
	public class NetManager : IEnumerable<NetPeer>, IEnumerable
	{
		private class IPEndPointComparer : IEqualityComparer<IPEndPoint>
		{
			public bool Equals(IPEndPoint x, IPEndPoint y)
			{
				if (x.Address.Equals(y.Address))
				{
					return x.Port == y.Port;
				}
				return false;
			}

			public int GetHashCode(IPEndPoint obj)
			{
				return obj.GetHashCode();
			}
		}

		public struct NetPeerEnumerator : IEnumerator<NetPeer>, IEnumerator, IDisposable
		{
			private readonly NetPeer _initialPeer;

			private NetPeer _p;

			public NetPeer Current => _p;

			object IEnumerator.Current => _p;

			public NetPeerEnumerator(NetPeer p)
			{
				_initialPeer = p;
				_p = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				_p = ((_p == null) ? _initialPeer : _p.NextPeer);
				return _p != null;
			}

			public void Reset()
			{
				throw new NotSupportedException();
			}
		}

		private readonly NetSocket _socket;

		private Thread _logicThread;

		private bool _manualMode;

		private readonly AutoResetEvent _updateTriggerEvent = new AutoResetEvent(initialState: true);

		private readonly Queue<NetEvent> _netEventsQueue;

		private NetEvent _netEventPoolHead;

		private readonly INetEventListener _netEventListener;

		private readonly IDeliveryEventListener _deliveryEventListener;

		private readonly INtpEventListener _ntpEventListener;

		private readonly Dictionary<IPEndPoint, NetPeer> _peersDict;

		private readonly Dictionary<IPEndPoint, ConnectionRequest> _requestsDict;

		private readonly Dictionary<IPEndPoint, NtpRequest> _ntpRequests;

		private readonly ReaderWriterLockSlim _peersLock;

		private volatile NetPeer _headPeer;

		private volatile int _connectedPeersCount;

		private readonly List<NetPeer> _connectedPeerListCache;

		private NetPeer[] _peersArray;

		private readonly PacketLayerBase _extraPacketLayer;

		private int _lastPeerId;

		private readonly Queue<int> _peerIds;

		private byte _channelsCount = 1;

		private readonly object _eventLock = new object();

		internal readonly NetPacketPool NetPacketPool;

		public bool UnconnectedMessagesEnabled;

		public bool NatPunchEnabled;

		public int UpdateTime = 15;

		public int PingInterval = 1000;

		public int DisconnectTimeout = 5000;

		public bool SimulatePacketLoss;

		public bool SimulateLatency;

		public int SimulationPacketLossChance = 10;

		public int SimulationMinLatency = 30;

		public int SimulationMaxLatency = 100;

		public bool UnsyncedEvents;

		public bool UnsyncedReceiveEvent;

		public bool UnsyncedDeliveryEvent;

		public bool BroadcastReceiveEnabled;

		public int ReconnectDelay = 500;

		public int MaxConnectAttempts = 10;

		public bool ReuseAddress;

		public readonly NetStatistics Statistics;

		public bool EnableStatistics;

		public readonly NatPunchModule NatPunchModule;

		public bool AutoRecycle;

		public IPv6Mode IPv6Enabled = IPv6Mode.SeparateSocket;

		public int MtuOverride;

		public bool UseSafeMtu;

		public bool DisconnectOnUnreachable;

		public bool IsRunning => _socket.IsRunning;

		public int LocalPort => _socket.LocalPort;

		public NetPeer FirstPeer => _headPeer;

		public byte ChannelsCount
		{
			get
			{
				return _channelsCount;
			}
			set
			{
				if (value < 1 || value > 64)
				{
					throw new ArgumentException("Channels count must be between 1 and 64");
				}
				_channelsCount = value;
			}
		}

		public List<NetPeer> ConnectedPeerList
		{
			get
			{
				GetPeersNonAlloc(_connectedPeerListCache, ConnectionState.Connected);
				return _connectedPeerListCache;
			}
		}

		public int ConnectedPeersCount => _connectedPeersCount;

		public int ExtraPacketSizeForLayer
		{
			get
			{
				if (_extraPacketLayer == null)
				{
					return 0;
				}
				return _extraPacketLayer.ExtraPacketSizeForLayer;
			}
		}

		public NetPeer GetPeerById(int id)
		{
			return _peersArray[id];
		}

		private bool TryGetPeer(IPEndPoint endPoint, out NetPeer peer)
		{
			_peersLock.EnterReadLock();
			bool result = _peersDict.TryGetValue(endPoint, out peer);
			_peersLock.ExitReadLock();
			return result;
		}

		private void AddPeer(NetPeer peer)
		{
			_peersLock.EnterWriteLock();
			if (_headPeer != null)
			{
				peer.NextPeer = _headPeer;
				_headPeer.PrevPeer = peer;
			}
			_headPeer = peer;
			_peersDict.Add(peer.EndPoint, peer);
			if (peer.Id >= _peersArray.Length)
			{
				int num = _peersArray.Length * 2;
				while (peer.Id >= num)
				{
					num *= 2;
				}
				Array.Resize(ref _peersArray, num);
			}
			_peersArray[peer.Id] = peer;
			_peersLock.ExitWriteLock();
		}

		private void RemovePeer(NetPeer peer)
		{
			_peersLock.EnterWriteLock();
			RemovePeerInternal(peer);
			_peersLock.ExitWriteLock();
		}

		private void RemovePeerInternal(NetPeer peer)
		{
			if (!_peersDict.Remove(peer.EndPoint))
			{
				return;
			}
			if (peer == _headPeer)
			{
				_headPeer = peer.NextPeer;
			}
			if (peer.PrevPeer != null)
			{
				peer.PrevPeer.NextPeer = peer.NextPeer;
			}
			if (peer.NextPeer != null)
			{
				peer.NextPeer.PrevPeer = peer.PrevPeer;
			}
			peer.PrevPeer = null;
			_peersArray[peer.Id] = null;
			lock (_peerIds)
			{
				_peerIds.Enqueue(peer.Id);
			}
		}

		public NetManager(INetEventListener listener, PacketLayerBase extraPacketLayer = null)
		{
			_socket = new NetSocket(this);
			_netEventListener = listener;
			_deliveryEventListener = listener as IDeliveryEventListener;
			_ntpEventListener = listener as INtpEventListener;
			_netEventsQueue = new Queue<NetEvent>();
			NetPacketPool = new NetPacketPool();
			NatPunchModule = new NatPunchModule(_socket);
			Statistics = new NetStatistics();
			_connectedPeerListCache = new List<NetPeer>();
			_peersDict = new Dictionary<IPEndPoint, NetPeer>(new IPEndPointComparer());
			_requestsDict = new Dictionary<IPEndPoint, ConnectionRequest>(new IPEndPointComparer());
			_ntpRequests = new Dictionary<IPEndPoint, NtpRequest>(new IPEndPointComparer());
			_peersLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
			_peerIds = new Queue<int>();
			_peersArray = new NetPeer[32];
			_extraPacketLayer = extraPacketLayer;
		}

		internal void ConnectionLatencyUpdated(NetPeer fromPeer, int latency)
		{
			CreateEvent(NetEvent.EType.ConnectionLatencyUpdated, fromPeer, null, SocketError.Success, latency);
		}

		internal void MessageDelivered(NetPeer fromPeer, object userData)
		{
			if (_deliveryEventListener != null)
			{
				CreateEvent(NetEvent.EType.MessageDelivered, fromPeer, null, SocketError.Success, 0, DisconnectReason.ConnectionFailed, null, DeliveryMethod.Unreliable, null, userData);
			}
		}

		internal int SendRawAndRecycle(NetPacket packet, IPEndPoint remoteEndPoint)
		{
			int result = SendRaw(packet.RawData, 0, packet.Size, remoteEndPoint);
			NetPacketPool.Recycle(packet);
			return result;
		}

		internal int SendRaw(NetPacket packet, IPEndPoint remoteEndPoint)
		{
			return SendRaw(packet.RawData, 0, packet.Size, remoteEndPoint);
		}

		internal int SendRaw(byte[] message, int start, int length, IPEndPoint remoteEndPoint)
		{
			if (!_socket.IsRunning)
			{
				return 0;
			}
			SocketError errorCode = SocketError.Success;
			int num;
			if (_extraPacketLayer != null)
			{
				NetPacket packet = NetPacketPool.GetPacket(length + _extraPacketLayer.ExtraPacketSizeForLayer);
				Buffer.BlockCopy(message, start, packet.RawData, 0, length);
				int offset = 0;
				_extraPacketLayer.ProcessOutBoundPacket(remoteEndPoint, ref packet.RawData, ref offset, ref length);
				num = _socket.SendTo(packet.RawData, offset, length, remoteEndPoint, ref errorCode);
				NetPacketPool.Recycle(packet);
			}
			else
			{
				num = _socket.SendTo(message, start, length, remoteEndPoint, ref errorCode);
			}
			switch (errorCode)
			{
			case SocketError.MessageSize:
				return -1;
			case SocketError.NetworkUnreachable:
			case SocketError.HostUnreachable:
			{
				if (DisconnectOnUnreachable && TryGetPeer(remoteEndPoint, out var peer))
				{
					DisconnectPeerForce(peer, (errorCode == SocketError.HostUnreachable) ? DisconnectReason.HostUnreachable : DisconnectReason.NetworkUnreachable, errorCode, null);
				}
				CreateEvent(NetEvent.EType.Error, null, remoteEndPoint, errorCode);
				return -1;
			}
			default:
				if (num <= 0)
				{
					return 0;
				}
				if (EnableStatistics)
				{
					Statistics.IncrementPacketsSent();
					Statistics.AddBytesSent(length);
				}
				return num;
			}
		}

		internal void DisconnectPeerForce(NetPeer peer, DisconnectReason reason, SocketError socketErrorCode, NetPacket eventData)
		{
			DisconnectPeer(peer, reason, socketErrorCode, force: true, null, 0, 0, eventData);
		}

		private void DisconnectPeer(NetPeer peer, DisconnectReason reason, SocketError socketErrorCode, bool force, byte[] data, int start, int count, NetPacket eventData)
		{
			switch (peer.Shutdown(data, start, count, force))
			{
			case ShutdownResult.None:
				return;
			case ShutdownResult.WasConnected:
				Interlocked.Decrement(ref _connectedPeersCount);
				break;
			}
			Thread.MemoryBarrier();
			CreateEvent(NetEvent.EType.Disconnect, peer, null, socketErrorCode, 0, reason, null, DeliveryMethod.Unreliable, eventData);
		}

		private void CreateEvent(NetEvent.EType type, NetPeer peer = null, IPEndPoint remoteEndPoint = null, SocketError errorCode = SocketError.Success, int latency = 0, DisconnectReason disconnectReason = DisconnectReason.ConnectionFailed, ConnectionRequest connectionRequest = null, DeliveryMethod deliveryMethod = DeliveryMethod.Unreliable, NetPacket readerSource = null, object userData = null)
		{
			bool flag = UnsyncedEvents;
			switch (type)
			{
			case NetEvent.EType.Connect:
				Interlocked.Increment(ref _connectedPeersCount);
				break;
			case NetEvent.EType.MessageDelivered:
				flag = UnsyncedDeliveryEvent;
				break;
			}
			NetEvent netEvent;
			lock (_eventLock)
			{
				netEvent = _netEventPoolHead;
				if (netEvent == null)
				{
					netEvent = new NetEvent(this);
				}
				else
				{
					_netEventPoolHead = netEvent.Next;
				}
			}
			netEvent.Type = type;
			netEvent.DataReader.SetSource(readerSource, readerSource?.GetHeaderSize() ?? 0);
			netEvent.Peer = peer;
			netEvent.RemoteEndPoint = remoteEndPoint;
			netEvent.Latency = latency;
			netEvent.ErrorCode = errorCode;
			netEvent.DisconnectReason = disconnectReason;
			netEvent.ConnectionRequest = connectionRequest;
			netEvent.DeliveryMethod = deliveryMethod;
			netEvent.UserData = userData;
			if (flag || _manualMode)
			{
				ProcessEvent(netEvent);
				return;
			}
			lock (_netEventsQueue)
			{
				_netEventsQueue.Enqueue(netEvent);
			}
		}

		private void ProcessEvent(NetEvent evt)
		{
			bool isNull = evt.DataReader.IsNull;
			switch (evt.Type)
			{
			case NetEvent.EType.Connect:
				_netEventListener.OnPeerConnected(evt.Peer);
				break;
			case NetEvent.EType.Disconnect:
			{
				DisconnectInfo disconnectInfo = new DisconnectInfo
				{
					Reason = evt.DisconnectReason,
					AdditionalData = evt.DataReader,
					SocketErrorCode = evt.ErrorCode
				};
				_netEventListener.OnPeerDisconnected(evt.Peer, disconnectInfo);
				break;
			}
			case NetEvent.EType.Receive:
				_netEventListener.OnNetworkReceive(evt.Peer, evt.DataReader, evt.DeliveryMethod);
				break;
			case NetEvent.EType.ReceiveUnconnected:
				_netEventListener.OnNetworkReceiveUnconnected(evt.RemoteEndPoint, evt.DataReader, UnconnectedMessageType.BasicMessage);
				break;
			case NetEvent.EType.Broadcast:
				_netEventListener.OnNetworkReceiveUnconnected(evt.RemoteEndPoint, evt.DataReader, UnconnectedMessageType.Broadcast);
				break;
			case NetEvent.EType.Error:
				_netEventListener.OnNetworkError(evt.RemoteEndPoint, evt.ErrorCode);
				break;
			case NetEvent.EType.ConnectionLatencyUpdated:
				_netEventListener.OnNetworkLatencyUpdate(evt.Peer, evt.Latency);
				break;
			case NetEvent.EType.ConnectionRequest:
				_netEventListener.OnConnectionRequest(evt.ConnectionRequest);
				break;
			case NetEvent.EType.MessageDelivered:
				_deliveryEventListener.OnMessageDelivered(evt.Peer, evt.UserData);
				break;
			}
			if (isNull)
			{
				RecycleEvent(evt);
			}
			else if (AutoRecycle)
			{
				evt.DataReader.RecycleInternal();
			}
		}

		internal void RecycleEvent(NetEvent evt)
		{
			evt.Peer = null;
			evt.ErrorCode = SocketError.Success;
			evt.RemoteEndPoint = null;
			evt.ConnectionRequest = null;
			lock (_eventLock)
			{
				evt.Next = _netEventPoolHead;
				_netEventPoolHead = evt;
			}
		}

		private void UpdateLogic()
		{
			List<NetPeer> list = new List<NetPeer>();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (_socket.IsRunning)
			{
				int num = (int)stopwatch.ElapsedMilliseconds;
				num = ((num <= 0) ? 1 : num);
				stopwatch.Reset();
				stopwatch.Start();
				for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
				{
					if (netPeer.ConnectionState == ConnectionState.Disconnected && netPeer.TimeSinceLastPacket > DisconnectTimeout)
					{
						list.Add(netPeer);
					}
					else
					{
						netPeer.Update(num);
					}
				}
				if (list.Count > 0)
				{
					_peersLock.EnterWriteLock();
					for (int i = 0; i < list.Count; i++)
					{
						RemovePeerInternal(list[i]);
					}
					_peersLock.ExitWriteLock();
					list.Clear();
				}
				ProcessNtpRequests(num);
				int num2 = UpdateTime - (int)stopwatch.ElapsedMilliseconds;
				if (num2 > 0)
				{
					_updateTriggerEvent.WaitOne(num2);
				}
			}
			stopwatch.Stop();
		}

		[Conditional("DEBUG")]
		private void ProcessDelayedPackets()
		{
		}

		private void ProcessNtpRequests(int elapsedMilliseconds)
		{
			List<IPEndPoint> list = null;
			foreach (KeyValuePair<IPEndPoint, NtpRequest> ntpRequest in _ntpRequests)
			{
				ntpRequest.Value.Send(_socket, elapsedMilliseconds);
				if (ntpRequest.Value.NeedToKill)
				{
					if (list == null)
					{
						list = new List<IPEndPoint>();
					}
					list.Add(ntpRequest.Key);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (IPEndPoint item in list)
			{
				_ntpRequests.Remove(item);
			}
		}

		public void ManualUpdate(int elapsedMilliseconds)
		{
			if (!_manualMode)
			{
				return;
			}
			for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
			{
				if (netPeer.ConnectionState == ConnectionState.Disconnected && netPeer.TimeSinceLastPacket > DisconnectTimeout)
				{
					RemovePeerInternal(netPeer);
				}
				else
				{
					netPeer.Update(elapsedMilliseconds);
				}
			}
			ProcessNtpRequests(elapsedMilliseconds);
		}

		public void ManualReceive()
		{
			if (_manualMode)
			{
				_socket.ManualReceive();
			}
		}

		internal void OnMessageReceived(NetPacket packet, SocketError errorCode, IPEndPoint remoteEndPoint)
		{
			if (errorCode != SocketError.Success)
			{
				CreateEvent(NetEvent.EType.Error, null, null, errorCode);
				NetDebug.WriteError("[NM] Receive error: {0}", errorCode);
				return;
			}
			try
			{
				DataReceived(packet, remoteEndPoint);
			}
			catch (Exception ex)
			{
				NetDebug.WriteError("[NM] SocketReceiveThread error: " + ex);
			}
		}

		internal NetPeer OnConnectionSolved(ConnectionRequest request, byte[] rejectData, int start, int length)
		{
			NetPeer value = null;
			if (request.Result == ConnectionRequestResult.RejectForce)
			{
				if (rejectData != null && length > 0)
				{
					NetPacket withProperty = NetPacketPool.GetWithProperty(PacketProperty.Disconnect, length);
					withProperty.ConnectionNumber = request.ConnectionNumber;
					FastBitConverter.GetBytes(withProperty.RawData, 1, request.ConnectionTime);
					if (withProperty.Size >= NetConstants.PossibleMtu[0])
					{
						NetDebug.WriteError("[Peer] Disconnect additional data size more than MTU!");
					}
					else
					{
						Buffer.BlockCopy(rejectData, start, withProperty.RawData, 9, length);
					}
					SendRawAndRecycle(withProperty, request.RemoteEndPoint);
				}
			}
			else
			{
				_peersLock.EnterUpgradeableReadLock();
				if (_peersDict.TryGetValue(request.RemoteEndPoint, out value))
				{
					_peersLock.ExitUpgradeableReadLock();
				}
				else if (request.Result == ConnectionRequestResult.Reject)
				{
					value = new NetPeer(this, request.RemoteEndPoint, GetNextPeerId());
					value.Reject(request.ConnectionTime, request.ConnectionNumber, rejectData, start, length);
					AddPeer(value);
					_peersLock.ExitUpgradeableReadLock();
				}
				else
				{
					value = new NetPeer(this, request.RemoteEndPoint, GetNextPeerId(), request.ConnectionTime, request.ConnectionNumber);
					AddPeer(value);
					_peersLock.ExitUpgradeableReadLock();
					CreateEvent(NetEvent.EType.Connect, value);
				}
			}
			lock (_requestsDict)
			{
				_requestsDict.Remove(request.RemoteEndPoint);
				return value;
			}
		}

		private int GetNextPeerId()
		{
			lock (_peerIds)
			{
				return (_peerIds.Count == 0) ? _lastPeerId++ : _peerIds.Dequeue();
			}
		}

		private void ProcessConnectRequest(IPEndPoint remoteEndPoint, NetPeer netPeer, NetConnectRequestPacket connRequest)
		{
			byte connectionNumber = connRequest.ConnectionNumber;
			if (netPeer != null)
			{
				ConnectRequestResult connectRequestResult = netPeer.ProcessConnectRequest(connRequest);
				switch (connectRequestResult)
				{
				default:
					return;
				case ConnectRequestResult.Reconnection:
					DisconnectPeerForce(netPeer, DisconnectReason.Reconnect, SocketError.Success, null);
					RemovePeer(netPeer);
					break;
				case ConnectRequestResult.NewConnection:
					RemovePeer(netPeer);
					break;
				case ConnectRequestResult.P2PLose:
					DisconnectPeerForce(netPeer, DisconnectReason.PeerToPeerConnection, SocketError.Success, null);
					RemovePeer(netPeer);
					break;
				}
				if (connectRequestResult != ConnectRequestResult.P2PLose)
				{
					connectionNumber = (byte)((netPeer.ConnectionNum + 1) % 4);
				}
			}
			ConnectionRequest value;
			lock (_requestsDict)
			{
				if (_requestsDict.TryGetValue(remoteEndPoint, out value))
				{
					value.UpdateRequest(connRequest);
					return;
				}
				value = new ConnectionRequest(connRequest.ConnectionTime, connectionNumber, connRequest.Data, remoteEndPoint, this);
				_requestsDict.Add(remoteEndPoint, value);
			}
			CreateEvent(NetEvent.EType.ConnectionRequest, null, null, SocketError.Success, 0, DisconnectReason.ConnectionFailed, value);
		}

		private void DataReceived(NetPacket packet, IPEndPoint remoteEndPoint)
		{
			if (EnableStatistics)
			{
				Statistics.IncrementPacketsReceived();
				Statistics.AddBytesReceived(packet.Size);
			}
			if (_ntpRequests.Count > 0 && _ntpRequests.TryGetValue(remoteEndPoint, out var _))
			{
				if (packet.Size < 48)
				{
					return;
				}
				byte[] array = new byte[packet.Size];
				Buffer.BlockCopy(packet.RawData, 0, array, 0, packet.Size);
				NtpPacket ntpPacket = NtpPacket.FromServerResponse(array, DateTime.UtcNow);
				try
				{
					ntpPacket.ValidateReply();
				}
				catch (InvalidOperationException)
				{
					ntpPacket = null;
				}
				if (ntpPacket != null)
				{
					_ntpRequests.Remove(remoteEndPoint);
					if (_ntpEventListener != null)
					{
						_ntpEventListener.OnNtpResponse(ntpPacket);
					}
				}
				return;
			}
			if (_extraPacketLayer != null)
			{
				int offset = 0;
				_extraPacketLayer.ProcessInboundPacket(remoteEndPoint, ref packet.RawData, ref offset, ref packet.Size);
				if (packet.Size == 0)
				{
					return;
				}
			}
			if (!packet.Verify())
			{
				NetDebug.WriteError("[NM] DataReceived: bad!");
				NetPacketPool.Recycle(packet);
				return;
			}
			switch (packet.Property)
			{
			case PacketProperty.ConnectRequest:
				if (NetConnectRequestPacket.GetProtocolId(packet) != 11)
				{
					SendRawAndRecycle(NetPacketPool.GetWithProperty(PacketProperty.InvalidProtocol), remoteEndPoint);
					return;
				}
				break;
			case PacketProperty.Broadcast:
				if (BroadcastReceiveEnabled)
				{
					CreateEvent(NetEvent.EType.Broadcast, null, remoteEndPoint, SocketError.Success, 0, DisconnectReason.ConnectionFailed, null, DeliveryMethod.Unreliable, packet);
				}
				return;
			case PacketProperty.UnconnectedMessage:
				if (UnconnectedMessagesEnabled)
				{
					CreateEvent(NetEvent.EType.ReceiveUnconnected, null, remoteEndPoint, SocketError.Success, 0, DisconnectReason.ConnectionFailed, null, DeliveryMethod.Unreliable, packet);
				}
				return;
			case PacketProperty.NatMessage:
				if (NatPunchEnabled)
				{
					NatPunchModule.ProcessMessage(remoteEndPoint, packet);
				}
				return;
			}
			_peersLock.EnterReadLock();
			NetPeer value2;
			bool flag = _peersDict.TryGetValue(remoteEndPoint, out value2);
			_peersLock.ExitReadLock();
			switch (packet.Property)
			{
			case PacketProperty.ConnectRequest:
			{
				NetConnectRequestPacket netConnectRequestPacket = NetConnectRequestPacket.FromData(packet);
				if (netConnectRequestPacket != null)
				{
					ProcessConnectRequest(remoteEndPoint, value2, netConnectRequestPacket);
				}
				break;
			}
			case PacketProperty.PeerNotFound:
				if (flag)
				{
					if (value2.ConnectionState == ConnectionState.Connected)
					{
						if (packet.Size == 1)
						{
							NetPacket withProperty = NetPacketPool.GetWithProperty(PacketProperty.PeerNotFound, 9);
							withProperty.RawData[1] = 0;
							FastBitConverter.GetBytes(withProperty.RawData, 2, value2.ConnectTime);
							SendRawAndRecycle(withProperty, remoteEndPoint);
						}
						else if (packet.Size == 10 && packet.RawData[1] == 1 && BitConverter.ToInt64(packet.RawData, 2) == value2.ConnectTime)
						{
							DisconnectPeerForce(value2, DisconnectReason.RemoteConnectionClose, SocketError.Success, null);
						}
					}
				}
				else if (packet.Size == 10 && packet.RawData[1] == 0)
				{
					packet.RawData[1] = 1;
					SendRawAndRecycle(packet, remoteEndPoint);
				}
				break;
			case PacketProperty.InvalidProtocol:
				if (flag && value2.ConnectionState == ConnectionState.Outgoing)
				{
					DisconnectPeerForce(value2, DisconnectReason.InvalidProtocol, SocketError.Success, null);
				}
				break;
			case PacketProperty.Disconnect:
				if (flag)
				{
					DisconnectResult disconnectResult = value2.ProcessDisconnect(packet);
					if (disconnectResult == DisconnectResult.None)
					{
						NetPacketPool.Recycle(packet);
						break;
					}
					DisconnectPeerForce(value2, (disconnectResult == DisconnectResult.Disconnect) ? DisconnectReason.RemoteConnectionClose : DisconnectReason.ConnectionRejected, SocketError.Success, packet);
				}
				else
				{
					NetPacketPool.Recycle(packet);
				}
				SendRawAndRecycle(NetPacketPool.GetWithProperty(PacketProperty.ShutdownOk), remoteEndPoint);
				break;
			case PacketProperty.ConnectAccept:
				if (flag)
				{
					NetConnectAcceptPacket netConnectAcceptPacket = NetConnectAcceptPacket.FromData(packet);
					if (netConnectAcceptPacket != null && value2.ProcessConnectAccept(netConnectAcceptPacket))
					{
						CreateEvent(NetEvent.EType.Connect, value2);
					}
				}
				break;
			default:
				if (flag)
				{
					value2.ProcessPacket(packet);
				}
				else
				{
					SendRawAndRecycle(NetPacketPool.GetWithProperty(PacketProperty.PeerNotFound), remoteEndPoint);
				}
				break;
			}
		}

		internal void CreateReceiveEvent(NetPacket packet, DeliveryMethod method, int headerSize, NetPeer fromPeer)
		{
			NetEvent netEvent;
			lock (_eventLock)
			{
				netEvent = _netEventPoolHead;
				if (netEvent == null)
				{
					netEvent = new NetEvent(this);
				}
				else
				{
					_netEventPoolHead = netEvent.Next;
				}
			}
			netEvent.Type = NetEvent.EType.Receive;
			netEvent.DataReader.SetSource(packet, headerSize);
			netEvent.Peer = fromPeer;
			netEvent.DeliveryMethod = method;
			if (UnsyncedEvents || UnsyncedReceiveEvent || _manualMode)
			{
				ProcessEvent(netEvent);
				return;
			}
			lock (_netEventsQueue)
			{
				_netEventsQueue.Enqueue(netEvent);
			}
		}

		public void SendToAll(NetDataWriter writer, DeliveryMethod options)
		{
			SendToAll(writer.Data, 0, writer.Length, options);
		}

		public void SendToAll(byte[] data, DeliveryMethod options)
		{
			SendToAll(data, 0, data.Length, options);
		}

		public void SendToAll(byte[] data, int start, int length, DeliveryMethod options)
		{
			SendToAll(data, start, length, 0, options);
		}

		public void SendToAll(NetDataWriter writer, byte channelNumber, DeliveryMethod options)
		{
			SendToAll(writer.Data, 0, writer.Length, channelNumber, options);
		}

		public void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options)
		{
			SendToAll(data, 0, data.Length, channelNumber, options);
		}

		public void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options)
		{
			try
			{
				_peersLock.EnterReadLock();
				for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
				{
					netPeer.Send(data, start, length, channelNumber, options);
				}
			}
			finally
			{
				_peersLock.ExitReadLock();
			}
		}

		public void SendToAll(NetDataWriter writer, DeliveryMethod options, NetPeer excludePeer)
		{
			SendToAll(writer.Data, 0, writer.Length, 0, options, excludePeer);
		}

		public void SendToAll(byte[] data, DeliveryMethod options, NetPeer excludePeer)
		{
			SendToAll(data, 0, data.Length, 0, options, excludePeer);
		}

		public void SendToAll(byte[] data, int start, int length, DeliveryMethod options, NetPeer excludePeer)
		{
			SendToAll(data, start, length, 0, options, excludePeer);
		}

		public void SendToAll(NetDataWriter writer, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
			SendToAll(writer.Data, 0, writer.Length, channelNumber, options, excludePeer);
		}

		public void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
			SendToAll(data, 0, data.Length, channelNumber, options, excludePeer);
		}

		public void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options, NetPeer excludePeer)
		{
			try
			{
				_peersLock.EnterReadLock();
				for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
				{
					if (netPeer != excludePeer)
					{
						netPeer.Send(data, start, length, channelNumber, options);
					}
				}
			}
			finally
			{
				_peersLock.ExitReadLock();
			}
		}

		public bool Start()
		{
			return Start(0);
		}

		public bool Start(IPAddress addressIPv4, IPAddress addressIPv6, int port)
		{
			_manualMode = false;
			if (!_socket.Bind(addressIPv4, addressIPv6, port, ReuseAddress, IPv6Enabled, manualMode: false))
			{
				return false;
			}
			_logicThread = new Thread(UpdateLogic)
			{
				Name = "LogicThread",
				IsBackground = true
			};
			_logicThread.Start();
			return true;
		}

		public bool Start(string addressIPv4, string addressIPv6, int port)
		{
			IPAddress addressIPv7 = NetUtils.ResolveAddress(addressIPv4);
			IPAddress addressIPv8 = NetUtils.ResolveAddress(addressIPv6);
			return Start(addressIPv7, addressIPv8, port);
		}

		public bool Start(int port)
		{
			return Start(IPAddress.Any, IPAddress.IPv6Any, port);
		}

		public bool StartInManualMode(IPAddress addressIPv4, IPAddress addressIPv6, int port)
		{
			_manualMode = true;
			if (!_socket.Bind(addressIPv4, addressIPv6, port, ReuseAddress, IPv6Enabled, manualMode: true))
			{
				return false;
			}
			return true;
		}

		public bool StartInManualMode(string addressIPv4, string addressIPv6, int port)
		{
			IPAddress addressIPv7 = NetUtils.ResolveAddress(addressIPv4);
			IPAddress addressIPv8 = NetUtils.ResolveAddress(addressIPv6);
			return StartInManualMode(addressIPv7, addressIPv8, port);
		}

		public bool StartInManualMode(int port)
		{
			return StartInManualMode(IPAddress.Any, IPAddress.IPv6Any, port);
		}

		public bool SendUnconnectedMessage(byte[] message, IPEndPoint remoteEndPoint)
		{
			return SendUnconnectedMessage(message, 0, message.Length, remoteEndPoint);
		}

		public bool SendUnconnectedMessage(NetDataWriter writer, IPEndPoint remoteEndPoint)
		{
			return SendUnconnectedMessage(writer.Data, 0, writer.Length, remoteEndPoint);
		}

		public bool SendUnconnectedMessage(byte[] message, int start, int length, IPEndPoint remoteEndPoint)
		{
			NetPacket withData = NetPacketPool.GetWithData(PacketProperty.UnconnectedMessage, message, start, length);
			return SendRawAndRecycle(withData, remoteEndPoint) > 0;
		}

		public bool SendBroadcast(NetDataWriter writer, int port)
		{
			return SendBroadcast(writer.Data, 0, writer.Length, port);
		}

		public bool SendBroadcast(byte[] data, int port)
		{
			return SendBroadcast(data, 0, data.Length, port);
		}

		public bool SendBroadcast(byte[] data, int start, int length, int port)
		{
			NetPacket netPacket;
			if (_extraPacketLayer != null)
			{
				int headerSize = NetPacket.GetHeaderSize(PacketProperty.Broadcast);
				netPacket = NetPacketPool.GetPacket(headerSize + length + _extraPacketLayer.ExtraPacketSizeForLayer);
				netPacket.Property = PacketProperty.Broadcast;
				Buffer.BlockCopy(data, start, netPacket.RawData, headerSize, length);
				int offset = 0;
				int length2 = length + headerSize;
				_extraPacketLayer.ProcessOutBoundPacket(null, ref netPacket.RawData, ref offset, ref length2);
			}
			else
			{
				netPacket = NetPacketPool.GetWithData(PacketProperty.Broadcast, data, start, length);
			}
			bool result = _socket.SendBroadcast(netPacket.RawData, 0, netPacket.Size, port);
			NetPacketPool.Recycle(netPacket);
			return result;
		}

		public void TriggerUpdate()
		{
			_updateTriggerEvent.Set();
		}

		public void PollEvents()
		{
			if (UnsyncedEvents)
			{
				return;
			}
			int count;
			lock (_netEventsQueue)
			{
				count = _netEventsQueue.Count;
			}
			for (int i = 0; i < count; i++)
			{
				NetEvent evt;
				lock (_netEventsQueue)
				{
					evt = _netEventsQueue.Dequeue();
				}
				ProcessEvent(evt);
			}
		}

		public NetPeer Connect(string address, int port, string key)
		{
			return Connect(address, port, NetDataWriter.FromString(key));
		}

		public NetPeer Connect(string address, int port, NetDataWriter connectionData)
		{
			IPEndPoint target;
			try
			{
				target = NetUtils.MakeEndPoint(address, port);
			}
			catch
			{
				CreateEvent(NetEvent.EType.Disconnect, null, null, SocketError.Success, 0, DisconnectReason.UnknownHost);
				return null;
			}
			return Connect(target, connectionData);
		}

		public NetPeer Connect(IPEndPoint target, string key)
		{
			return Connect(target, NetDataWriter.FromString(key));
		}

		public NetPeer Connect(IPEndPoint target, NetDataWriter connectionData)
		{
			if (!_socket.IsRunning)
			{
				throw new InvalidOperationException("Client is not running");
			}
			byte connectNum = 0;
			lock (_requestsDict)
			{
				if (_requestsDict.ContainsKey(target))
				{
					return null;
				}
			}
			_peersLock.EnterUpgradeableReadLock();
			if (_peersDict.TryGetValue(target, out var value))
			{
				ConnectionState connectionState = value.ConnectionState;
				if (connectionState == ConnectionState.Outgoing || connectionState == ConnectionState.Connected)
				{
					_peersLock.ExitUpgradeableReadLock();
					return value;
				}
				connectNum = (byte)((value.ConnectionNum + 1) % 4);
				RemovePeer(value);
			}
			value = new NetPeer(this, target, GetNextPeerId(), connectNum, connectionData);
			AddPeer(value);
			_peersLock.ExitUpgradeableReadLock();
			return value;
		}

		public void Stop()
		{
			Stop(sendDisconnectMessages: true);
		}

		public void Stop(bool sendDisconnectMessages)
		{
			if (!_socket.IsRunning)
			{
				return;
			}
			for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
			{
				netPeer.Shutdown(null, 0, 0, !sendDisconnectMessages);
			}
			_socket.Close(suspend: false);
			_updateTriggerEvent.Set();
			if (!_manualMode)
			{
				_logicThread.Join();
				_logicThread = null;
			}
			_peersLock.EnterWriteLock();
			_headPeer = null;
			_peersDict.Clear();
			_peersArray = new NetPeer[32];
			_peersLock.ExitWriteLock();
			lock (_peerIds)
			{
				_peerIds.Clear();
			}
			_connectedPeersCount = 0;
			lock (_netEventsQueue)
			{
				_netEventsQueue.Clear();
			}
		}

		public int GetPeersCount(ConnectionState peerState)
		{
			int num = 0;
			_peersLock.EnterReadLock();
			for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
			{
				if ((netPeer.ConnectionState & peerState) != 0)
				{
					num++;
				}
			}
			_peersLock.ExitReadLock();
			return num;
		}

		public void GetPeersNonAlloc(List<NetPeer> peers, ConnectionState peerState)
		{
			peers.Clear();
			_peersLock.EnterReadLock();
			for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
			{
				if ((netPeer.ConnectionState & peerState) != 0)
				{
					peers.Add(netPeer);
				}
			}
			_peersLock.ExitReadLock();
		}

		public void DisconnectAll()
		{
			DisconnectAll(null, 0, 0);
		}

		public void DisconnectAll(byte[] data, int start, int count)
		{
			_peersLock.EnterReadLock();
			for (NetPeer netPeer = _headPeer; netPeer != null; netPeer = netPeer.NextPeer)
			{
				DisconnectPeer(netPeer, DisconnectReason.DisconnectPeerCalled, SocketError.Success, force: false, data, start, count, null);
			}
			_peersLock.ExitReadLock();
		}

		public void DisconnectPeerForce(NetPeer peer)
		{
			DisconnectPeerForce(peer, DisconnectReason.DisconnectPeerCalled, SocketError.Success, null);
		}

		public void DisconnectPeer(NetPeer peer)
		{
			DisconnectPeer(peer, null, 0, 0);
		}

		public void DisconnectPeer(NetPeer peer, byte[] data)
		{
			DisconnectPeer(peer, data, 0, data.Length);
		}

		public void DisconnectPeer(NetPeer peer, NetDataWriter writer)
		{
			DisconnectPeer(peer, writer.Data, 0, writer.Length);
		}

		public void DisconnectPeer(NetPeer peer, byte[] data, int start, int count)
		{
			DisconnectPeer(peer, DisconnectReason.DisconnectPeerCalled, SocketError.Success, force: false, data, start, count, null);
		}

		public void CreateNtpRequest(IPEndPoint endPoint)
		{
			_ntpRequests.Add(endPoint, new NtpRequest(endPoint));
		}

		public void CreateNtpRequest(string ntpServerAddress, int port)
		{
			IPEndPoint iPEndPoint = NetUtils.MakeEndPoint(ntpServerAddress, port);
			_ntpRequests.Add(iPEndPoint, new NtpRequest(iPEndPoint));
		}

		public void CreateNtpRequest(string ntpServerAddress)
		{
			IPEndPoint iPEndPoint = NetUtils.MakeEndPoint(ntpServerAddress, 123);
			_ntpRequests.Add(iPEndPoint, new NtpRequest(iPEndPoint));
		}

		public NetPeerEnumerator GetEnumerator()
		{
			return new NetPeerEnumerator(_headPeer);
		}

		IEnumerator<NetPeer> IEnumerable<NetPeer>.GetEnumerator()
		{
			return new NetPeerEnumerator(_headPeer);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new NetPeerEnumerator(_headPeer);
		}
	}
}
