using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class LoadBalancingClient : IPhotonPeerListener
	{
		private class EncryptionDataParameters
		{
			public const byte Mode = 0;

			public const byte Secret1 = 1;

			public const byte Secret2 = 2;
		}

		private class CallbackTargetChange
		{
			public readonly object Target;

			public readonly bool AddTarget;

			public CallbackTargetChange(object target, bool addTarget)
			{
			}
		}

		public AuthModeOption AuthMode;

		public EncryptionMode EncryptionMode;

		private object tokenCache;

		public string NameServerHost;

		private static readonly Dictionary<ConnectionProtocol, int> ProtocolToNameServerPort;

		public PhotonPortDefinition ServerPortOverrides;

		public Func<string, ServerConnection, string> AddressRewriter;

		public string ProxyServerAddress;

		private ClientState state;

		public ConnectionCallbacksContainer ConnectionCallbackTargets;

		public MatchMakingCallbacksContainer MatchMakingCallbackTargets;

		internal InRoomCallbacksContainer InRoomCallbackTargets;

		internal LobbyCallbacksContainer LobbyCallbackTargets;

		internal WebRpcCallbacksContainer WebRpcCallbackTargets;

		internal ErrorInfoCallbacksContainer ErrorInfoCallbackTargets;

		public string DisconnectMessage;

		public bool TelemetryEnabled;

		private bool telemetrySent;

		public SystemConnectionSummary SystemConnectionSummary;

		public bool EnableLobbyStatistics;

		private readonly List<TypedLobbyInfo> lobbyStatistics;

		private JoinType lastJoinType;

		private EnterRoomParams enterRoomParamsCache;

		private OperationResponse failedRoomEntryOperation;

		private const int FriendRequestListMax = 512;

		private string[] friendListRequested;

		public RegionHandler RegionHandler;

		private string bestRegionSummaryFromStorage;

		public string SummaryToCache;

		private bool connectToBestRegion;

		private readonly Queue<CallbackTargetChange> callbackTargetChanges;

		private readonly HashSet<object> callbackTargets;

		public int NameServerPortInAppSettings;

		public LoadBalancingPeer LoadBalancingPeer { get; private set; }

		public SerializationProtocol SerializationProtocol
		{
			get
			{
				return default(SerializationProtocol);
			}
			set
			{
			}
		}

		public string AppVersion { get; set; }

		public string AppId { get; set; }

		public ClientAppType ClientType { get; set; }

		public AuthenticationValues AuthValues { get; set; }

		public ConnectionProtocol? ExpectedProtocol { get; set; }

		private object TokenForInit => null;

		public bool IsUsingNameServer { get; set; }

		public string NameServerAddress => null;

		[Obsolete("Set port overrides in ServerPortOverrides. Not used anymore!")]
		public bool UseAlternativeUdpPorts { get; set; }

		public bool EnableProtocolFallback { get; set; }

		public string CurrentServerAddress => null;

		public string MasterServerAddress { get; set; }

		public string GameServerAddress { get; protected internal set; }

		public ServerConnection Server { get; private set; }

		public int ConnectCount { get; private set; }

		public ClientState State
		{
			get
			{
				return default(ClientState);
			}
			set
			{
			}
		}

		public bool IsConnected => false;

		public bool IsConnectedAndReady => false;

		public DisconnectCause DisconnectedCause { get; protected set; }

		public bool InLobby => false;

		public TypedLobby CurrentLobby { get; internal set; }

		public Player LocalPlayer { get; internal set; }

		public string NickName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string UserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Room CurrentRoom { get; set; }

		public bool InRoom => false;

		public int PlayersOnMasterCount { get; internal set; }

		public int PlayersInRoomsCount { get; internal set; }

		public int RoomsCount { get; internal set; }

		public bool IsFetchingFriendList => false;

		public string CloudRegion { get; private set; }

		public string CurrentCluster { get; private set; }

		public event Action<ClientState, ClientState> StateChanged
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

		public event Action<EventData> EventReceived
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

		public event Action<OperationResponse> OpResponseReceived
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

		public LoadBalancingClient(ConnectionProtocol protocol = ConnectionProtocol.Udp)
		{
		}

		public LoadBalancingClient(string masterAddress, string appId, string gameVersion, ConnectionProtocol protocol = ConnectionProtocol.Udp)
		{
		}

		private string GetNameServerAddress()
		{
			return null;
		}

		private string ToProtocolAddress(string address, int port, ConnectionProtocol protocol)
		{
			return null;
		}

		public virtual bool ConnectUsingSettings(AppSettings appSettings)
		{
			return false;
		}

		[Obsolete("Use ConnectToMasterServer() instead.")]
		public bool Connect()
		{
			return false;
		}

		public virtual bool ConnectToMasterServer()
		{
			return false;
		}

		public bool ConnectToNameServer()
		{
			return false;
		}

		public bool ConnectToRegionMaster(string region)
		{
			return false;
		}

		[Conditional("UNITY_WEBGL")]
		private void CheckConnectSetupWebGl()
		{
		}

		private bool Connect(string serverAddress, string proxyServerAddress, ServerConnection serverType)
		{
			return false;
		}

		public bool ReconnectToMaster()
		{
			return false;
		}

		public bool ReconnectAndRejoin()
		{
			return false;
		}

		public void Disconnect()
		{
		}

		internal void Disconnect(DisconnectCause cause)
		{
		}

		private void DisconnectToReconnect()
		{
		}

		public void SimulateConnectionLoss(bool simulateTimeout)
		{
		}

		private bool CallAuthenticate()
		{
			return false;
		}

		public void Service()
		{
		}

		private bool OpGetRegions()
		{
			return false;
		}

		public bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options = null)
		{
			return false;
		}

		public bool OpJoinLobby(TypedLobby lobby)
		{
			return false;
		}

		public bool OpLeaveLobby()
		{
			return false;
		}

		public bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams = null)
		{
			return false;
		}

		public bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
		{
			return false;
		}

		public bool OpCreateRoom(EnterRoomParams enterRoomParams)
		{
			return false;
		}

		public bool OpJoinOrCreateRoom(EnterRoomParams enterRoomParams)
		{
			return false;
		}

		public bool OpJoinRoom(EnterRoomParams enterRoomParams)
		{
			return false;
		}

		public bool OpRejoinRoom(string roomName, object ticket = null)
		{
			return false;
		}

		public bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
		{
			return false;
		}

		public bool OpGetGameList(TypedLobby typedLobby, string sqlLobbyFilter)
		{
			return false;
		}

		public bool OpSetCustomPropertiesOfActor(int actorNr, Hashtable propertiesToSet, Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			return false;
		}

		protected internal bool OpSetPropertiesOfActor(int actorNr, Hashtable actorProperties, Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			return false;
		}

		public bool OpSetCustomPropertiesOfRoom(Hashtable propertiesToSet, Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			return false;
		}

		protected internal bool OpSetPropertyOfRoom(byte propCode, object value)
		{
			return false;
		}

		protected internal bool OpSetPropertiesOfRoom(Hashtable gameProperties, Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			return false;
		}

		public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			return false;
		}

		public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
		{
			return false;
		}

		private void ReadoutProperties(Hashtable gameProperties, Hashtable actorProperties, int targetActorNr)
		{
		}

		private Hashtable ReadoutPropertiesForActorNr(Hashtable actorProperties, int actorNr)
		{
			return null;
		}

		public void ChangeLocalID(int newId, bool applyUserId = false)
		{
		}

		private void GameEnteredOnGameServer(OperationResponse operationResponse)
		{
		}

		private void UpdatedActorList(int[] actorsInGame)
		{
		}

		protected internal virtual Player CreatePlayer(string actorName, int actorNumber, bool isLocal, Hashtable actorProperties)
		{
			return null;
		}

		protected internal virtual Room CreateRoom(string roomName, RoomOptions opt)
		{
			return null;
		}

		private bool CheckIfOpAllowedOnServer(byte opCode, ServerConnection serverConnection)
		{
			return false;
		}

		private bool CheckIfOpCanBeSent(byte opCode, ServerConnection serverConnection, string opName)
		{
			return false;
		}

		private bool CheckIfClientIsReadyToCallOperation(byte opCode)
		{
			return false;
		}

		public virtual void DebugReturn(DebugLevel level, string message)
		{
		}

		private void CallbackRoomEnterFailed(OperationResponse operationResponse)
		{
		}

		public virtual void OnOperationResponse(OperationResponse operationResponse)
		{
		}

		public virtual void OnStatusChanged(StatusCode statusCode)
		{
		}

		public virtual void OnEvent(EventData photonEvent)
		{
		}

		public virtual void OnMessage(object message)
		{
		}

		private void OnDisconnectMessageReceived(DisconnectMessage obj)
		{
		}

		private void OnRegionPingCompleted(RegionHandler regionHandler)
		{
		}

		protected internal static string ReplacePortWithAlternative(string address, ushort replacementPort)
		{
			return null;
		}

		private void SetupEncryption(Dictionary<byte, object> encryptionData)
		{
		}

		public bool OpWebRpc(string uriPath, object parameters, bool sendAuthCookie = false)
		{
			return false;
		}

		public void AddCallbackTarget(object target)
		{
		}

		public void RemoveCallbackTarget(object target)
		{
		}

		protected internal void UpdateCallbackTargets()
		{
		}

		private void UpdateCallbackTarget<T>(CallbackTargetChange change, List<T> container) where T : class
		{
		}
	}
}
