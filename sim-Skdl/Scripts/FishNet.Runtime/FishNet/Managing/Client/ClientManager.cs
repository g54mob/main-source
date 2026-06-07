using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Broadcast;
using FishNet.Connection;
using FishNet.Managing.Server;
using FishNet.Managing.Transporting;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Managing.Client
{
	[AddComponentMenu("FishNet/Manager/ClientManager")]
	[DisallowMultipleComponent]
	public sealed class ClientManager : MonoBehaviour
	{
		private delegate void ServerBroadcastDelegate(PooledReader reader);

		private readonly Dictionary<ushort, HashSet<ServerBroadcastDelegate>> _broadcastHandlers;

		private Dictionary<ushort, HashSet<(int, ServerBroadcastDelegate)>> _handlerTargets;

		public NetworkConnection Connection;

		public Dictionary<int, NetworkConnection> Clients;

		[Tooltip("What platforms to enable remote server timeout.")]
		[SerializeField]
		private RemoteTimeoutType _remoteServerTimeout;

		[Tooltip("How long in seconds server must go without sending any packets before the local client disconnects. This is independent of any transport settings.")]
		[Range(1f, 1500f)]
		[SerializeField]
		private ushort _remoteServerTimeoutDuration;

		[Tooltip("True to automatically set the frame rate when the client connects.")]
		[SerializeField]
		private bool _changeFrameRate;

		[Tooltip("Maximum frame rate the client may run at. When as host this value runs at whichever is higher between client and server.")]
		[Range(1f, 500f)]
		[SerializeField]
		private ushort _frameRate;

		private float _lastPacketTime;

		private SplitReader _splitReader;

		private List<Vector3> _objectsPositionsCache;

		private int _nextLodNobIndex;

		public bool Started { get; private set; }

		public ClientObjects Objects { get; private set; }

		[HideInInspector]
		public NetworkManager NetworkManager { get; private set; }

		internal ushort FrameRate => 0;

		public uint LevelOfDetailInterval => 0u;

		public uint LastPacketLocalTick { get; private set; }

		public event Action OnAuthenticated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnClientTimeOut
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ClientConnectionStateArgs> OnClientConnectionState
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<RemoteConnectionStateArgs> OnRemoteConnectionState
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ConnectedClientsArgs> OnConnectedClients
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void RegisterBroadcast<T>(Action<T> handler) where T : struct, IBroadcast
		{
		}

		public void UnregisterBroadcast<T>(Action<T> handler) where T : struct, IBroadcast
		{
		}

		private ServerBroadcastDelegate CreateBroadcastDelegate<T>(Action<T> handler)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ParseBroadcast(PooledReader reader, Channel channel)
		{
		}

		public void Broadcast<T>(T message, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void SetRemoteServerTimeout(RemoteTimeoutType timeoutType, ushort duration)
		{
		}

		private void UpdateLastPacketDatas()
		{
		}

		private void OnDestroy()
		{
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		private void OnClientConnectionBroadcast(ClientConnectionChangeBroadcast args)
		{
		}

		private void OnConnectedClientsBroadcast(ConnectedClientsBroadcast args)
		{
		}

		private void SubscribeToEvents(bool subscribe)
		{
		}

		public int GetTransportIndex()
		{
			return 0;
		}

		public bool StopConnection()
		{
			return false;
		}

		public bool StartConnection()
		{
			return false;
		}

		public bool StartConnection(string address)
		{
			return false;
		}

		public bool StartConnection(string address, ushort port)
		{
			return false;
		}

		private void Transport_OnClientConnectionState(ClientConnectionStateArgs args)
		{
		}

		private void Transport_OnClientReceivedData(ClientReceivedDataArgs args)
		{
		}

		private void TransportManager_OnIterateIncomingEnd(bool server)
		{
		}

		private void ParseReceived(ClientReceivedDataArgs args)
		{
		}

		internal void ParseReader(PooledReader reader, Channel channel, bool print = false)
		{
		}

		private void ParsePingPong(PooledReader reader)
		{
		}

		private void ParseAuthenticated(PooledReader reader)
		{
		}

		private void TimeManager_OnPostTick()
		{
		}

		private void CheckServerTimeout()
		{
		}

		internal void TrySendLodUpdate(uint localTick, bool forceFullUpdate)
		{
		}
	}
}
