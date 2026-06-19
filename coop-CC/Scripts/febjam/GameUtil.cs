using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.SceneManagement;

public static class GameUtil
{
	public const string GAME_SCENE = "scene-game";

	public const string RUN_SCENE = "scene-run";

	public const string LOBBY_SCENE = "scene-lobby";

	public const string TITLE_SCENE = "scene-title";

	public const string TUTORIAL_SCENE = "scene-TutorialReal";

	public const string DEBUG_SCENE = "scene-debug";

	public const int PLAYER_COUNT = 4;

	public const int BELL_COUNT_PER_CONTRACT = 5;

	public const int SHIFT_COUNT = 5;

	public const int MODIFIER_1_AFTER = 1;

	public const int MODIFIER_2_AFTER = 3;

	private static Room _warehouseRoom;

	private static Room _breakroomRoom;

	private static Room _lobbyRoom;

	private static RoomType _activeRoom;

	private static bool _gameInitialized;

	private static ObjectQuery<PlayerPosition> _playerPositionsQuery;

	private static ObjectQuery<PlayerGrabber> _playerGrabberQuery;

	private static List<Transform> _transforms = new List<Transform>();

	private static List<Vector3> _vectors = new List<Vector3>();

	public const string IPADDRESSPORTEXTRACTION = "^([\\d\\w\\.]+):(\\d+)$";

	public static EntityWorld world { get; private set; }

	public static EntityManager entityManager => world.entityManager;

	public static bool isReady
	{
		get
		{
			if (world != null)
			{
				return world.isValid;
			}
			return false;
		}
	}

	public static bool isLobby
	{
		get
		{
			if (isReady)
			{
				return _activeRoom == RoomType.Lobby;
			}
			return false;
		}
	}

	public static bool isRun
	{
		get
		{
			if (isReady)
			{
				if (_activeRoom != RoomType.Warehouse)
				{
					return _activeRoom == RoomType.BreakRoom;
				}
				return true;
			}
			return false;
		}
	}

	public static string currentWarehouseSceneName { get; private set; }

	public static ContractObject contract { get; private set; }

	public static ShiftOrderObject[] orders { get; private set; }

	public static int seed { get; private set; }

	public static Camera mainCamera { get; private set; }

	public static Camera uiCamera { get; private set; }

	public static GameError gameError { get; set; }

	public static bool isUnloadingScene { get; set; }

	public static int buildNumber { get; private set; }

	public static string buildHash { get; private set; }

	public static string gameVersionFull { get; private set; }

	public static bool isTutorial => GameSettings.current.loadType == GameLoadType.Tutorial;

	public static bool isGym => GameSettings.current.loadType == GameLoadType.Gym;

	public static bool isDemo => false;

	[RuntimeInitializeOnLoadMethod]
	private static void RuntimeInit()
	{
		_gameInitialized = false;
		gameError = GameError.None;
		if (Application.isEditor)
		{
			buildNumber = 0;
			buildHash = "0000";
			gameVersionFull = Application.version + "-EDITOR";
			return;
		}
		int hashCode = AggroUtil.GetBuildGuid().GetHashCode();
		uint num = (uint)(hashCode & 0xFFFF);
		uint num2 = (uint)hashCode >> 16;
		buildHash = ((ushort)(buildNumber = (ushort)(num ^ num2))).ToString("X4");
		if (Debug.isDebugBuild)
		{
			gameVersionFull = Application.version + "-" + buildHash + "-DEV";
		}
		else
		{
			gameVersionFull = Application.version + "-" + buildHash;
		}
		if (isDemo)
		{
			gameVersionFull += "-DEMO";
		}
		CrashReportHandler.SetUserMetadata("game-version-full", gameVersionFull);
		Debug.Log("[GAME VERSION] " + gameVersionFull);
	}

	public static IEnumerator InitializeGameCo()
	{
		if (!_gameInitialized)
		{
			_gameInitialized = true;
			yield return new WaitForTask(Platform.InitializeAsync());
			CrashReportHandler.SetUserMetadata("game-platform", Platform.GetPlatformType().ToString());
			AggroUtil.InitializeGlobalScrobs();
			AudioManager.Initialize();
			Options.Initialize();
			if (Platform.GetPlatformType() == PlatformType.SteamDeck)
			{
				AggroInputManager.ChangeMode(InputMode.Gamepad);
			}
		}
		if (SaveManager.isInitialized)
		{
			yield break;
		}
		if (SaveManager.DoesGameExist(0))
		{
			yield return new WaitForTask(SaveManager.InitializeLoadGameAsync(0));
			if (SaveManager.data.GetSaveVersion() != 1)
			{
				SaveManager.Uninitialize();
				SaveManager.InitializeNewGame(0);
				yield return new WaitForTask(SaveManager.SaveGameAsync());
			}
		}
		else
		{
			SaveManager.InitializeNewGame(0);
			yield return new WaitForTask(SaveManager.SaveGameAsync());
		}
		CostumeObject[] costumes = GlobalScriptableObject<CosmeticGlobalData>.instance.costumes;
		foreach (CostumeObject costumeObject in costumes)
		{
			if ((object)costumeObject != null && costumeObject.startsUnlocked)
			{
				SaveManager.data.UnlockCostume(costumeObject);
			}
		}
	}

	public static void Initialize(EntityWorld world)
	{
		GameUtil.world = world;
		NetworkClient.RegisterHandler<NetMsgTeleported>(OnTeleported);
		_playerPositionsQuery = world.entityManager.CreateObjectQuery<PlayerPosition>();
		_playerGrabberQuery = world.entityManager.CreateObjectQuery<PlayerGrabber>();
	}

	public static void InitializeLobby(Camera mainCamera, Camera uiCamera, Room lobbyRoom, int seed)
	{
		_lobbyRoom = lobbyRoom;
		GameUtil.seed = seed;
		GameUtil.mainCamera = mainCamera;
		GameUtil.uiCamera = uiCamera;
		_activeRoom = RoomType.Lobby;
	}

	public static void InitializeContractRun(string sceneName, ContractObject contract, Camera mainCamera, Camera uiCamera, Room warehouseRoom, Room breakroomRoom, int seed)
	{
		GameUtil.seed = seed;
		GameUtil.contract = contract;
		switch (GameUtil.contract.type)
		{
		case ContractType.Explicit:
			orders = GameUtil.contract.orders;
			break;
		case ContractType.Random:
		{
			List<ShiftOrderObject> list = new List<ShiftOrderObject>(GameUtil.contract.orders);
			list.Randomize(Hash.Calculate(seed, Hash.Calculate(typeof(GameUtil))));
			orders = new ShiftOrderObject[GameUtil.contract.randomBoxCount];
			for (int i = 0; i < orders.Length; i++)
			{
				orders[i] = list[i];
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		}
		GameUtil.mainCamera = mainCamera;
		GameUtil.uiCamera = uiCamera;
		_warehouseRoom = warehouseRoom;
		_breakroomRoom = breakroomRoom;
		_activeRoom = RoomType.BreakRoom;
		currentWarehouseSceneName = sceneName;
	}

	public static void InitializeTutorial(string sceneName, Camera mainCamera, Camera uiCamera, Room warehouseRoom, int seed)
	{
		GameUtil.mainCamera = mainCamera;
		GameUtil.uiCamera = uiCamera;
		_warehouseRoom = warehouseRoom;
		currentWarehouseSceneName = sceneName;
		GameUtil.seed = seed;
		_activeRoom = RoomType.Warehouse;
	}

	public static void InitializeGym(string sceneName, ContractObject contract, Camera mainCamera, Camera uiCamera, Room warehouseRoom, int seed)
	{
		GameUtil.seed = seed;
		GameUtil.contract = contract;
		switch (GameUtil.contract.type)
		{
		case ContractType.Explicit:
			orders = GameUtil.contract.orders;
			break;
		case ContractType.Random:
		{
			List<ShiftOrderObject> list = new List<ShiftOrderObject>(GameUtil.contract.orders);
			list.Randomize(Hash.Calculate(seed, Hash.Calculate(typeof(GameUtil))));
			orders = new ShiftOrderObject[GameUtil.contract.randomBoxCount];
			for (int i = 0; i < orders.Length; i++)
			{
				orders[i] = list[i];
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		}
		GameUtil.mainCamera = mainCamera;
		GameUtil.uiCamera = uiCamera;
		_warehouseRoom = warehouseRoom;
		_activeRoom = RoomType.Warehouse;
		currentWarehouseSceneName = sceneName;
	}

	public static void UninitializeWorld()
	{
		world = null;
		NetworkClient.UnregisterHandler<NetMsgTeleported>();
	}

	public static void UninitializeLobby()
	{
		world = null;
		_activeRoom = RoomType.None;
	}

	public static void UninitializeGame()
	{
		seed = 0;
		contract = null;
		currentWarehouseSceneName = null;
		orders = null;
		_warehouseRoom = null;
		_breakroomRoom = null;
		_activeRoom = RoomType.None;
	}

	public static Entity GetLocalPlayer()
	{
		TryGetLocalPlayer(out var player);
		return player;
	}

	public static bool TryGetLocalPlayer(out Entity player)
	{
		if (NetworkClient.isConnected)
		{
			NetworkIdentity localPlayer = NetworkClient.localPlayer;
			if (localPlayer != null && localPlayer.TryGetComponent<EntityBehaviour>(out var component))
			{
				player = component.entity;
				return true;
			}
		}
		player = Entity.invalid;
		return false;
	}

	public static RoomType GetCurrentRoomType()
	{
		return _activeRoom;
	}

	public static Transform GetCurrentContainer()
	{
		return GetContainer(_activeRoom);
	}

	public static Transform GetContainer(RoomType type)
	{
		return type switch
		{
			RoomType.Warehouse => _warehouseRoom.instantiateContainer, 
			RoomType.BreakRoom => _breakroomRoom.instantiateContainer, 
			RoomType.Lobby => _lobbyRoom.instantiateContainer, 
			_ => throw new InvalidEnumException(), 
		};
	}

	public static void OnTeleported(NetMsgTeleported msg)
	{
		_activeRoom = msg.roomType;
		if (TryGetLocalPlayer(out var player))
		{
			player.rigidbody.velocity = Vector3.zero;
			player.rigidbody.angularVelocity = Vector3.zero;
			player.netTransform.SetDirty();
		}
	}

	[Server]
	public static void ServerTeleportPlayers(RoomType roomType, int seed)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GameUtil::ServerTeleportPlayers(RoomType,System.Int32)' called when server was not active");
			return;
		}
		_transforms.Clear();
		_playerPositionsQuery.Run();
		for (int i = 0; i < _playerPositionsQuery.count; i++)
		{
			PlayerPosition playerPosition = _playerPositionsQuery[i];
			if (playerPosition.Evaluate(roomType))
			{
				_transforms.Add(playerPosition.transform);
			}
		}
		if (_transforms.Count > 0)
		{
			_transforms.Randomize(seed);
			int num = 0;
			foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
			{
				NetMsgTeleported message = new NetMsgTeleported
				{
					roomType = roomType
				};
				connection.Value.Send(message);
			}
			{
				foreach (KeyValuePair<int, NetworkConnectionToClient> connection2 in NetworkServer.connections)
				{
					Transform transform = _transforms[num++ % _transforms.Count];
					if (EntityExtensions.TryGetEntity(connection2.Value.identity, out var entity))
					{
						Vector3 position = transform.position;
						position.y = 0f;
						entity.netTransform.ServerTeleport(position, transform.rotation);
					}
				}
				return;
			}
		}
		Debug.LogWarning($"Did not find positions of type {roomType}!");
	}

	[Server]
	public static void ServerPlayersResetState()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GameUtil::ServerPlayersResetState()' called when server was not active");
			return;
		}
		_playerGrabberQuery.Run();
		for (int i = 0; i < _playerGrabberQuery.count; i++)
		{
			Entity entity = _playerGrabberQuery.GetEntity(i);
			entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: false, checkUpgrade: false);
			entity.GetObject<PlayerStress>().RequestClearStress();
		}
	}

	[Server]
	public static bool ServerPlayersGrabbersEmpty()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean GameUtil::ServerPlayersGrabbersEmpty()' called when server was not active");
			return default(bool);
		}
		_playerGrabberQuery.Run();
		for (int i = 0; i < _playerGrabberQuery.count; i++)
		{
			if (_playerGrabberQuery[i].serverGrabbed != Entity.invalid)
			{
				return false;
			}
		}
		return true;
	}

	[Server]
	public static void ServerTeleportBox(Entity box, Vector3 position, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GameUtil::ServerTeleportBox(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		_vectors.Clear();
		_vectors.Add(position);
		box.predictedRigidbodyGroup.ServerTeleport(_vectors, rotation);
		box.GetObject<NetworkTransformFollow>().ServerTeleported();
	}

	public static void LocalPlayerResetState()
	{
		if (isRun && TryGetLocalPlayer(out var player))
		{
			player.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: false, checkUpgrade: false);
			player.GetObject<PlayerStress>().RequestClearStress();
		}
	}

	public static void JoinLobby(PlatformGameJoin invite)
	{
		if (invite.result == PlatformError.Success && string.IsNullOrEmpty(invite.joinData))
		{
			invite.result = PlatformError.UnknownError;
		}
		switch (invite.result)
		{
		case PlatformError.Success:
			GameSettings.Set(new GameSettings
			{
				loadType = GameLoadType.Lobby,
				networkType = NetworkType.JoinPlatform,
				address = invite.joinData
			});
			SceneManager.LoadScene("scene-game");
			break;
		case PlatformError.LobbyFull:
			gameError = GameError.ClientCantConnectLobbyFull;
			SceneManager.LoadScene("scene-title");
			break;
		default:
			gameError = GameError.ClientCantConnect;
			SceneManager.LoadScene("scene-title");
			break;
		}
	}

	public static float GetDifficultyMultiplier()
	{
		if (!isRun || !isReady)
		{
			return 1f;
		}
		float num = 1f;
		if (NetworkAggroManagerBase<ModifierManager>.ManagerExists() && NetworkAggroManagerBase<PlayersManager>.ManagerExists() && NetworkAggroManagerBase<ShiftManager>.ManagerExists())
		{
			num = NetworkAggroManagerBase<PlayersManager>.instance.playerCount switch
			{
				1 => num * NetworkAggroManagerBase<ModifierManager>.instance.onePlayerMultiplier, 
				2 => num * NetworkAggroManagerBase<ModifierManager>.instance.twoPlayerMultiplier, 
				3 => num * NetworkAggroManagerBase<ModifierManager>.instance.threePlayerMultiplier, 
				_ => num * NetworkAggroManagerBase<ModifierManager>.instance.fourPlayerMultiplier, 
			};
			switch (NetworkAggroManagerBase<ShiftManager>.instance.GetCurrentShift())
			{
			case 1:
			case 2:
				num *= NetworkAggroManagerBase<ModifierManager>.instance.shiftTwoMultiplier;
				break;
			case 3:
				num *= NetworkAggroManagerBase<ModifierManager>.instance.shiftThreeMultiplier;
				break;
			case 4:
				num *= NetworkAggroManagerBase<ModifierManager>.instance.shiftFourMultiplier;
				break;
			default:
				num *= NetworkAggroManagerBase<ModifierManager>.instance.shiftFiveMultiplier;
				break;
			}
		}
		if ((object)contract != null)
		{
			num *= contract.modifierMultiplier;
		}
		return num;
	}
}
