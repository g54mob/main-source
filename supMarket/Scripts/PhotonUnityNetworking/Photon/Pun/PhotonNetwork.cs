using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun
{
	public static class PhotonNetwork
	{
		private struct RaiseEventBatch : IEquatable<RaiseEventBatch>
		{
			public byte Group;

			public bool Reliable;

			public override int GetHashCode()
			{
				return 0;
			}

			public bool Equals(RaiseEventBatch other)
			{
				return false;
			}
		}

		private class SerializeViewBatch : IEquatable<SerializeViewBatch>, IEquatable<RaiseEventBatch>
		{
			public readonly RaiseEventBatch Batch;

			public List<object> ObjectUpdates;

			private int defaultSize;

			private int offset;

			public SerializeViewBatch(RaiseEventBatch batch, int offset)
			{
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public bool Equals(SerializeViewBatch other)
			{
				return false;
			}

			public bool Equals(RaiseEventBatch other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public void Clear()
			{
			}

			public void Add(List<object> viewData)
			{
			}
		}

		public const string PunVersion = "2.50";

		private static string gameVersion;

		public static LoadBalancingClient NetworkingClient;

		public static readonly int MAX_VIEW_IDS;

		public const string ServerSettingsFileName = "PhotonServerSettings";

		private static ServerSettings photonServerSettings;

		private const string PlayerPrefsKey = "PUNCloudBestRegion";

		public static ConnectMethod ConnectMethod;

		public static PunLogLevel LogLevel;

		public static bool EnableCloseConnection;

		public static float PrecisionForVectorSynchronization;

		public static float PrecisionForQuaternionSynchronization;

		public static float PrecisionForFloatSynchronization;

		private static bool offlineMode;

		private static Room offlineModeRoom;

		private static bool automaticallySyncScene;

		private static int sendFrequency;

		private static int serializationFrequency;

		private static bool isMessageQueueRunning;

		private static double frametime;

		private static int frame;

		private static Stopwatch StartupStopwatch;

		public static float MinimalTimeScaleToDispatchInFixedUpdate;

		private static int lastUsedViewSubId;

		private static int lastUsedViewSubIdStatic;

		private static readonly HashSet<string> PrefabsWithoutMagicCallback;

		private static readonly Hashtable SendInstantiateEvHashtable;

		private static readonly RaiseEventOptions SendInstantiateRaiseEventOptions;

		private static HashSet<byte> allowedReceivingGroups;

		private static HashSet<byte> blockedSendingGroups;

		private static HashSet<PhotonView> reusablePVHashset;

		private static NonAllocDictionary<int, PhotonView> photonViewList;

		internal static byte currentLevelPrefix;

		internal static bool loadingLevelAndPausedNetwork;

		internal const string CurrentSceneProperty = "curScn";

		internal const string CurrentScenePropertyLoadAsync = "curScnLa";

		private static IPunPrefabPool prefabPool;

		public static bool UseRpcMonoBehaviourCache;

		private static readonly Dictionary<Type, List<MethodInfo>> monoRPCMethodsCache;

		private static Dictionary<string, int> rpcShortcuts;

		public static bool RunRpcCoroutines;

		private static AsyncOperation _AsyncLevelLoadingOperation;

		private static float _levelLoadingProgress;

		private static readonly Type typePunRPC;

		private static readonly Type typePhotonMessageInfo;

		private static readonly object keyByteZero;

		private static readonly object keyByteOne;

		private static readonly object keyByteTwo;

		private static readonly object keyByteThree;

		private static readonly object keyByteFour;

		private static readonly object keyByteFive;

		private static readonly object keyByteSix;

		private static readonly object keyByteSeven;

		private static readonly object keyByteEight;

		private static readonly object[] emptyObjectArray;

		private static readonly Type[] emptyTypeArray;

		internal static List<PhotonView> foundPVs;

		private static readonly Hashtable removeFilter;

		private static readonly Hashtable ServerCleanDestroyEvent;

		private static readonly RaiseEventOptions ServerCleanOptions;

		internal static RaiseEventOptions SendToAllOptions;

		internal static RaiseEventOptions SendToOthersOptions;

		internal static RaiseEventOptions SendToSingleOptions;

		private static readonly Hashtable rpcFilterByViewId;

		private static readonly RaiseEventOptions OpCleanRpcBufferOptions;

		private static Hashtable rpcEvent;

		private static RaiseEventOptions RpcOptionsToAll;

		public static int ObjectsInOneUpdate;

		private static readonly PhotonStream serializeStreamOut;

		private static readonly PhotonStream serializeStreamIn;

		private static RaiseEventOptions serializeRaiseEvOptions;

		private static readonly Dictionary<RaiseEventBatch, SerializeViewBatch> serializeViewBatches;

		public const int SyncViewId = 0;

		public const int SyncCompressed = 1;

		public const int SyncNullValues = 2;

		public const int SyncFirstValue = 3;

		private static RegionHandler _cachedRegionHandler;

		public static bool IsConnectedAndSlave => false;

		public static bool IsConnectedAndMaster => false;

		public static string GameVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string AppVersion => null;

		public static ServerSettings PhotonServerSettings
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public static string ServerAddress => null;

		public static string CloudRegion => null;

		public static string CurrentCluster => null;

		public static string BestRegionSummaryInPreferences
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public static bool IsConnected => false;

		public static bool IsConnectedAndReady => false;

		public static ClientState NetworkClientState => default(ClientState);

		public static ServerConnection Server => default(ServerConnection);

		public static AuthenticationValues AuthValues
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static TypedLobby CurrentLobby => null;

		public static Room CurrentRoom => null;

		public static Player LocalPlayer => null;

		public static string NickName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Player[] PlayerList => null;

		public static Player[] PlayerListOthers => null;

		public static bool OfflineMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool AutomaticallySyncScene
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool EnableLobbyStatistics => false;

		public static bool InLobby => false;

		public static int SendRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int SerializationRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static bool IsMessageQueueRunning
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static double Time => 0.0;

		public static int ServerTimestamp => 0;

		public static float KeepAliveInBackground
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static bool IsMasterClient => false;

		public static Player MasterClient => null;

		public static bool InRoom => false;

		public static int CountOfPlayersOnMaster => 0;

		public static int CountOfPlayersInRooms => 0;

		public static int CountOfPlayers => 0;

		public static int CountOfRooms => 0;

		public static bool NetworkStatisticsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int ResentReliableCommands => 0;

		public static bool CrcCheckEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int PacketLossByCrcCheck => 0;

		public static int MaxResendsBeforeDisconnect
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int QuickResends
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Set port overrides in ServerPortOverrides. Not used anymore!")]
		public static bool UseAlternativeUdpPorts { get; set; }

		public static PhotonPortDefinition ServerPortOverrides
		{
			get
			{
				return default(PhotonPortDefinition);
			}
			set
			{
			}
		}

		[Obsolete("Use PhotonViewCollection instead for an iterable collection of current photonViews.")]
		public static PhotonView[] PhotonViews => null;

		public static NonAllocDictionary<int, PhotonView>.ValueIterator PhotonViewCollection => default(NonAllocDictionary<int, PhotonView>.ValueIterator);

		public static int ViewCount => 0;

		public static IPunPrefabPool PrefabPool
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static float LevelLoadingProgress => 0f;

		private static event Action<PhotonView, Player> OnOwnershipRequestEv
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

		private static event Action<PhotonView, Player> OnOwnershipTransferedEv
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

		private static event Action<PhotonView, Player> OnOwnershipTransferFailedEv
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

		static PhotonNetwork()
		{
		}

		private static void StaticReset()
		{
		}

		public static bool ConnectUsingSettings()
		{
			return false;
		}

		public static bool ConnectUsingSettings(AppSettings appSettings, bool startInOfflineMode = false)
		{
			return false;
		}

		public static bool ConnectToMaster(string masterServerAddress, int port, string appID)
		{
			return false;
		}

		public static bool ConnectToBestCloudServer()
		{
			return false;
		}

		public static bool ConnectToRegion(string region)
		{
			return false;
		}

		public static void Disconnect()
		{
		}

		public static bool Reconnect()
		{
			return false;
		}

		public static void NetworkStatisticsReset()
		{
		}

		public static string NetworkStatisticsToString()
		{
			return null;
		}

		private static bool VerifyCanUseNetwork()
		{
			return false;
		}

		public static int GetPing()
		{
			return 0;
		}

		public static void FetchServerTimestamp()
		{
		}

		public static void SendAllOutgoingCommands()
		{
		}

		public static bool CloseConnection(Player kickPlayer)
		{
			return false;
		}

		public static bool SetMasterClient(Player masterClientPlayer)
		{
			return false;
		}

		public static bool JoinRandomRoom()
		{
			return false;
		}

		public static bool JoinRandomRoom(Hashtable expectedCustomRoomProperties, int expectedMaxPlayers)
		{
			return false;
		}

		public static bool JoinRandomRoom(Hashtable expectedCustomRoomProperties, int expectedMaxPlayers, MatchmakingMode matchingType, TypedLobby typedLobby, string sqlLobbyFilter, string[] expectedUsers = null)
		{
			return false;
		}

		public static bool JoinRandomOrCreateRoom(Hashtable expectedCustomRoomProperties = null, byte expectedMaxPlayers = 0, MatchmakingMode matchingType = MatchmakingMode.FillRoom, TypedLobby typedLobby = null, string sqlLobbyFilter = null, string roomName = null, RoomOptions roomOptions = null, string[] expectedUsers = null)
		{
			return false;
		}

		public static bool CreateRoom(string roomName, RoomOptions roomOptions = null, TypedLobby typedLobby = null, string[] expectedUsers = null)
		{
			return false;
		}

		public static bool JoinOrCreateRoom(string roomName, RoomOptions roomOptions, TypedLobby typedLobby, string[] expectedUsers = null)
		{
			return false;
		}

		public static bool JoinRoom(string roomName, string[] expectedUsers = null)
		{
			return false;
		}

		public static bool RejoinRoom(string roomName)
		{
			return false;
		}

		public static bool ReconnectAndRejoin()
		{
			return false;
		}

		public static bool LeaveRoom(bool becomeInactive = true)
		{
			return false;
		}

		private static void EnterOfflineRoom(string roomName, RoomOptions roomOptions, bool createdRoom)
		{
		}

		public static bool JoinLobby()
		{
			return false;
		}

		public static bool JoinLobby(TypedLobby typedLobby)
		{
			return false;
		}

		public static bool LeaveLobby()
		{
			return false;
		}

		public static bool FindFriends(string[] friendsToFind)
		{
			return false;
		}

		public static bool GetCustomRoomList(TypedLobby typedLobby, string sqlLobbyFilter)
		{
			return false;
		}

		public static bool SetPlayerCustomProperties(Hashtable customProperties)
		{
			return false;
		}

		public static void RemovePlayerCustomProperties(string[] customPropertiesToDelete)
		{
		}

		public static bool RaiseEvent(byte eventCode, object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			return false;
		}

		private static bool RaiseEventInternal(byte eventCode, object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			return false;
		}

		public static bool AllocateViewID(PhotonView view)
		{
			return false;
		}

		[Obsolete("Renamed. Use AllocateRoomViewID instead")]
		public static bool AllocateSceneViewID(PhotonView view)
		{
			return false;
		}

		public static bool AllocateRoomViewID(PhotonView view)
		{
			return false;
		}

		public static int AllocateViewID(bool roomObject)
		{
			return 0;
		}

		public static int AllocateViewID(int ownerId)
		{
			return 0;
		}

		public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
		{
			return null;
		}

		[Obsolete("Renamed. Use InstantiateRoomObject instead")]
		public static GameObject InstantiateSceneObject(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
		{
			return null;
		}

		public static GameObject InstantiateRoomObject(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
		{
			return null;
		}

		private static GameObject NetworkInstantiate(Hashtable networkEvent, Player creator)
		{
			return null;
		}

		private static GameObject NetworkInstantiate(InstantiateParameters parameters, bool roomObject = false, bool instantiateEvent = false)
		{
			return null;
		}

		internal static bool SendInstantiate(InstantiateParameters parameters, bool roomObject = false)
		{
			return false;
		}

		public static void Destroy(PhotonView targetView)
		{
		}

		public static void Destroy(GameObject targetGo)
		{
		}

		public static void DestroyPlayerObjects(Player targetPlayer)
		{
		}

		public static void DestroyPlayerObjects(int targetPlayerId)
		{
		}

		public static void DestroyAll()
		{
		}

		public static void RemoveRPCs(Player targetPlayer)
		{
		}

		public static void RemoveRPCs(PhotonView targetPhotonView)
		{
		}

		internal static void RPC(PhotonView view, string methodName, RpcTarget target, bool encrypt, params object[] parameters)
		{
		}

		internal static void RPC(PhotonView view, string methodName, Player targetPlayer, bool encrypt, params object[] parameters)
		{
		}

		public static void SetInterestGroups(byte group, bool enabled)
		{
		}

		public static void LoadLevel(int levelNumber)
		{
		}

		public static void LoadLevel(string levelName)
		{
		}

		public static bool WebRpc(string name, object parameters, bool sendAuthCookie = false)
		{
			return false;
		}

		private static void SetupLogging()
		{
		}

		public static void LoadOrCreateSettings(bool reload = false)
		{
		}

		public static void AddCallbackTarget(object target)
		{
		}

		public static void RemoveCallbackTarget(object target)
		{
		}

		internal static string CallbacksToString()
		{
			return null;
		}

		private static void LeftRoomCleanup()
		{
		}

		internal static void LocalCleanupAnythingInstantiated(bool destroyInstantiatedGameObjects)
		{
		}

		private static void ResetPhotonViewsOnSerialize()
		{
		}

		internal static void ExecuteRpc(Hashtable rpcData, Player sender)
		{
		}

		private static bool CheckTypeMatch(ParameterInfo[] methodParameters, Type[] callParameterTypes)
		{
			return false;
		}

		public static void DestroyPlayerObjects(int playerId, bool localOnly)
		{
		}

		public static void DestroyAll(bool localOnly)
		{
		}

		internal static void RemoveInstantiatedGO(GameObject go, bool localOnly)
		{
		}

		private static void ServerCleanInstantiateAndDestroy(PhotonView photonView)
		{
		}

		private static void SendDestroyOfPlayer(int actorNr)
		{
		}

		private static void SendDestroyOfAll()
		{
		}

		private static void OpRemoveFromServerInstantiationsOfPlayer(int actorNr)
		{
		}

		internal static void RequestOwnership(int viewID, int fromOwner)
		{
		}

		internal static void TransferOwnership(int viewID, int playerID)
		{
		}

		internal static void OwnershipUpdate(int[] viewOwnerPairs, int targetActor = -1)
		{
		}

		public static bool LocalCleanPhotonView(PhotonView view)
		{
			return false;
		}

		public static PhotonView GetPhotonView(int viewID)
		{
			return null;
		}

		public static void RegisterPhotonView(PhotonView netView)
		{
		}

		public static void OpCleanActorRpcBuffer(int actorNumber)
		{
		}

		public static void OpRemoveCompleteCacheOfPlayer(int actorNumber)
		{
		}

		public static void OpRemoveCompleteCache()
		{
		}

		private static void RemoveCacheOfLeftPlayers()
		{
		}

		public static void CleanRpcBufferIfMine(PhotonView view)
		{
		}

		public static void OpCleanRpcBuffer(PhotonView view)
		{
		}

		public static void RemoveRPCsInGroup(int group)
		{
		}

		public static bool RemoveBufferedRPCs(int viewId = 0, string methodName = null, int[] callersActorNumbers = null)
		{
			return false;
		}

		public static void SetLevelPrefix(byte prefix)
		{
		}

		internal static void RPC(PhotonView view, string methodName, RpcTarget target, Player player, bool encrypt, params object[] parameters)
		{
		}

		public static void SetInterestGroups(byte[] disableGroups, byte[] enableGroups)
		{
		}

		public static void SetSendingEnabled(byte group, bool enabled)
		{
		}

		public static void SetSendingEnabled(byte[] disableGroups, byte[] enableGroups)
		{
		}

		internal static void NewSceneLoaded()
		{
		}

		internal static void RunViewUpdate()
		{
		}

		private static void SendSerializeViewBatch(SerializeViewBatch batch)
		{
		}

		private static List<object> OnSerializeWrite(PhotonView view)
		{
			return null;
		}

		private static void OnSerializeRead(object[] data, Player sender, int networkTime, short correctPrefix)
		{
		}

		private static List<object> DeltaCompressionWrite(List<object> previousContent, List<object> currentContent)
		{
			return null;
		}

		private static object[] DeltaCompressionRead(object[] lastOnSerializeDataReceived, object[] incomingData)
		{
			return null;
		}

		private static bool AlmostEquals(IList<object> lastData, IList<object> currentContent)
		{
			return false;
		}

		private static bool AlmostEquals(object one, object two)
		{
			return false;
		}

		internal static bool GetMethod(MonoBehaviour monob, string methodType, out MethodInfo mi)
		{
			mi = null;
			return false;
		}

		internal static void LoadLevelIfSynced()
		{
		}

		internal static void SetLevelInPropsIfSynced(object levelId)
		{
		}

		private static void OnEvent(EventData photonEvent)
		{
		}

		private static void OnOperation(OperationResponse opResponse)
		{
		}

		private static void OnClientStateChanged(ClientState previousState, ClientState state)
		{
		}

		private static void OnRegionsPinged(RegionHandler regionHandler)
		{
		}
	}
}
