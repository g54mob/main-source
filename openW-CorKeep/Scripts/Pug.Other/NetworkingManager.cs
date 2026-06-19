using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using QFSW.QC;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Networking.Transport.Utilities;
using Unity.Profiling;
using UnityEngine;

public class NetworkingManager : ManagerBase, INetworkStreamDriverConstructor
{
	public enum SideChannel
	{
		None = 0,
		MapData = 1
	}

	public static readonly char[] sessionIdCharacterPool = new char[54]
	{
		'1', '2', '3', '4', '5', '6', '7', '8', '9', 'A',
		'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L',
		'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
		'X', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
		'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't',
		'u', 'v', 'w', 'z'
	};

	public static readonly char[] playerInputtedSessionIdCharacterPool = new char[62]
	{
		'1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
		'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
		'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
		'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
		'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
		'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
		'y', 'z'
	};

	[NonSerialized]
	public string connectionFailedReason;

	private string _currentJoinString;

	private string currentSessionId;

	public bool UseSecondaryNetworking;

	[ClearOnReload]
	public static bool UseDirectConnection = false;

	private NetworkingInterface _mainNetworkImpl;

	private NetworkingInterface _secondaryNetworkImpl;

	private PugNetworkInterface clientNetIf;

	private PugNetworkInterface serverNetIf;

	private List<PugNetworkInterface> thinClientsNetIfs = new List<PugNetworkInterface>();

	private List<QueuedSendMessage> localFromClient = new List<QueuedSendMessage>();

	private List<QueuedSendMessage> localFromServer = new List<QueuedSendMessage>();

	private List<List<QueuedSendMessage>> thinClientLocalFromServer = new List<List<QueuedSendMessage>>();

	private Dictionary<SideChannel, Action<byte[]>> serverSideChannelHandlers = new Dictionary<SideChannel, Action<byte[]>>();

	private Dictionary<SideChannel, Action<byte[]>> clientSideChannelHandlers = new Dictionary<SideChannel, Action<byte[]>>();

	private NetworkPipeline _reliablePipeline;

	public string pendingJoin;

	private int playerBanCount;

	private PlayerBanList playerBanList = new PlayerBanList
	{
		banList = new List<PlayerBanEntry>()
	};

	private int adminCount;

	private AdminList adminList = new AdminList
	{
		adminList = new List<PlayerAdminEntry>()
	};

	private const int DummyLoopBackport = 7777;

	private NetworkEndpoint localEndpoint = NetworkEndpoint.LoopbackIpv4.WithPort(7777);

	private bool wasPlayerInputDisabled;

	private uint _maxPredictAheadTimeMS = 500u;

	private bool _initialized;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("NetworkingManager.Init");

	public const int MinSendImportance = 5;

	public bool hasNetwork { get; set; }

	public bool isConnected { get; set; }

	public string serverName { get; set; }

	public string serverGuid { get; set; }

	public string serverSessionId { get; set; }

	public WorldMode serverWorldMode { get; set; }

	public bool serverIsModded { get; set; }

	public bool serverHasStreamIntegration { get; set; }

	public bool isCheckingPrivileges { get; set; }

	public bool connectionFailed { get; set; }

	public bool connectionFailedWithCrossplayErrorClient { get; set; }

	public bool connectionFailedWithCrossplayErrorHost { get; set; }

	private float lastRttUpdate { get; set; }

	public float rttToServer { get; set; }

	public ServerConnectionInfo CurrentSession
	{
		get
		{
			if (impl == null)
			{
				return default(ServerConnectionInfo);
			}
			return impl.CurrentSession;
		}
	}

	public string CurrentSessionID => CurrentSession.PasswordGameID;

	public bool currentSessionIsDedicatedServer
	{
		get
		{
			if (hasNetwork && impl != null)
			{
				return impl.ConnectedToDedicatedServer;
			}
			return false;
		}
	}

	public Platform AllowedPlatforms => impl.AllowedPlatforms;

	public int MaxPlayersCount => impl.MaxPlayersCount;

	public bool OfflineSession { get; set; }

	public bool CanSendInvites => impl.CanSendInvites;

	public bool SupportsDirectConnection
	{
		get
		{
			if (CurrentSession != default(ServerConnectionInfo))
			{
				return CurrentSession.SupportsDirectConnection;
			}
			return false;
		}
	}

	private NetworkingInterface impl
	{
		get
		{
			if ((!UseSecondaryNetworking || _secondaryNetworkImpl == null) && _mainNetworkImpl != null)
			{
				return _mainNetworkImpl;
			}
			return _secondaryNetworkImpl;
		}
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			if (UnsafeUtility.SizeOf<ClientInput>() != UnsafeUtility.SizeOf<ClientInputData>())
			{
				Debug.LogError($"ClientInput and ClientInputData are not the same size!: ClientInput size={UnsafeUtility.SizeOf<ClientInput>()} vs ClientInputData size={UnsafeUtility.SizeOf<ClientInputData>()}");
				return false;
			}
			clientNetIf = default(PugNetworkInterface);
			serverNetIf = default(PugNetworkInterface);
			clientNetIf.LocalEndpoint = localEndpoint;
			serverNetIf.LocalEndpoint = localEndpoint;
			NetworkStreamReceiveSystem.DriverConstructor = this;
			ResetConnectSettings();
			Manager.platform.AddJoinRequestHandler(ProcessJoinRequest);
			NetImplInit();
			_initialized = true;
			return true;
		}
	}

	[Command("triggerPlayFabError", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void TriggerPlayFabError(int errorCode)
	{
		if (impl is PlayFabPartyNetworking playFabPartyNetworking)
		{
			playFabPartyNetworking.Debug_TriggerError(errorCode);
		}
	}

	private void NetImplInit()
	{
		_secondaryNetworkImpl = new PlayFabPartyNetworking();
		_mainNetworkImpl = new SteamNetworking();
		hasNetwork = true;
		if (_secondaryNetworkImpl != null)
		{
			hasNetwork = _secondaryNetworkImpl.Initialize(ProcessDisconnect, HandleSideChannelMessage, UseDirectConnection, Manager.platform.Platform);
		}
		if (_mainNetworkImpl != null)
		{
			hasNetwork &= _mainNetworkImpl.Initialize(ProcessDisconnect, HandleSideChannelMessage, UseDirectConnection, Manager.platform.Platform);
		}
		clientNetIf.LocalEndpoint = localEndpoint;
		serverNetIf.LocalEndpoint = localEndpoint;
		NetworkStreamReceiveSystem.DriverConstructor = this;
		ResetConnectSettings();
		FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.PlayerBanList, 0);
		if (file.Exists())
		{
			byte[] bytes = file.Read();
			try
			{
				JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(bytes), playerBanList);
			}
			catch (Exception exception)
			{
				playerBanList.banList = new List<PlayerBanEntry>();
				Debug.LogError("Failed to parse serialized player ban list");
				Debug.LogException(exception);
			}
		}
		for (int i = 0; i < playerBanList.banList.Count; i++)
		{
			impl.InitializeBan(playerBanList.banList[i]);
			playerBanCount = math.max(playerBanCount, playerBanList.banList[i].index + 1);
		}
		FilesystemManager.File file2 = new FilesystemManager.File(FilesystemManager.FileID.AdminList, 0);
		if (file2.Exists())
		{
			byte[] bytes2 = file2.Read();
			try
			{
				JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(bytes2), adminList);
			}
			catch (Exception exception2)
			{
				adminList.adminList = new List<PlayerAdminEntry>();
				Debug.LogError("Failed to parse serialized admin list");
				Debug.LogException(exception2);
			}
		}
		List<PlayerAdminEntry> list = (from admin in adminList.adminList
			group admin by admin.steamId into @group
			select @group.First()).ToList();
		adminList.adminList = list;
		WriteAdminList();
		for (int num = 0; num < adminList.adminList.Count; num++)
		{
			adminCount = math.max(adminCount, adminList.adminList[num].index + 1);
		}
	}

	public override void Deinit()
	{
		if (_initialized)
		{
			impl.Deinitialize();
			WriteBanList();
			WriteAdminList();
			base.Deinit();
		}
	}

	public static bool TryGetThinClientIndexFromWorld(World world, out int index)
	{
		index = 0;
		if (!int.TryParse(world.Name.Replace("ThinClientWorld", ""), out index))
		{
			Debug.LogError("Failed parse thin client number");
			return false;
		}
		return true;
	}

	public NetworkEndpoint GetLocalEndpoint()
	{
		return localEndpoint;
	}

	private NetworkDriver GetDriverForWorld(World world)
	{
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(WorldNetworkDriver));
		return entityQuery.GetSingleton<WorldNetworkDriver>().driver;
	}

	private void WriteBanList()
	{
		string s = JsonUtility.ToJson(playerBanList, prettyPrint: true);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		Manager.filesystemManager.Write(new FilesystemManager.File(FilesystemManager.FileID.PlayerBanList, 0), bytes);
	}

	private void WriteAdminList()
	{
		string s = JsonUtility.ToJson(adminList, prettyPrint: true);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		Manager.filesystemManager.Write(new FilesystemManager.File(FilesystemManager.FileID.AdminList, 0), bytes);
	}

	public void ResetConnectSettings()
	{
		serverHasStreamIntegration = false;
		serverIsModded = false;
		isConnected = false;
		connectionFailed = false;
		serverGuid = null;
		serverSessionId = null;
		rttToServer = 0f;
	}

	public string GenerateSessionId(int length)
	{
		char[] array = sessionIdCharacterPool;
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < stringBuilder.Capacity; i++)
		{
			stringBuilder.Append(array[UnityEngine.Random.Range(0, array.Length)]);
		}
		return stringBuilder.ToString();
	}

	public bool IsValidSessionId(string sessionID)
	{
		foreach (char value in sessionID)
		{
			if (!playerInputtedSessionIdCharacterPool.Contains(value))
			{
				Debug.LogWarning("Session ID contains invalid characters!");
				return false;
			}
		}
		return true;
	}

	private void ConnectClientWorld(string name, ServerConnectionInfo address, Action<bool> callback)
	{
		if (address == default(ServerConnectionInfo))
		{
			InitializeConnection(localEndpoint, Manager.ecs.ClientWorld);
			callback?.Invoke(obj: true);
			return;
		}
		UseSecondaryNetworking = _mainNetworkImpl == null || !_mainNetworkImpl.IsValidConnectionAddress(address);
		Debug.Log($"Client connecting to session {address}");
		if (!impl.isInitialized)
		{
			connectionFailedReason = "Error/NoNetwork";
			callback?.Invoke(obj: false);
			return;
		}
		impl.Connect(address, delegate(NetworkEndpoint? ep)
		{
			if (ep.HasValue && Manager.ecs.ClientWorld != null)
			{
				InitializeConnection(ep.Value, Manager.ecs.ClientWorld);
				callback?.Invoke(obj: true);
			}
			else
			{
				callback?.Invoke(obj: false);
			}
		});
	}

	public void Connect(ServerConnectionInfo connectionInfo, Action<bool> callback)
	{
		ConnectClientWorld("ClientWorld0", connectionInfo, callback);
	}

	public void StartServer(World world)
	{
		NetworkEndpoint endpoint = NetworkEndpoint.AnyIpv4.WithPort(7777);
		UseSecondaryNetworking = Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false);
		if (OfflineSession || !impl.isInitialized)
		{
			Debug.Log("No network; Server is local only");
		}
		else
		{
			int maxNumberPlayers = Manager.prefs.serverMaxNumberPlayers;
			if (PlatformConfiguration.Instance != null)
			{
				maxNumberPlayers = PlatformConfiguration.Instance.SessionConfiguration.MaxNumberOfPlayers;
			}
			ServerConnectionInfo connectionInfo = new ServerConnectionInfo
			{
				GameID = Manager.prefs.serverGameId,
				Password = (UseDirectConnection ? Manager.prefs.serverPassword : null),
				JoinedWithIP = UseDirectConnection
			};
			if (!impl.StartListening())
			{
				Debug.LogError("Failed to create listen socket");
			}
			else if (!impl.StartSession(connectionInfo, maxNumberPlayers, HandleStartSession))
			{
				Debug.LogError("Failed to start session");
			}
		}
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(NetworkStreamDriver));
		entityQuery.GetSingleton<NetworkStreamDriver>().Listen(endpoint);
	}

	public void StopClient(World world)
	{
		if (world != null)
		{
			Disconnect(world);
		}
		if (impl != null && impl.isInitialized)
		{
			impl.Disconnect();
		}
		ResetConnectSettings();
	}

	public void StopServer(World world)
	{
		if (impl.isInitialized)
		{
			impl.StopSession();
			impl.StopListening();
		}
		Disconnect(world);
	}

	public void RecreateGameID(World world)
	{
		if (world.IsClient())
		{
			EntityManager entityManager = world.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
			entityManager.SetComponentData(entity, new NetworkCommandRpc
			{
				command = NetworkCommand.RecreateGameId
			});
		}
		else
		{
			EntityManager entityManager2 = world.EntityManager;
			Entity entity2 = entityManager2.CreateEntity(typeof(NetworkCommandRpc));
			entityManager2.SetComponentData(entity2, new NetworkCommandRpc
			{
				command = NetworkCommand.RecreateGameId
			});
		}
	}

	internal void RecreateGameIDInternal()
	{
		impl.RecreateGameId(HandleStartSession);
	}

	public void BanPlayer(PlayerController pc, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.PlayerBan,
			entity0 = pc.entity
		});
	}

	public void UnbanPlayer(int banIndex, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.PlayerUnban,
			int0 = banIndex
		});
	}

	internal int BanPlayerInternal(string playerName, Entity connectionEntity, World world, ulong onlineId)
	{
		if (!world.EntityManager.HasComponent<NetworkStreamConnection>(connectionEntity))
		{
			Debug.LogError("BanPlayerInternal: no NetworkStreamConnection");
			return -1;
		}
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		PlayerBanEntry playerBanEntry = new PlayerBanEntry
		{
			Name = playerName
		};
		playerBanEntry.steamId = onlineId;
		impl.BanPlayer(remoteEndpoint, ref playerBanEntry);
		if (!playerBanEntry.IsValid())
		{
			return -1;
		}
		if (playerBanList.banList.Contains(playerBanEntry))
		{
			int index = playerBanList.banList.IndexOf(playerBanEntry);
			PlayerBanEntry value2 = playerBanList.banList[index];
			if (value2.crossPlatformId == 0L)
			{
				value2.crossPlatformId = playerBanEntry.crossPlatformId;
			}
			if (value2.steamId == 0L)
			{
				value2.steamId = playerBanEntry.steamId;
			}
			playerBanList.banList[index] = value2;
			return playerBanList.banList[index].index;
		}
		playerBanEntry.index = ++playerBanCount;
		playerBanList.banList.Add(playerBanEntry);
		WriteBanList();
		return playerBanEntry.index;
	}

	internal void UnbanPlayerInternal(int index)
	{
		for (int num = playerBanList.banList.Count - 1; num >= 0; num--)
		{
			if (playerBanList.banList[num].index == index)
			{
				impl.UnbanPlayer(playerBanList.banList[num]);
				playerBanList.banList.RemoveAt(num);
			}
		}
		WriteBanList();
	}

	internal IEnumerable<PlayerBanEntry> GetBansInternal()
	{
		return playerBanList.banList;
	}

	public int GetAdminCount()
	{
		return adminList.adminList.Count;
	}

	internal IEnumerable<PlayerAdminEntry> GetAdminsInternal()
	{
		return adminList.adminList;
	}

	internal string GetConnectionId(Entity connectionEntity, World world)
	{
		if (!impl.isInitialized)
		{
			return "local";
		}
		if (!world.EntityManager.HasComponent<NetworkStreamConnection>(connectionEntity))
		{
			Debug.LogError("GetConnectionId: no NetworkStreamConnection");
			return null;
		}
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		return impl.GetConnectionId(remoteEndpoint);
	}

	public void AddAdmin(PlayerController pc, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.AddOrUpdateAdmin,
			entity0 = pc.entity
		});
	}

	public void RemoveAdmin(int adminIndex, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.RemoveAdmin,
			int0 = adminIndex
		});
	}

	public void RemoveAdmin(PlayerController pc, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.RemoveAdmin,
			entity0 = pc.entity
		});
	}

	public void SetGuestMode(bool value, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.SetGuestMode,
			int0 = (value ? 1 : 0)
		});
	}

	public void ChangePvPTeam(PlayerController pc, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.ChangePvPTeam,
			entity0 = pc.entity
		});
		try
		{
			if (Manager.ecs.ServerWorld != null && !Manager.ecs.ServerConnectionQ.IsEmpty && EntityUtility.HasComponentData<FactionCD>(pc.entity, pc.world) && Manager.ecs.ServerConnectionQ.CalculateEntityCount() == 1)
			{
				FactionCD componentData = EntityUtility.GetComponentData<FactionCD>(pc.entity, pc.world);
				componentData.ChangePvPTeam();
				EntityUtility.SetComponentData(pc.entity, pc.world, componentData);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public void SetPvPMode(bool value, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.SetPvPMode,
			int0 = (value ? 1 : 0)
		});
	}

	public void SetDisableSimulation(bool value, World world)
	{
		EntityManager entityManager = world.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(NetworkCommandRpc), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity, new NetworkCommandRpc
		{
			command = NetworkCommand.SetDisableSimulation,
			int0 = (value ? 1 : 0)
		});
	}

	internal int AddAdminInternal(string playerName, Entity connectionEntity, World world, int privileges, ulong onlineId)
	{
		if (!world.EntityManager.HasComponent<NetworkStreamConnection>(connectionEntity))
		{
			Debug.LogError("AddAdminInternal: no NetworkStreamConnection");
			return -1;
		}
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		if (remoteEndpoint.Equals(localEndpoint))
		{
			remoteEndpoint = impl.GetLocalEndpoint();
		}
		PlayerAdminEntry adminEntry = new PlayerAdminEntry
		{
			Name = playerName,
			privileges = privileges
		};
		adminEntry.steamId = onlineId;
		impl.SetAdmin(remoteEndpoint, ref adminEntry);
		if (!adminEntry.IsValid())
		{
			return -1;
		}
		if (adminList.adminList.Contains(adminEntry))
		{
			return adminList.adminList[adminList.adminList.IndexOf(adminEntry)].index;
		}
		adminEntry.index = ++adminCount;
		adminList.adminList.Add(adminEntry);
		UpdatePlayerAdminFlag();
		WriteAdminList();
		return adminEntry.index;
	}

	internal int RemoveAdminInternal(Entity connectionEntity, World world)
	{
		int result = -1;
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		for (int num = adminList.adminList.Count - 1; num >= 0; num--)
		{
			if (adminList.adminList[num].privileges <= 1 && impl.EntryMatchesEndpoint(adminList.adminList[num], remoteEndpoint))
			{
				result = adminList.adminList[num].index;
				adminList.adminList.RemoveAt(num);
				break;
			}
		}
		UpdatePlayerAdminFlag();
		WriteAdminList();
		return result;
	}

	public void EmptyAdminAndBan()
	{
		adminList.adminList = new List<PlayerAdminEntry>();
		WriteAdminList();
		for (int num = playerBanList.banList.Count - 1; num >= 0; num--)
		{
			impl?.UnbanPlayer(playerBanList.banList[num]);
			playerBanList.banList.RemoveAt(num);
		}
		WriteBanList();
	}

	internal bool RemoveAdminInternal(int index)
	{
		bool flag = false;
		for (int num = adminList.adminList.Count - 1; num >= 0; num--)
		{
			if (adminList.adminList[num].privileges <= 1 && adminList.adminList[num].index == index)
			{
				flag = true;
				adminList.adminList.RemoveAt(num);
			}
		}
		if (flag)
		{
			UpdatePlayerAdminFlag();
		}
		WriteAdminList();
		return flag;
	}

	private void UpdatePlayerAdminFlag()
	{
		using EntityQuery entityQuery = Manager.ecs.ServerWorld.EntityManager.CreateEntityQuery(typeof(PlayerGhost));
		using NativeArray<Entity> nativeArray = entityQuery.ToEntityArray(Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			PlayerGhost componentData = Manager.ecs.ServerWorld.EntityManager.GetComponentData<PlayerGhost>(nativeArray[i]);
			componentData.adminPrivileges = GetAdminPrivileges(componentData.connection, Manager.ecs.ServerWorld, componentData.onlineId);
			Manager.ecs.ServerWorld.EntityManager.SetComponentData(nativeArray[i], componentData);
		}
		using EntityQuery entityQuery2 = Manager.ecs.ServerWorld.EntityManager.CreateEntityQuery(typeof(ConnectionAdminLevelCD));
		using NativeArray<Entity> nativeArray2 = entityQuery2.ToEntityArray(Allocator.Temp);
		for (int j = 0; j < nativeArray2.Length; j++)
		{
			ConnectionAdminLevelCD componentData2 = Manager.ecs.ServerWorld.EntityManager.GetComponentData<ConnectionAdminLevelCD>(nativeArray2[j]);
			componentData2.adminPrivileges = GetAdminPrivileges(nativeArray2[j], Manager.ecs.ServerWorld, componentData2.onlineId);
			Manager.ecs.ServerWorld.EntityManager.SetComponentData(nativeArray2[j], componentData2);
		}
	}

	public void UpdateGameId(string gameId, int maxPlayersCount)
	{
		impl.UpdateSession(gameId, maxPlayersCount);
	}

	public void OnPlayerConnect(string playerName, Entity connectionEntity, World world, bool isLocalPlayer)
	{
		if (impl.isInitialized)
		{
			Debug.Log($"[userid:{GetConnectionId(connectionEntity, world)}] player {playerName} connected islocalplayer={isLocalPlayer}");
			if (adminList.adminList.Count == 0 || isLocalPlayer)
			{
				AddAdminInternal(playerName, connectionEntity, world, 2, Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId());
			}
			OnPlayerNameChange(playerName, connectionEntity, world);
		}
	}

	public void OnPlayerNameChange(string playerName, Entity connectionEntity, World world)
	{
		if (!impl.isInitialized)
		{
			return;
		}
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		if (remoteEndpoint.Equals(localEndpoint))
		{
			remoteEndpoint = impl.GetLocalEndpoint();
		}
		PlayerAdminEntry adminEntry = default(PlayerAdminEntry);
		impl.SetAdmin(remoteEndpoint, ref adminEntry);
		for (int i = 0; i < adminList.adminList.Count; i++)
		{
			if (adminList.adminList[i].Equals(adminEntry))
			{
				if (!string.Equals(adminEntry.Name, playerName))
				{
					Debug.Log("[userid:" + GetConnectionId(connectionEntity, world) + "] is using new name " + playerName);
					adminEntry = adminList.adminList[i];
					adminEntry.Name = playerName;
					adminList.adminList[i] = adminEntry;
					world.GetExistingSystemManaged<NetworkCommandServerSystem>().UpdateNames();
				}
				break;
			}
		}
	}

	internal int GetAdminPrivileges(Entity connectionEntity, World world, ulong platformSpecificUserId = 0uL)
	{
		if (!impl.isInitialized || OfflineSession)
		{
			return int.MaxValue;
		}
		if (!world.EntityManager.HasComponent<NetworkStreamConnection>(connectionEntity))
		{
			Debug.LogError("CheckIfAdminInternal: no NetworkStreamConnection");
			return 0;
		}
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		return GetAdminPrivileges(remoteEndpoint, platformSpecificUserId);
	}

	internal int GetAdminPrivileges(NetworkEndpoint dest, ulong platformSpecificUserId = 0uL)
	{
		if (dest.Equals(localEndpoint))
		{
			dest = impl.GetLocalEndpoint();
		}
		PlayerAdminEntry adminEntry = default(PlayerAdminEntry);
		if (platformSpecificUserId != 0L)
		{
			adminEntry.steamId = platformSpecificUserId;
		}
		impl.SetAdmin(dest, ref adminEntry);
		for (int i = 0; i < adminList.adminList.Count; i++)
		{
			if (adminList.adminList[i].Equals(adminEntry))
			{
				PlayerAdminEntry value = adminList.adminList[i];
				if (value.crossPlatformId == 0L && adminEntry.crossPlatformId != 0L)
				{
					value.crossPlatformId = adminEntry.crossPlatformId;
					adminList.adminList[i] = value;
					WriteAdminList();
				}
				return value.privileges;
			}
		}
		return 0;
	}

	public void InitWorld(World world)
	{
		SetNetworkTickRates(world);
		if (WorldExtensions.GetExistingSystem<GhostSendSystem>(world) != SystemHandle.Null)
		{
			using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(GhostSendSystemData));
			entityQuery.GetSingletonRW<GhostSendSystemData>().ValueRW.MinSendImportance = 5;
			entityQuery.GetSingletonRW<GhostSendSystemData>().ValueRW.IrrelevantImportanceDownScale = 2;
			entityQuery.GetSingletonRW<GhostSendSystemData>().ValueRW.FirstSendImportanceMultiplier = 10u;
			entityQuery.GetSingletonRW<GhostSendSystemData>().ValueRW.KeepSnapshotHistoryOnStructuralChange = false;
		}
		SystemHandle existingSystem = WorldExtensions.GetExistingSystem<GhostOwnerPredictionSwitchingSystem>(world);
		if (existingSystem != SystemHandle.Null)
		{
			world.Unmanaged.ResolveSystemStateRef(existingSystem).Enabled = false;
		}
		if (Manager.ecs.ServerWorld == null)
		{
			world.EntityManager.CreateSingleton(new LagCompensationConfig
			{
				ServerHistorySize = 10,
				ClientHistorySize = 10
			});
		}
		else
		{
			world.EntityManager.CreateSingleton(new LagCompensationConfig
			{
				ServerHistorySize = 10,
				ClientHistorySize = 1
			});
		}
	}

	public void SetNetworkTickRates(World world, int overrideSimulationRate = 0, int overrideNetworkSendRate = 0)
	{
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(ClientServerTickRate));
		world.EntityManager.DestroyEntity(entityQuery);
		Entity entity = world.EntityManager.CreateEntity(typeof(ClientServerTickRate));
		ClientServerTickRate componentData = default(ClientServerTickRate);
		componentData.ResolveDefaults();
		int upperBound = (componentData.SimulationTickRate = ((overrideSimulationRate > 0) ? overrideSimulationRate : PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate));
		int valueToClamp = ((overrideNetworkSendRate > 0) ? overrideNetworkSendRate : PlatformConfiguration.Instance.SessionConfiguration.NetworkSendRate);
		componentData.NetworkTickRate = math.clamp(valueToClamp, 0, upperBound);
		componentData.MaxSimulationStepsPerFrame = 1;
		componentData.MaxSimulationStepBatchSize = 1;
		Debug.Log($"Simulation tick rate={componentData.SimulationTickRate} Network tick rate={componentData.NetworkTickRate}");
		world.EntityManager.SetComponentData(entity, componentData);
	}

	[Command("setUsePredictionBackup", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void SetUsePredictionBackup(bool value)
	{
		World clientWorld = Manager.ecs.ClientWorld;
		if (clientWorld == null)
		{
			return;
		}
		using EntityQuery entityQuery = clientWorld.EntityManager.CreateEntityQuery(typeof(GhostUpdateSystem.GhostUpdateSystemData));
		entityQuery.GetSingletonRW<GhostUpdateSystem.GhostUpdateSystemData>().ValueRW.ForceDontUsePredictionBackup = !value;
	}

	[Command("setPartialTickRounding", "when to round partial ticks to full tick (within percentage of full, max 50)", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void SetPartialTickRounding(int value)
	{
		World clientWorld = Manager.ecs.ClientWorld;
		if (clientWorld != null)
		{
			EntityQuery entityQuery = clientWorld.EntityManager.CreateEntityQuery(typeof(ClientServerTickRate));
			entityQuery.GetSingletonRW<ClientServerTickRate>().ValueRW.ClampPartialTicksThreshold = value;
			entityQuery.Dispose();
			clientWorld = Manager.ecs.ServerWorld;
			if (clientWorld != null)
			{
				entityQuery = clientWorld.EntityManager.CreateEntityQuery(typeof(ClientServerTickRate));
				entityQuery.GetSingletonRW<ClientServerTickRate>().ValueRW.ClampPartialTicksThreshold = value;
				entityQuery.Dispose();
			}
		}
	}

	public void Disconnect(World world)
	{
		NetworkDriver driverForWorld = GetDriverForWorld(world);
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(NetworkStreamConnection));
		foreach (NetworkStreamConnection item in entityQuery.ToComponentDataArray<NetworkStreamConnection>(Allocator.Temp))
		{
			driverForWorld.Disconnect(item.Value);
		}
		driverForWorld.ScheduleFlushSend().Complete();
	}

	private void InitializeConnection(NetworkEndpoint ep, World world)
	{
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(ClientTickRate));
		world.EntityManager.DestroyEntity(entityQuery);
		Entity entity = world.EntityManager.CreateEntity(typeof(ClientTickRate));
		ClientTickRate defaultClientTickRate = NetworkTimeSystem.DefaultClientTickRate;
		defaultClientTickRate.MaxExtrapolationTimeSimTicks = 6u;
		defaultClientTickRate.MaxPredictAheadTimeMS = _maxPredictAheadTimeMS;
		world.EntityManager.SetComponentData(entity, defaultClientTickRate);
		using EntityQuery entityQuery2 = world.EntityManager.CreateEntityQuery(typeof(NetworkStreamDriver));
		entityQuery2.GetSingleton<NetworkStreamDriver>().Connect(world.EntityManager, ep);
		SetUsePredictionBackup(value: false);
		Debug.Log("Client connected");
	}

	[Command("SetMaxPredictedAheadTimeMS", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetMaxPredictedAheadTimeMS(uint value)
	{
		Manager.networking._maxPredictAheadTimeMS = value;
		foreach (World item in World.All)
		{
			if (!item.IsClient())
			{
				continue;
			}
			using EntityQuery entityQuery = item.EntityManager.CreateEntityQuery(typeof(ClientTickRate));
			if (entityQuery.IsEmpty)
			{
				break;
			}
			entityQuery.GetSingletonRW<ClientTickRate>().ValueRW.MaxPredictAheadTimeMS = value;
		}
	}

	[Command("SetMaxPredictionStepBatchRepeated", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetMaxPredictionStepBatchRepeated(int value)
	{
		foreach (World item in World.All)
		{
			if (!item.IsClient())
			{
				continue;
			}
			using EntityQuery entityQuery = item.EntityManager.CreateEntityQuery(typeof(ClientTickRate));
			if (entityQuery.IsEmpty)
			{
				break;
			}
			entityQuery.GetSingletonRW<ClientTickRate>().ValueRW.MaxPredictionStepBatchSizeRepeatedTick = value;
		}
	}

	[Command("SetMaxPredictionStepBatchFirst", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetMaxPredictionStepBatchFirst(int value)
	{
		foreach (World item in World.All)
		{
			if (!item.IsClient())
			{
				continue;
			}
			using EntityQuery entityQuery = item.EntityManager.CreateEntityQuery(typeof(ClientTickRate));
			if (entityQuery.IsEmpty)
			{
				break;
			}
			entityQuery.GetSingletonRW<ClientTickRate>().ValueRW.MaxPredictionStepBatchSizeFirstTimeTick = value;
		}
	}

	[Command("SetCommandSlack", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetCommandSlack(uint value)
	{
		foreach (World item in World.All)
		{
			if (!item.IsClient())
			{
				continue;
			}
			using EntityQuery entityQuery = item.EntityManager.CreateEntityQuery(typeof(ClientTickRate));
			if (entityQuery.IsEmpty)
			{
				break;
			}
			entityQuery.GetSingletonRW<ClientTickRate>().ValueRW.TargetCommandSlack = value;
		}
	}

	private void Update()
	{
		if (!string.IsNullOrEmpty(pendingJoin) && Manager.sceneHandler.isTitle && !Manager.load.IsLoading())
		{
			string sessionId = pendingJoin;
			pendingJoin = null;
			Manager.menu.PopAllMenus();
			OfflineSession = false;
			JoinSessionDirect(sessionId, checkPrivileges: true);
		}
		if (impl != null && impl.isInitialized)
		{
			impl.Update();
			if (Manager.ecs.ServerWorld == null && Manager.ecs.ClientWorld != null)
			{
				if (Time.realtimeSinceStartup - lastRttUpdate > 1f)
				{
					lastRttUpdate = Time.realtimeSinceStartup;
					rttToServer = impl.GetPing();
				}
			}
			else
			{
				rttToServer = 0f;
			}
		}
		string currentJoinString = _currentJoinString;
		_currentJoinString = (Manager.prefs.allowJoinByPresence ? CurrentSessionID : null);
		if (_currentJoinString != currentJoinString || (Manager.prefs.allowJoinByPresence && Manager.platform.forcePresenceJoinStringUpdate))
		{
			if (Manager.platform.forcePresenceJoinStringUpdate)
			{
				Manager.platform.forcePresenceJoinStringUpdate = false;
			}
			Manager.platform.joinString = _currentJoinString;
		}
		if (Manager.sceneHandler != null && Manager.sceneHandler.isTitle && connectionFailedWithCrossplayErrorHost)
		{
			RadicalMenu topMenu = Manager.menu.GetTopMenu();
			if (!(topMenu != null) || topMenu is RadicalPopUpMenu)
			{
				return;
			}
			connectionFailedWithCrossplayErrorHost = false;
			if (!Manager.prefs.crossPlay)
			{
				return;
			}
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/DisableCrossplay", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
			{
				if (response.IsConfirm)
				{
					Manager.prefs.crossPlay = false;
				}
			}, new List<string> { "cancelDialogue", "yes" }, 10f, 0.8f, 0, 20f);
		}
		else if (Manager.sceneHandler != null && Manager.sceneHandler.isTitle && connectionFailedWithCrossplayErrorClient)
		{
			RadicalMenu topMenu2 = Manager.menu.GetTopMenu();
			if (topMenu2 != null && !(topMenu2 is RadicalPopUpMenu))
			{
				connectionFailedWithCrossplayErrorClient = false;
				Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/HostDisableCrossplay", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
				{
				}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
			}
		}
	}

	public void ClientNetworkUpdate(World world)
	{
		if (world != null && Manager.ecs.ServerWorld != null && serverNetIf.CanSendAndReceiveBeCompletedWithoutWaiting())
		{
			ServerNetworkUpdate(null);
		}
		PugNetworkInterface pugNetworkInterface = clientNetIf;
		List<QueuedSendMessage> list = localFromServer;
		pugNetworkInterface.CompleteSend();
		impl.SendMessages(pugNetworkInterface.sendQueue);
		QueuedSendMessage item;
		while (pugNetworkInterface.localQueue.TryDequeue(out item))
		{
			if (serverNetIf.IsCreated)
			{
				localFromClient.Add(item);
			}
		}
		pugNetworkInterface.CompleteReceive();
		foreach (QueuedSendMessage item2 in list)
		{
			pugNetworkInterface.receiveQueue.Enqueue(item2);
		}
		list.Clear();
		if (Manager.ecs.ServerWorld == null)
		{
			impl.ReceiveMessages(pugNetworkInterface.receiveQueue);
		}
	}

	public void ServerNetworkUpdate(World world)
	{
		if (world != null && Manager.ecs.ClientWorld != null && clientNetIf.CanSendAndReceiveBeCompletedWithoutWaiting())
		{
			ClientNetworkUpdate(null);
		}
		serverNetIf.CompleteSend();
		impl.SendMessages(serverNetIf.sendQueue);
		QueuedSendMessage item;
		while (serverNetIf.localQueue.TryDequeue(out item))
		{
			if (clientNetIf.IsCreated)
			{
				localFromServer.Add(item);
			}
		}
		serverNetIf.CompleteReceive();
		foreach (QueuedSendMessage item2 in localFromClient)
		{
			serverNetIf.receiveQueue.Enqueue(item2);
		}
		localFromClient.Clear();
		impl.ReceiveMessages(serverNetIf.receiveQueue);
	}

	private void ProcessDisconnect(NetworkEndpoint endpoint)
	{
		World world;
		if (Manager.ecs.ServerWorld != null && !serverNetIf.LocalEndpoint.Equals(endpoint))
		{
			world = Manager.ecs.ServerWorld;
			_ = serverNetIf;
		}
		else
		{
			if (Manager.ecs.ClientWorld == null || clientNetIf.LocalEndpoint.Equals(endpoint))
			{
				return;
			}
			world = Manager.ecs.ClientWorld;
			_ = clientNetIf;
		}
		world.EntityManager.CompleteAllTrackedJobs();
		NetworkDriver driverForWorld = GetDriverForWorld(world);
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		entityQueryBuilder = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		using EntityQuery entityQuery = entityQueryBuilder.Build(world.EntityManager);
		using NativeArray<Entity> nativeArray = entityQuery.ToEntityArray(Allocator.Temp);
		using NativeArray<NetworkStreamConnection> nativeArray2 = entityQuery.ToComponentDataArray<NetworkStreamConnection>(Allocator.Temp);
		for (int i = 0; i < nativeArray2.Length; i++)
		{
			if (driverForWorld.GetRemoteEndpoint(nativeArray2[i].Value) == endpoint)
			{
				world.EntityManager.AddComponentData(nativeArray[i], new NetworkStreamRequestDisconnect
				{
					Reason = NetworkStreamDisconnectReason.ConnectionClose
				});
				break;
			}
		}
	}

	private void ProcessJoinRequest(string joinString)
	{
		Debug.Log("Got join request from platform: " + joinString);
		if (string.IsNullOrEmpty(joinString))
		{
			return;
		}
		if (impl != null && !impl.CheckSessionValidity(joinString))
		{
			Debug.LogWarning("Trying to join a session you are already in. Returning.");
			return;
		}
		OfflineSession = false;
		pendingJoin = joinString;
		if (Manager.sceneHandler != null && (Manager.sceneHandler.isInGame || Manager.sceneHandler.isIntro || Manager.load.IsLoading()))
		{
			Manager.load.ExitGame(FadePresets.cut);
		}
	}

	public void AddSideChannelHandler(SideChannel sideChannel, bool isServer, Action<byte[]> handler)
	{
		if (isServer)
		{
			if (serverSideChannelHandlers.ContainsKey(sideChannel))
			{
				Debug.LogError("Duplicate handlers for side channel " + sideChannel);
				serverSideChannelHandlers.Remove(sideChannel);
			}
			serverSideChannelHandlers.Add(sideChannel, handler);
		}
		else
		{
			if (clientSideChannelHandlers.ContainsKey(sideChannel))
			{
				Debug.LogError("Duplicate handlers for side channel " + sideChannel);
				clientSideChannelHandlers.Remove(sideChannel);
			}
			clientSideChannelHandlers.Add(sideChannel, handler);
		}
	}

	public void RemoveSideChannelHandler(SideChannel sideChannel, bool isServer)
	{
		if (isServer)
		{
			serverSideChannelHandlers.Remove(sideChannel);
		}
		else
		{
			clientSideChannelHandlers.Remove(sideChannel);
		}
	}

	public void SendSideChannel(Entity connectionEntity, World world, SideChannel sideChannel, bool isServer, byte[] data)
	{
		NetworkConnection value = world.EntityManager.GetComponentData<NetworkStreamConnection>(connectionEntity).Value;
		NetworkEndpoint remoteEndpoint = GetDriverForWorld(world).GetRemoteEndpoint(value);
		if ((isServer && remoteEndpoint == serverNetIf.LocalEndpoint) || (!isServer && remoteEndpoint == clientNetIf.LocalEndpoint))
		{
			Action<byte[]> value3;
			if (isServer)
			{
				if (clientSideChannelHandlers.TryGetValue(sideChannel, out var value2))
				{
					value2(data);
				}
			}
			else if (serverSideChannelHandlers.TryGetValue(sideChannel, out value3))
			{
				value3(data);
			}
		}
		else
		{
			impl.SendSideChannelMessage(remoteEndpoint, (int)sideChannel, data);
		}
	}

	private void HandleSideChannelMessage(NetworkEndpoint endpoint, int sideChannelInt, byte[] packet)
	{
		Action<byte[]> value2;
		if (Manager.ecs.ServerWorld != null && Manager.ecs.ServerWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.guestMode && GetAdminPrivileges(endpoint, 0uL) < 1)
		{
			Debug.Log($"Skipping received side channel message from {endpoint} (non-admin) due to guest mode");
		}
		else if (Manager.ecs.ServerWorld == null)
		{
			if (clientSideChannelHandlers.TryGetValue((SideChannel)sideChannelInt, out var value))
			{
				value(packet);
			}
			else
			{
				Debug.LogError($"Got packet on side channel {(SideChannel)sideChannelInt} without receiver (client)");
			}
		}
		else if (serverSideChannelHandlers.TryGetValue((SideChannel)sideChannelInt, out value2))
		{
			value2(packet);
		}
		else
		{
			Debug.LogError($"Got packet on side channel {(SideChannel)sideChannelInt} without receiver (server)");
		}
	}

	private void HandleStartSession(bool success)
	{
	}

	public void CreateClientDriver(World world, ref NetworkDriverStore driver, NetDebug netDebug)
	{
		NetworkSettings settings = default(NetworkSettings);
		settings.WithReliableStageParameters().WithFragmentationStageParameters(1048576);
		settings.WithNetworkConfigParameters(3000, 60, 30000, 500, 2000, 100);
		NetworkDriverStore.NetworkDriverInstance driverInstance = default(NetworkDriverStore.NetworkDriverInstance);
		NetworkDriver driver2 = (driverInstance.driver = NetworkDriver.Create(ref clientNetIf, settings));
		Entity entity = world.EntityManager.CreateEntity(typeof(WorldNetworkDriver));
		world.EntityManager.SetComponentData(entity, new WorldNetworkDriver
		{
			driver = driver2
		});
		driverInstance.unreliablePipeline = driver2.CreatePipeline(typeof(NullPipelineStage));
		_reliablePipeline = (driverInstance.reliablePipeline = driver2.CreatePipeline(typeof(ReliableSequencedPipelineStage)));
		driverInstance.unreliableFragmentedPipeline = driver2.CreatePipeline(typeof(FragmentationPipelineStage));
		driver.RegisterDriver(TransportType.IPC, in driverInstance);
	}

	public void CreateServerDriver(World world, ref NetworkDriverStore driver, NetDebug netDebug)
	{
		NetworkSettings settings = default(NetworkSettings);
		settings.WithReliableStageParameters().WithFragmentationStageParameters(1048576);
		NetworkDriverStore.NetworkDriverInstance driverInstance = default(NetworkDriverStore.NetworkDriverInstance);
		settings.WithNetworkConfigParameters(3000, 60, 30000, 500, 2000, 100);
		NetworkDriver driver2 = (driverInstance.driver = NetworkDriver.Create(ref serverNetIf, settings));
		Entity entity = world.EntityManager.CreateEntity(typeof(WorldNetworkDriver));
		world.EntityManager.SetComponentData(entity, new WorldNetworkDriver
		{
			driver = driver2
		});
		driverInstance.unreliablePipeline = driver2.CreatePipeline(typeof(NullPipelineStage));
		driverInstance.reliablePipeline = driver2.CreatePipeline(typeof(ReliableSequencedPipelineStage));
		driverInstance.unreliableFragmentedPipeline = driver2.CreatePipeline(typeof(FragmentationPipelineStage));
		driver.RegisterDriver(TransportType.IPC, in driverInstance);
	}

	public void StartSessionInvitationFlow()
	{
		impl.StartSessionInvitationFlow();
	}

	public void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback)
	{
		impl.SendSessionInvitations(invitees, callback);
	}

	public void JoinSessionDirect(string sessionId, bool checkPrivileges)
	{
		currentSessionId = sessionId;
		HandleJoinSessionDirect(hasAllRequestedPrivileges: true);
	}

	private void HandleJoinSessionDirect(bool hasAllRequestedPrivileges)
	{
		if (hasAllRequestedPrivileges)
		{
			if (Manager.sceneHandler.isTitle)
			{
				Manager.sceneHandler.titleScreenAnimator.SetTitleTextEnabled(enable: false);
			}
			Manager.menu.PushMenu(RadicalMenu.MenuType.JOIN_GAME);
			RadicalJoinGameMenu obj = Manager.menu.GetTopMenu() as RadicalJoinGameMenu;
			ServerConnectionInfo sessionData = ServerConnectionInfo.UnPackConnectionID(currentSessionId);
			obj.ChangeJoinMethod(sessionData.JoinedWithIP ? RadicalJoinGameMenu.JoinMethod.IP : RadicalJoinGameMenu.JoinMethod.ID);
			obj.SetSessionData(sessionData);
			obj.ButtonPressed();
			obj.hostText.ResetText();
		}
	}

	public void CanUserPlayMultiplayer(Action<bool> callback, bool joining, bool showUI = true, bool doInBackground = false, bool checkNetworking = true)
	{
		Task.Run(async delegate
		{
			await CanUserPlayMultiplayerAsync(delegate(bool hasNetwork)
			{
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					callback?.Invoke(hasNetwork);
				});
			}, joining, showUI, doInBackground, checkNetworking);
		});
	}

	private async Task CanUserPlayMultiplayerAsync(Action<bool> callback, bool joining, bool showUI = true, bool doInBackground = false, bool checkNetworking = true)
	{
		try
		{
			PlatformInterface.UserPrivileges privileges = PlatformInterface.UserPrivileges.Multiplayer | PlatformInterface.UserPrivileges.UGC | PlatformInterface.UserPrivileges.PremiumSubscription;
			if (OfflineSession)
			{
				callback?.Invoke(obj: true);
				return;
			}
			isCheckingPrivileges = true;
			if (doInBackground)
			{
				callback?.Invoke(obj: true);
				callback = null;
			}
			if (!(await EulaAcceptedCheck()))
			{
				isCheckingPrivileges = false;
				callback?.Invoke(obj: false);
				return;
			}
			Task.Run(async delegate
			{
				await PrivilegeCheckTimeOut(callback);
			});
			bool flag = !checkNetworking;
			if (!flag)
			{
				flag = await Manager.platform.HasNetworkCheck();
			}
			if (!flag)
			{
				await UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
				{
					HandleNoNetwork(joining, callback);
				});
			}
			else
			{
				Manager.platform.platformImpl.CheckUserPrivileges(privileges, showUI, delegate(PlatformInterface.PrivilegesResult result)
				{
					OnCheckUserPrivilegesComplete(result, callback);
				});
			}
		}
		catch (Exception ex)
		{
			Exception e = ex;
			await UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
			{
				callback?.Invoke(obj: false);
				throw e;
			});
		}
	}

	private async Task PrivilegeCheckTimeOut(Action<bool> callback)
	{
		for (int i = 0; i < 30000; i += 1000)
		{
			if (!isCheckingPrivileges)
			{
				break;
			}
			await Task.Delay(1000);
		}
		if (isCheckingPrivileges)
		{
			isCheckingPrivileges = false;
			Manager.menu.centerPopUpText.FadeOutCurrentDisplaySequence();
			Debug.Log("Connection timed out.");
			callback?.Invoke(obj: false);
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/Timeout", null, menuInputCooldown: true, 0f, 5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, new List<string> { "ok" }, 10f, 0.95f, 0, 18f);
		}
	}

	private async Task<bool> EulaAcceptedCheck()
	{
		if (!Manager.prefs.ShowEulaPopUp)
		{
			return true;
		}
		bool isCheckingEula = true;
		bool acceptedEula = false;
		wasPlayerInputDisabled = !Manager.input.IsSystemInputEnabled();
		Manager.input.EnableSystemInput();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("OpenEula", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
			{
				if (response.IsConfirm)
				{
					UnityMainThreadDispatcher.Instance().Enqueue(delegate
					{
						Manager.menu.PushMenu(RadicalMenu.MenuType.EULA_MENU);
						(Manager.menu.eulaMenu as RadicalEulaMenu)?.StartEulaCheck(delegate(bool isAccepted)
						{
							isCheckingEula = false;
							acceptedEula = isAccepted;
						});
					});
				}
				else
				{
					isCheckingEula = false;
				}
			}, new List<string> { "cancelDialogue", "Open" }, 10f, 0f, 0, 15f);
		});
		while (isCheckingEula)
		{
			await Task.Delay(200);
		}
		if (wasPlayerInputDisabled)
		{
			Manager.input.DisableSystemInput();
		}
		if (acceptedEula)
		{
			await UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
			{
				Manager.menu.centerPopUpText.FadeOutCurrentDisplaySequence();
				Manager.prefs.ShowEulaPopUp = false;
				Manager.prefs.Write();
			});
		}
		return acceptedEula;
	}

	private void OnCheckUserPrivilegesComplete(PlatformInterface.PrivilegesResult result, Action<bool> callback)
	{
		if (!isCheckingPrivileges)
		{
			return;
		}
		isCheckingPrivileges = false;
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			Manager.menu.centerPopUpText.FadeOutCurrentDisplaySequence();
			if (result.CheckStatus == PlatformInterface.PrivilegeCheckStatus.Failed)
			{
				Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/BadInternet", null, menuInputCooldown: true, 0f, 5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, new List<string> { "ok" }, 10f, 0.95f, 0, 18f);
			}
			UnityMainThreadDispatcher.Instance().Enqueue(delegate
			{
				callback?.Invoke(result.isAllowedToPlayMultiplayer);
			});
		});
	}

	private void HandleNoNetwork(bool joining, Action<bool> callback)
	{
		if (!isCheckingPrivileges)
		{
			return;
		}
		isCheckingPrivileges = false;
		Manager.menu.centerPopUpText.FadeOutCurrentDisplaySequence();
		if (!joining)
		{
			Debug.Log("Can't play multiplayer since network availability check failed. Continuing in offline mode.");
			Manager.networking.OfflineSession = true;
			callback?.Invoke(obj: true);
			return;
		}
		callback?.Invoke(obj: false);
		Debug.Log("Can't play multiplayer since network availability check failed.");
		string[] formatFields = new string[1] { "unsupported" };
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence(Manager.platform.platformImpl.IsLoggedOn ? "Error/ConnectionLost" : "Error/AuthenticationFailed", options: new List<string> { "ok" }, formatFields: formatFields, menuInputCooldown: true, fadeTime: 0f, staticTime: 1.5f, useUnscaledTime: true, yPosition: 0f, textBackgroundAlpha: 1f, localize: true, fontFace: TextManager.FontFace.boldMedium, optionsCallback: delegate
			{
			}, minWidth: 10f, backgroundAlpha: 0.95f, priority: 0, textMaxWidth: 18f);
		});
	}
}
