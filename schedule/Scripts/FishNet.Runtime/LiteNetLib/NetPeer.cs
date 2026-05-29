using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
	public class NetPeer
	{
		private class IncomingFragments
		{
			public NetPacket[] Fragments;

			public int ReceivedCount;

			public int TotalSize;

			public byte ChannelId;
		}

		private int _rtt;

		private int _avgRtt;

		private int _rttCount;

		private double _resendDelay;

		private int _pingSendTimer;

		private int _rttResetTimer;

		private readonly Stopwatch _pingTimer;

		private int _timeSinceLastPacket;

		private long _remoteDelta;

		private readonly object _shutdownLock;

		internal NetPeer NextPeer;

		internal NetPeer PrevPeer;

		private readonly Queue<NetPacket> _unreliableChannel;

		private readonly ConcurrentQueue<BaseChannel> _channelSendQueue;

		private readonly BaseChannel[] _channels;

		private int _mtu;

		private int _mtuIdx;

		private bool _finishMtu;

		private int _mtuCheckTimer;

		private int _mtuCheckAttempts;

		private const int MtuCheckDelay = 1000;

		private const int MaxMtuCheckAttempts = 4;

		private readonly object _mtuMutex;

		private int _fragmentId;

		private readonly Dictionary<ushort, IncomingFragments> _holdedFragments;

		private readonly Dictionary<ushort, ushort> _deliveredFragments;

		private readonly NetPacket _mergeData;

		private int _mergePos;

		private int _mergeCount;

		private IPEndPoint _remoteEndPoint;

		private int _connectAttempts;

		private int _connectTimer;

		private long _connectTime;

		private byte _connectNum;

		private ConnectionState _connectionState;

		private NetPacket _shutdownPacket;

		private const int ShutdownDelay = 300;

		private int _shutdownTimer;

		private readonly NetPacket _pingPacket;

		private readonly NetPacket _pongPacket;

		private readonly NetPacket _connectRequestPacket;

		private readonly NetPacket _connectAcceptPacket;

		public readonly NetManager NetManager;

		public readonly int Id;

		public object Tag;

		public readonly NetStatistics Statistics;

		internal byte ConnectionNum
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public IPEndPoint EndPoint => null;

		public ConnectionState ConnectionState => default(ConnectionState);

		internal long ConnectTime => 0L;

		public int RemoteId { get; private set; }

		public int Ping => 0;

		public int RoundTripTime => 0;

		public int Mtu => 0;

		public long RemoteTimeDelta => 0L;

		public DateTime RemoteUtcTime => default(DateTime);

		public int TimeSinceLastPacket => 0;

		internal double ResendDelay => 0.0;

		internal NetPeer(NetManager netManager, IPEndPoint remoteEndPoint, int id)
		{
		}

		internal void InitiateEndPointChange()
		{
		}

		internal void FinishEndPointChange(IPEndPoint newEndPoint)
		{
		}

		internal void ResetMtu()
		{
		}

		private void SetMtu(int mtuIdx)
		{
		}

		private void OverrideMtu(int mtuValue)
		{
		}

		public int GetPacketsCountInReliableQueue(byte channelNumber, bool ordered)
		{
			return 0;
		}

		public PooledPacket CreatePacketFromPool(DeliveryMethod deliveryMethod, byte channelNumber)
		{
			return default(PooledPacket);
		}

		public void SendPooledPacket(PooledPacket packet, int userDataSize)
		{
		}

		private BaseChannel CreateChannel(byte idx)
		{
			return null;
		}

		internal NetPeer(NetManager netManager, IPEndPoint remoteEndPoint, int id, byte connectNum, NetDataWriter connectData)
		{
		}

		internal NetPeer(NetManager netManager, ConnectionRequest request, int id)
		{
		}

		internal void Reject(NetConnectRequestPacket requestData, byte[] data, int start, int length)
		{
		}

		internal bool ProcessConnectAccept(NetConnectAcceptPacket packet)
		{
			return false;
		}

		public int GetMaxSinglePacketSize(DeliveryMethod options)
		{
			return 0;
		}

		public void SendWithDeliveryEvent(byte[] data, byte channelNumber, DeliveryMethod deliveryMethod, object userData)
		{
		}

		public void SendWithDeliveryEvent(byte[] data, int start, int length, byte channelNumber, DeliveryMethod deliveryMethod, object userData)
		{
		}

		public void SendWithDeliveryEvent(NetDataWriter dataWriter, byte channelNumber, DeliveryMethod deliveryMethod, object userData)
		{
		}

		public void Send(byte[] data, DeliveryMethod deliveryMethod)
		{
		}

		public void Send(NetDataWriter dataWriter, DeliveryMethod deliveryMethod)
		{
		}

		public void Send(byte[] data, int start, int length, DeliveryMethod options)
		{
		}

		public void Send(byte[] data, byte channelNumber, DeliveryMethod deliveryMethod)
		{
		}

		public void Send(NetDataWriter dataWriter, byte channelNumber, DeliveryMethod deliveryMethod)
		{
		}

		public void Send(byte[] data, int start, int length, byte channelNumber, DeliveryMethod deliveryMethod)
		{
		}

		private void Send_Internal(byte[] data, int start, int length, byte channelNumber, DeliveryMethod deliveryMethod, object userData)
		{
		}

		public void Disconnect(byte[] data)
		{
		}

		public void Disconnect(NetDataWriter writer)
		{
		}

		public void Disconnect(byte[] data, int start, int count)
		{
		}

		public void Disconnect()
		{
		}

		internal DisconnectResult ProcessDisconnect(NetPacket packet)
		{
			return default(DisconnectResult);
		}

		internal void AddToReliableChannelSendQueue(BaseChannel channel)
		{
		}

		internal ShutdownResult Shutdown(byte[] data, int start, int length, bool force)
		{
			return default(ShutdownResult);
		}

		private void UpdateRoundTripTime(int roundTripTime)
		{
		}

		internal void AddReliablePacket(DeliveryMethod method, NetPacket p)
		{
		}

		private void ProcessMtuPacket(NetPacket packet)
		{
		}

		private void UpdateMtuLogic(int deltaTime)
		{
		}

		internal ConnectRequestResult ProcessConnectRequest(NetConnectRequestPacket connRequest)
		{
			return default(ConnectRequestResult);
		}

		internal void ProcessPacket(NetPacket packet)
		{
		}

		private void SendMerged()
		{
		}

		internal void SendUserData(NetPacket packet)
		{
		}

		internal void Update(int deltaTime)
		{
		}

		internal void RecycleAndDeliver(NetPacket packet)
		{
		}
	}
}
