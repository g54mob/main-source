using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Authenticating;
using FishNet.Broadcast;
using FishNet.Connection;
using FishNet.Managing.Logging;
using FishNet.Managing.Transporting;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Server
{
	[AddComponentMenu("FishNet/Manager/ServerManager")]
	[DisallowMultipleComponent]
	public sealed class ServerManager : MonoBehaviour
	{
		private delegate void ClientBroadcastDelegate(NetworkConnection connection, PooledReader reader);

		private readonly Dictionary<ushort, HashSet<ClientBroadcastDelegate>> _broadcastHandlers;

		private Dictionary<ushort, HashSet<(int, ClientBroadcastDelegate)>> _handlerTargets;

		private HashSet<NetworkConnection> _connectionsWithoutExclusions;

		[HideInInspector]
		public Dictionary<int, NetworkConnection> Clients;

		[Tooltip("Authenticator for this ServerManager. May be null if not using authentication.")]
		[SerializeField]
		private Authenticator _authenticator;

		[Tooltip("What platforms to enable remote client timeout.")]
		[SerializeField]
		private RemoteTimeoutType _remoteClientTimeout;

		[Tooltip("How long in seconds a client must go without sending any packets before getting disconnected. This is independent of any transport settings.")]
		[Range(1f, 1500f)]
		[SerializeField]
		private ushort _remoteClientTimeoutDuration;

		[Range(0f, 60f)]
		[SerializeField]
		[Tooltip("Default send rate for SyncTypes. A value of 0f will send changed values every tick.")]
		private float _syncTypeRate;

		[Tooltip("How to pack object spawns.")]
		[SerializeField]
		internal TransformPackingData SpawnPacking;

		[SerializeField]
		[Tooltip("True to automatically set the frame rate when the client connects.")]
		private bool _changeFrameRate;

		[Range(1f, 500f)]
		[SerializeField]
		[Tooltip("Maximum frame rate the server may run at. When as host this value runs at whichever is higher between client and server.")]
		private ushort _frameRate;

		[SerializeField]
		[Tooltip("True to share the Ids of clients and the objects they own with other clients. No sensitive information is shared.")]
		private bool _shareIds;

		[Tooltip("True to automatically start the server connection when running as headless.")]
		[SerializeField]
		private bool _startOnHeadless;

		[Tooltip("True to kick clients which send data larger than the MTU.")]
		[SerializeField]
		private bool _limitClientMTU;

		private int _nextClientTimeoutCheckIndex;

		private float _nextTimeoutCheckTime;

		private SplitReader _splitReader;

		public const ushort MAXIMUM_REMOTE_CLIENT_TIMEOUT_DURATION = 1500;

		private uint _cachedLevelOfDetailInterval;

		private bool _cachedUseLod;

		internal Dictionary<ushort, RpcLink> RpcLinks;

		private Queue<ushort> _availableRpcLinkIndexes;

		public bool Started { get; private set; }

		public ServerObjects Objects { get; private set; }

		[HideInInspector]
		public NetworkManager NetworkManager { get; private set; }

		[Obsolete("Use GetAuthenticator and SetAuthenticator.")]
		public Authenticator Authenticator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal ushort FrameRate => 0;

		internal bool ShareIds => false;

		internal bool LimitClientMTU => false;

		public event Action<ServerConnectionStateArgs> OnServerConnectionState
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

		public event Action<NetworkConnection, bool> OnAuthenticationResult
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

		public event Action<NetworkConnection, RemoteConnectionStateArgs> OnRemoteConnectionState
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

		public event Action<NetworkConnection, int, KickReason> OnClientKick
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

		public void RegisterBroadcast<T>(Action<NetworkConnection, T> handler, bool requireAuthentication = true) where T : struct, IBroadcast
		{
		}

		public void UnregisterBroadcast<T>(Action<NetworkConnection, T> handler) where T : struct, IBroadcast
		{
		}

		private ClientBroadcastDelegate CreateBroadcastDelegate<T>(Action<NetworkConnection, T> handler, bool requireAuthentication)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ParseBroadcast(PooledReader reader, NetworkConnection conn, Channel channel)
		{
		}

		public void Broadcast<T>(NetworkConnection connection, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void Broadcast<T>(HashSet<NetworkConnection> connections, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void BroadcastExcept<T>(HashSet<NetworkConnection> connections, NetworkConnection excludedConnection, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void BroadcastExcept<T>(HashSet<NetworkConnection> connections, HashSet<NetworkConnection> excludedConnections, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void BroadcastExcept<T>(NetworkConnection excludedConnection, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void BroadcastExcept<T>(HashSet<NetworkConnection> excludedConnections, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Broadcast<T>(NetworkObject networkObject, T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public void Broadcast<T>(T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		public Authenticator GetAuthenticator()
		{
			return null;
		}

		public void SetAuthenticator(Authenticator value)
		{
		}

		public void SetRemoteClientTimeout(RemoteTimeoutType timeoutType, ushort duration)
		{
		}

		internal float GetSynctypeRate()
		{
			return 0f;
		}

		public bool GetStartOnHeadless()
		{
			return false;
		}

		public void SetStartOnHeadless(bool value)
		{
		}

		private void OnDestroy()
		{
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		private void InitializeAuthenticator()
		{
		}

		internal void StartForHeadless()
		{
		}

		public bool StopConnection(bool sendDisconnectMessage)
		{
			return false;
		}

		internal void SendDisconnectMessages(int[] connectionIds)
		{
		}

		private void SendDisconnectMessages(List<NetworkConnection> conns, bool iterate)
		{
		}

		public bool StartConnection()
		{
			return false;
		}

		public bool StartConnection(ushort port)
		{
			return false;
		}

		private void CheckClientTimeout()
		{
		}

		private void TimeManager_OnPostTick()
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
		}

		private void SceneManager_OnClientLoadedStartScenes(NetworkConnection conn, bool asServer)
		{
		}

		private void SubscribeToTransport(bool subscribe)
		{
		}

		private void _authenticator_OnAuthenticationResult(NetworkConnection conn, bool authenticated)
		{
		}

		private void Transport_OnServerConnectionState(ServerConnectionStateArgs args)
		{
		}

		private void Transport_OnRemoteConnectionState(RemoteConnectionStateArgs args)
		{
		}

		private void SendAuthenticated(NetworkConnection conn)
		{
		}

		private void Transport_OnServerReceivedData(ServerReceivedDataArgs args)
		{
		}

		private void ParseReceived(ServerReceivedDataArgs args)
		{
		}

		private void ParsePingPong(PooledReader reader, NetworkConnection conn)
		{
		}

		private void ClientAuthenticated(NetworkConnection connection)
		{
		}

		private void BroadcastClientConnectionChange(bool connected, NetworkConnection conn)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ParseNetworkLODUpdate(PooledReader reader, NetworkConnection conn)
		{
		}

		public bool OneServerStarted()
		{
			return false;
		}

		public bool AnyServerStarted(int? excludedIndex = null)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Spawn(GameObject go, NetworkConnection ownerConnection = null, Scene scene = default(Scene))
		{
		}

		public void Spawn(NetworkObject nob, NetworkConnection ownerConnection = null, Scene scene = default(Scene))
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Despawn(GameObject go, DespawnType? despawnType = null)
		{
		}

		public void Despawn(NetworkObject networkObject, DespawnType? despawnType = null)
		{
		}

		public void Kick(NetworkConnection conn, KickReason kickReason, LoggingType loggingType = LoggingType.Common, string log = "")
		{
		}

		public void Kick(int clientId, KickReason kickReason, LoggingType loggingType = LoggingType.Common, string log = "")
		{
		}

		public void Kick(NetworkConnection conn, Reader reader, KickReason kickReason, LoggingType loggingType = LoggingType.Common, string log = "")
		{
		}

		private void InitializeRpcLinks()
		{
		}

		internal bool GetRpcLink(out ushort value)
		{
			value = default(ushort);
			return false;
		}

		internal void SetRpcLink(ushort linkIndex, RpcLink data)
		{
		}

		internal void StoreRpcLinks(Dictionary<uint, RpcLinkType> links)
		{
		}
	}
}
