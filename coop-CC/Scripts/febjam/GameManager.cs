using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private enum Mode
	{
		Client = 0,
		ServerLobby = 1,
		ServerRun = 2,
		Gym = 3,
		Tutorial = 4,
		GymTutorial = 5
	}

	public ContractObject[] contracts;

	public ContractObject[] demoContracts;

	public ContractObject gymContract;

	private EntityWorld _world;

	private InitializationUpdateSystemGroup _initGroup;

	private SimulationUpdateSystemGroup _simGroup;

	private PresentationUpdateSystemGroup _presGroup;

	private PresentationLateUpdateSystemGroup _presLateGroup;

	private List<ContractObject> _sortedContracts = new List<ContractObject>();

	private static GameNextType _next;

	private static NetMsgGameManagerLoad _msg;

	private static bool _isReadyToStart;

	private static GameManager _instance;

	public static ContractObject selectedRunContract { get; set; }

	private void Start()
	{
		FadeManager.SetFaded();
		ContractObject[] contracts = GetContracts();
		foreach (ContractObject contractObject in contracts)
		{
			if (contractObject != null)
			{
				_sortedContracts.Add(contractObject);
			}
		}
		_sortedContracts.Sort(delegate(ContractObject x, ContractObject y)
		{
			if (x.isDemoLocked && y.isDemoLocked)
			{
				return Array.IndexOf(contracts, x).CompareTo(Array.IndexOf(contracts, y));
			}
			if (x.isDemoLocked)
			{
				return 1;
			}
			if (y.isDemoLocked)
			{
				return -1;
			}
			int num = x.bellsRequired.CompareTo(y.bellsRequired);
			return (num != 0) ? num : string.Compare(x.name, y.name, StringComparison.Ordinal);
		});
		StartCoroutine(GameCo());
	}

	private ContractObject[] GetContracts()
	{
		if (GameUtil.isDemo)
		{
			return demoContracts;
		}
		return contracts;
	}

	private void OnDestroy()
	{
		if (_world != null)
		{
			EntityWorldUtil.RemoveWorldFromPlayerLoopList(_world);
			_world.Dispose();
		}
		GameUtil.UninitializeLobby();
		GameUtil.UninitializeGame();
		GameUtil.UninitializeWorld();
		NetworkClient.UnregisterHandler<NetMsgGameManagerLoad>();
		NetworkClient.UnregisterHandler<NetMsgGameManagerReady>();
		Physics.simulationMode = SimulationMode.FixedUpdate;
		GameObjectPoolManager.ClearDisabledPrefabs();
		GameObjectPoolManager.ClearPrefabPools();
		AggroInputManager.ResetVibrations();
	}

	private IEnumerator GameCo()
	{
		while (!GameSettings.hasSettings)
		{
			yield return null;
		}
		GameUtil.isUnloadingScene = false;
		_instance = this;
		selectedRunContract = GetContracts()[0];
		yield return GameUtil.InitializeGameCo();
		GameSettings settings = GameSettings.current;
		Physics.simulationMode = SimulationMode.Script;
		string loadedWarehouse = null;
		Mode mode;
		if (settings.networkType == NetworkType.Host || settings.networkType == NetworkType.HostPlatform || settings.networkType == NetworkType.SinglePlayer)
		{
			ushort port = (ushort)((settings.networkType != NetworkType.HostPlatform) ? settings.port : 0);
			if (settings.loadType == GameLoadType.Lobby)
			{
				if (!SceneUtil.IsSceneLoaded("scene-lobby"))
				{
					yield return SceneManager.LoadSceneAsync("scene-lobby", LoadSceneMode.Additive);
				}
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-lobby"));
				if (settings.networkType == NetworkType.Host)
				{
					try
					{
						AggroNetworkManager.StartHost(NetworkTransportType.Normal, port);
					}
					catch (Exception exception)
					{
						UnityEngine.Debug.LogException(exception);
						GameUtil.gameError = GameError.HostFailed;
						SceneManager.LoadScene("scene-title");
						yield break;
					}
				}
				else if (settings.networkType == NetworkType.HostPlatform)
				{
					try
					{
						AggroNetworkManager.StartHost(NetworkTransportType.Platform, port);
					}
					catch (Exception exception2)
					{
						UnityEngine.Debug.LogException(exception2);
						GameUtil.gameError = GameError.HostFailed;
						SceneManager.LoadScene("scene-title");
						yield break;
					}
					Task<bool> task = Platform.CreateLobbyAsync(settings.allowFriends, 4);
					yield return new WaitForTask(task);
					if (task.IsFaulted || !task.Result)
					{
						GameUtil.gameError = GameError.HostFailed;
						SceneManager.LoadScene("scene-title");
						yield break;
					}
				}
				else
				{
					AggroNetworkManager.StartSinglePlayer();
				}
				mode = Mode.ServerLobby;
			}
			else if (settings.loadType == GameLoadType.Tutorial)
			{
				if (!SceneUtil.IsSceneLoaded("scene-run"))
				{
					yield return SceneManager.LoadSceneAsync("scene-run", LoadSceneMode.Additive);
				}
				if (!SceneUtil.IsSceneLoaded("scene-TutorialReal"))
				{
					yield return SceneManager.LoadSceneAsync("scene-TutorialReal", LoadSceneMode.Additive);
				}
				loadedWarehouse = "scene-TutorialReal";
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-run"));
				AggroNetworkManager.StartSinglePlayer();
				mode = Mode.Tutorial;
			}
			else
			{
				if (!SceneUtil.IsSceneLoaded("scene-run"))
				{
					yield return SceneManager.LoadSceneAsync("scene-run", LoadSceneMode.Additive);
				}
				if (!SceneUtil.IsSceneLoaded(settings.scene))
				{
					yield return SceneManager.LoadSceneAsync(settings.scene, LoadSceneMode.Additive);
				}
				loadedWarehouse = settings.scene;
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-run"));
				AggroNetworkManager.StartSinglePlayer();
				mode = Mode.Gym;
			}
		}
		else
		{
			UnityEngine.Debug.Log($"[GameManager] [GameCo] Transport type is {settings.networkType}, address is {settings.address}, port is {settings.port}");
			Task<ClientConnectionResult> task2 = ((settings.networkType != NetworkType.Join) ? AggroNetworkManager.StartClientAsync(NetworkTransportType.Platform, settings.address, settings.port) : AggroNetworkManager.StartClientAsync(NetworkTransportType.Normal, settings.address, settings.port));
			yield return new WaitForTask(task2);
			if (task2.IsFaulted || !task2.Result.isSuccess)
			{
				if (task2.Result.result == ClientConnectionResult.Result.FailedVersionMismatch)
				{
					GameUtil.gameError = GameError.ClientVersionMismatch;
				}
				else
				{
					GameUtil.gameError = GameError.ClientCantConnect;
				}
				SceneManager.LoadScene("scene-title");
				yield break;
			}
			yield return SceneManager.LoadSceneAsync("scene-lobby", LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-lobby"));
			yield return null;
			mode = Mode.Client;
		}
		if (NetworkServer.active)
		{
			if (mode == Mode.Tutorial)
			{
				CrashReportHandler.SetUserMetadata("network-type", "tutorial");
			}
			else
			{
				CrashReportHandler.SetUserMetadata("network-type", "server");
			}
		}
		else
		{
			CrashReportHandler.SetUserMetadata("network-type", "client");
		}
		NetworkClient.RegisterHandler<NetMsgGameManagerLoad>(OnGameManagerLoad);
		NetworkClient.RegisterHandler<NetMsgGameManagerReady>(OnGameManagerReady);
		AggroEditorSettings.TryGetSettings(out var settings2);
		if (settings2 != null && settings2.startWithLatency)
		{
			NetworkUtil.EnableSimulatedLatency(settings2.latency, settings2.packetLoss);
		}
		_world = new EntityWorld("Game World", EntityWorldFlags.GameObjectWorld, Allocator.Persistent);
		_world.stopEntityBehaviourCreation = true;
		GameUtil.Initialize(_world);
		switch (mode)
		{
		case Mode.Client:
		case Mode.ServerLobby:
			InitializeLobby(GenerateSeed());
			break;
		case Mode.Tutorial:
			InitializeTutorial(loadedWarehouse, GenerateSeed());
			break;
		case Mode.Gym:
			InitializeGym(loadedWarehouse, GenerateSeed());
			break;
		default:
			throw new InvalidEnumException();
		}
		_initGroup = _world.GetOrCreateSystem<InitializationUpdateSystemGroup>();
		_simGroup = _world.GetOrCreateSystem<SimulationUpdateSystemGroup>();
		_presGroup = _world.GetOrCreateSystem<PresentationUpdateSystemGroup>();
		_presLateGroup = _world.GetOrCreateSystem<PresentationLateUpdateSystemGroup>();
		InputSystemGroup inputSystem = _world.GetOrCreateSystem<InputSystemGroup>();
		EntityWorldUtil.CreateSystemsForWorld(_world);
		_initGroup.enabled = false;
		_simGroup.enabled = false;
		_presGroup.enabled = false;
		_presLateGroup.enabled = false;
		ObjectQuery<Grabbable> grabbableQuery = _world.entityManager.CreateObjectQuery<Grabbable>();
		NetworkUtil.FindSetNetworkManagers();
		_world.stopEntityBehaviourCreation = false;
		_world.ProcessExistingEntities(runStartRunning: false);
		_world.RunStartRunningMessages();
		switch (mode)
		{
		case Mode.Client:
		case Mode.ServerLobby:
			EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-lobby"), RoomType.Lobby);
			break;
		case Mode.Gym:
		case Mode.Tutorial:
			EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-run"), RoomType.BreakRoom);
			EntityUtil.SetContextForScene(SceneManager.GetSceneByName(loadedWarehouse), RoomType.Warehouse);
			break;
		default:
			throw new InvalidEnumException();
		}
		if (NetworkClient.active)
		{
			NetworkClient.Ready();
		}
		if (NetworkServer.active)
		{
			if (GameUtil.isLobby)
			{
				AggroNetworkManager.SetCurrentLobbyPlayers();
				AggroNetworkManager.EnableHost();
			}
			else
			{
				AggroNetworkManager.SpawnPlayers();
			}
		}
		_next = GameNextType.None;
		EntityWorldUtil.AppendSystemToPlayerLoopList(_initGroup, typeof(EarlyUpdate));
		_initGroup.enabled = true;
		_simGroup.enabled = true;
		_presGroup.enabled = true;
		_presLateGroup.enabled = true;
		AggroInputManager.Enable();
		if (mode == Mode.ServerLobby || mode == Mode.Client)
		{
			AggroInputManager.PushController(NetworkAggroManagerBase<LobbyManager>.instance);
		}
		else
		{
			AggroInputManager.PushController(inputSystem);
		}
		if (mode == Mode.Tutorial)
		{
			AggroManagerBase<TutorialManager>.instance.StartTutorial();
		}
		GC.Collect();
		yield return FadeManager.FadeOutCo();
		string loadedRun = null;
		while (true)
		{
			if (_next == GameNextType.None)
			{
				if (Platform.hasPendingJoin)
				{
					_next = GameNextType.QuitInvite;
				}
				yield return null;
				continue;
			}
			if (!FadeManager.IsFaded())
			{
				yield return FadeManager.FadeInCo();
			}
			AggroInputManager.RemoveController(inputSystem);
			AggroInputManager.Disable();
			Platform.FlushStatsAndAchievements();
			GameUtil.LocalPlayerResetState();
			_world.stopEntityBehaviourCreation = true;
			_initGroup.enabled = false;
			_simGroup.enabled = false;
			_presGroup.enabled = false;
			_presLateGroup.enabled = false;
			EntityWorldUtil.RemoveWorldFromPlayerLoopList(_world);
			if (_next == GameNextType.QuitApplication || _next == GameNextType.QuitTitle || _next == GameNextType.QuitInvite)
			{
				break;
			}
			NetworkAggroManagerBase<VFXManager>.instance.ReleaseAll();
			if (NetworkServer.active)
			{
				NetworkAggroManagerBase<PlayersManager>.instance.ServerResetAll();
				AggroNetworkManager.DisableHost();
				NetworkServer.SetAllClientsNotReady();
				if (_next == GameNextType.ServerLobby)
				{
					NetMsgGameManagerLoad msg = new NetMsgGameManagerLoad
					{
						isRun = false,
						seed = GenerateSeed()
					};
					NetworkServer.SendToAll(msg);
					AggroNetworkManager.RemoveCurrentLocalPlayers();
					GameUtil.isUnloadingScene = true;
					yield return SceneManager.UnloadSceneAsync(loadedRun);
					yield return SceneManager.UnloadSceneAsync("scene-run");
					GameUtil.isUnloadingScene = false;
					yield return SceneManager.LoadSceneAsync("scene-lobby", LoadSceneMode.Additive);
					SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-lobby"));
					InitializeLobby(msg.seed);
					yield return null;
					grabbableQuery.Run();
					for (int i = 0; i < grabbableQuery.count; i++)
					{
						Entity entity = grabbableQuery.GetEntity(i);
						NetworkServer.Destroy(entity.gameObject);
						_world.entityManager.DestroyEntity(entity.key);
					}
				}
				else
				{
					if (_next != GameNextType.ServerRun)
					{
						UnityEngine.Debug.LogError($"[GAME MANAGER] Unexpected next type for server! ({_next})");
						_next = GameNextType.QuitTitle;
						break;
					}
					Unity.Mathematics.Random random = MathUtil.GetRandom(GenerateSeed());
					NetMsgGameManagerLoad msg = new NetMsgGameManagerLoad
					{
						isRun = true,
						seed = random.NextInt()
					};
					string path;
					switch (selectedRunContract.type)
					{
					case ContractType.Explicit:
						msg.contractIndex = (sbyte)Array.IndexOf(GetContracts(), selectedRunContract);
						path = ((NetworkServer.connections.Count < 3) ? selectedRunContract.smallWarehouse : selectedRunContract.bigWarehouse);
						break;
					case ContractType.Random:
						msg.contractIndex = (sbyte)Array.IndexOf(GetContracts(), selectedRunContract);
						path = ((NetworkServer.connections.Count < 3) ? selectedRunContract.smallWarehouses[random.NextInt(0, selectedRunContract.smallWarehouses.Length)] : selectedRunContract.bigWarehouses[random.NextInt(0, selectedRunContract.bigWarehouses.Length)]);
						break;
					default:
						throw new InvalidEnumException();
					}
					loadedRun = (msg.sceneName = Path.GetFileNameWithoutExtension(path));
					NetworkServer.SendToAll(msg);
					AggroNetworkManager.RemoveCurrentLocalPlayers();
					GameUtil.isUnloadingScene = true;
					yield return SceneManager.UnloadSceneAsync("scene-lobby");
					GameUtil.isUnloadingScene = false;
					yield return SceneManager.LoadSceneAsync("scene-run", LoadSceneMode.Additive);
					yield return SceneManager.LoadSceneAsync(loadedRun, LoadSceneMode.Additive);
					SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-run"));
					InitializeRun(loadedRun, selectedRunContract, msg.seed);
				}
				if (NetworkClient.active)
				{
					NetworkClient.Ready();
				}
				NetworkUtil.FindSetNetworkManagers();
				_world.stopEntityBehaviourCreation = false;
				_world.ProcessExistingEntities(runStartRunning: false);
				_world.RunStartRunningMessages();
				if (GameUtil.isLobby)
				{
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-lobby"), RoomType.Lobby);
				}
				else
				{
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-run"), RoomType.BreakRoom);
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName(loadedRun), RoomType.Warehouse);
				}
				yield return WaitForAllPlayersCo();
				yield return null;
				if (GameUtil.isLobby)
				{
					AggroNetworkManager.SetCurrentLobbyPlayers();
				}
				else
				{
					AggroNetworkManager.SpawnPlayers();
				}
				NetworkServer.SendToAll(default(NetMsgGameManagerReady));
				if (NetworkServer.active && GameUtil.isLobby)
				{
					AggroNetworkManager.EnableHost();
				}
			}
			else
			{
				if (!NetworkClient.active)
				{
					_next = GameNextType.QuitTitle;
					break;
				}
				if (_next != GameNextType.ClientMsg)
				{
					UnityEngine.Debug.LogError($"[GAME MANAGER] Unexpected next type for client! ({_next})");
					_next = GameNextType.QuitTitle;
					break;
				}
				if (_msg.isRun)
				{
					GameUtil.isUnloadingScene = true;
					yield return SceneManager.UnloadSceneAsync("scene-lobby");
					GameUtil.isUnloadingScene = false;
					yield return SceneManager.LoadSceneAsync("scene-run", LoadSceneMode.Additive);
					yield return SceneManager.LoadSceneAsync(_msg.sceneName, LoadSceneMode.Additive);
					SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-run"));
					loadedRun = _msg.sceneName;
					InitializeRun(loadedRun, (_msg.contractIndex >= 0) ? GetContracts()[_msg.contractIndex] : null, _msg.seed);
				}
				else
				{
					GameUtil.isUnloadingScene = true;
					yield return SceneManager.UnloadSceneAsync(loadedRun);
					yield return SceneManager.UnloadSceneAsync("scene-run");
					GameUtil.isUnloadingScene = false;
					yield return SceneManager.LoadSceneAsync("scene-lobby", LoadSceneMode.Additive);
					SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene-lobby"));
					InitializeLobby(_msg.seed);
				}
				NetworkUtil.FindSetNetworkManagers();
				_world.stopEntityBehaviourCreation = false;
				_world.ProcessExistingEntities(runStartRunning: false);
				_world.RunStartRunningMessages();
				if (GameUtil.isLobby)
				{
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-lobby"), RoomType.Lobby);
				}
				else
				{
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName("scene-run"), RoomType.BreakRoom);
					EntityUtil.SetContextForScene(SceneManager.GetSceneByName(loadedRun), RoomType.Warehouse);
				}
				yield return null;
				NetworkClient.Ready();
			}
			while (!_isReadyToStart)
			{
				yield return null;
			}
			EntityWorldUtil.AppendSystemToPlayerLoopList(_initGroup, typeof(EarlyUpdate));
			_initGroup.enabled = true;
			_simGroup.enabled = true;
			_presGroup.enabled = true;
			_presLateGroup.enabled = true;
			yield return new WaitForTask(SaveManager.SaveGameAsync());
			AggroInputManager.Enable();
			if (_next == GameNextType.ServerLobby || (_next == GameNextType.ClientMsg && !_msg.isRun))
			{
				AggroInputManager.PushController(NetworkAggroManagerBase<LobbyManager>.instance);
			}
			else
			{
				AggroInputManager.PushController(inputSystem);
			}
			_next = GameNextType.None;
			GC.Collect();
			yield return FadeManager.FadeOutCo();
		}
		if (NetworkServer.active && !AggroNetworkManager.isSinglePlayer)
		{
			AggroNetworkManager.DisableHost();
		}
		CrashReportHandler.SetUserMetadata("network-type", "none");
		if (_next != GameNextType.QuitInvite)
		{
			Platform.LeaveLobby();
		}
		AggroNetworkManager.Disconnect();
		_world.Dispose();
		GameUtil.UninitializeWorld();
		Physics.simulationMode = SimulationMode.FixedUpdate;
		yield return new WaitForTask(SaveManager.SaveGameAsync());
		if (_next == GameNextType.QuitApplication)
		{
			Application.Quit();
			yield break;
		}
		GameObjectPoolManager.ClearDisabledPrefabs();
		GameObjectPoolManager.ClearPrefabPools();
		GameUtil.isUnloadingScene = true;
		GameSettings.Clear();
		if (_next == GameNextType.QuitInvite)
		{
			GameUtil.JoinLobby(Platform.GetAndConsumeJoin());
		}
		else
		{
			SceneManager.LoadScene("scene-title");
		}
	}

	private IEnumerator WaitForAllPlayersCo()
	{
		bool flag;
		do
		{
			yield return null;
			flag = true;
			foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
			{
				if (!connection.Value.isReady)
				{
					flag = false;
					break;
				}
			}
		}
		while (!flag);
	}

	private void OnGameManagerLoad(NetMsgGameManagerLoad msg)
	{
		_isReadyToStart = false;
		if (!NetworkServer.active)
		{
			_next = GameNextType.ClientMsg;
			_msg = msg;
		}
	}

	private void OnGameManagerReady(NetMsgGameManagerReady msg)
	{
		_isReadyToStart = true;
	}

	private static int GenerateSeed()
	{
		return UnityEngine.Random.Range(int.MinValue, int.MaxValue);
	}

	private void InitializeLobby(int seed)
	{
		Room[] array = UnityEngine.Object.FindObjectsOfType<Room>();
		Room room = null;
		foreach (Room room2 in array)
		{
			switch (room2.containerType)
			{
			case RoomType.Lobby:
				room = room2;
				break;
			default:
				throw new InvalidEnumException();
			case RoomType.BreakRoom:
			case RoomType.Warehouse:
				break;
			}
		}
		room = CheckCreateRoom(room, RoomType.Lobby);
		GameUtil.InitializeLobby(Camera.main, UnityEngine.Object.FindObjectOfType<UICamera>().GetComponent<Camera>(), room, seed);
	}

	private void InitializeRun(string sceneName, ContractObject contract, int seed)
	{
		Room[] array = UnityEngine.Object.FindObjectsOfType<Room>();
		Room room = null;
		Room room2 = null;
		foreach (Room room3 in array)
		{
			switch (room3.containerType)
			{
			case RoomType.Warehouse:
				room = room3;
				break;
			case RoomType.BreakRoom:
				room2 = room3;
				break;
			default:
				throw new InvalidEnumException();
			}
		}
		room = CheckCreateRoom(room, RoomType.Warehouse);
		room2 = CheckCreateRoom(room2, RoomType.BreakRoom);
		SaveManager.data.SetLastPlayedContract(contract);
		GameUtil.InitializeContractRun(sceneName, contract, Camera.main, UnityEngine.Object.FindObjectOfType<UICamera>().GetComponent<Camera>(), room, room2, seed);
	}

	private void InitializeTutorial(string sceneName, int seed)
	{
		Room[] array = UnityEngine.Object.FindObjectsOfType<Room>();
		Room room = null;
		foreach (Room room2 in array)
		{
			switch (room2.containerType)
			{
			case RoomType.Warehouse:
				room = room2;
				break;
			default:
				throw new InvalidEnumException();
			case RoomType.BreakRoom:
				break;
			}
		}
		room = CheckCreateRoom(room, RoomType.Warehouse);
		GameUtil.InitializeTutorial(sceneName, Camera.main, UnityEngine.Object.FindObjectOfType<UICamera>().GetComponent<Camera>(), room, seed);
	}

	private void InitializeGym(string sceneName, int seed)
	{
		Room[] array = UnityEngine.Object.FindObjectsOfType<Room>();
		Room room = null;
		foreach (Room room2 in array)
		{
			switch (room2.containerType)
			{
			case RoomType.Warehouse:
				room = room2;
				break;
			default:
				throw new InvalidEnumException();
			case RoomType.BreakRoom:
				break;
			}
		}
		room = CheckCreateRoom(room, RoomType.Warehouse);
		ContractObject overrideGymContract = gymContract;
		if (AggroEditorSettings.TryGetSettings(out var settings) && settings.overrideGymContract != null)
		{
			overrideGymContract = settings.overrideGymContract;
		}
		GameUtil.InitializeGym(sceneName, overrideGymContract, Camera.main, UnityEngine.Object.FindObjectOfType<UICamera>().GetComponent<Camera>(), room, seed);
	}

	private Room CheckCreateRoom(Room room, RoomType roomType)
	{
		if (room == null)
		{
			UnityEngine.Debug.LogWarning($"Room type is missing, creating a default one! {roomType}");
			room = new GameObject($"[{roomType}]").AddComponent<Room>();
		}
		return room;
	}

	private void Update()
	{
		if (_presGroup != null)
		{
			_presGroup.Update();
			AggroInputManager.Update();
			PlayerMessageManager.ProcessQueuedMessages();
		}
	}

	private void LateUpdate()
	{
		if (_presLateGroup != null)
		{
			_presLateGroup.Update();
		}
	}

	private void FixedUpdate()
	{
		if (_simGroup != null)
		{
			_simGroup.Update();
		}
	}

	public static void Next(GameNextType next)
	{
		_next = next;
	}

	public static void NextRun()
	{
		_next = GameNextType.ServerRun;
	}

	public static void GetAllContracts(List<ContractObject> contracts)
	{
		contracts.AddRangeNoGarbage(_instance._sortedContracts);
	}

	public static ContractObject[] GetAllContracts()
	{
		return _instance._sortedContracts.ToArray();
	}

	[Conditional("UNITY_EDITOR")]
	private void PrintEventRegistrations()
	{
		EntityEventManager.GlobalRegistration[] globalRegistrations = _world.eventManager.GetGlobalRegistrations();
		if (globalRegistrations.Length != 0)
		{
			string text = $"Registration Count {globalRegistrations.Length}\n";
			for (int i = 0; i < globalRegistrations.Length; i++)
			{
				EntityEventManager.GlobalRegistration globalRegistration = globalRegistrations[i];
				text = text + "  Event Type: " + TypeUtil.GetFriendlyName(globalRegistration.eventType) + " Func Name: " + globalRegistration.callback.Method.Name + "\n";
			}
			UnityEngine.Debug.Log(text);
		}
	}

	public static void GetAllUnlockedContracts(int bells, List<ContractObject> contracts)
	{
		for (int i = 0; i < _instance._sortedContracts.Count; i++)
		{
			ContractObject contractObject = _instance._sortedContracts[i];
			if (!contractObject.isDemoLocked)
			{
				if (contractObject.bellsRequired > bells)
				{
					break;
				}
				contracts.Add(contractObject);
			}
		}
	}
}
