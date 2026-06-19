using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Interaction;
using Outlines.Converters;
using Pug.Conversion;
using Pug.Properties;
using Pug.UnityExtensions;
using PugMod;
using Unity.Entities;
using Unity.NetCode;
using Unity.Profiling;
using Unity.Scenes;
using Unity.Transforms;
using UnityEngine;

public class ECSManager : ManagerBase
{
	public PugDatabaseAuthoring pugDatabase;

	public GameObject serverAuthoringPrefab;

	public GameObject clientAuthoringPrefab;

	private ECSManagerDummySystem serverDummySystem;

	private ECSManagerDummySystem clientDummySystem;

	private EntityCommandBufferSystem clientSyncPointECBS;

	private EntityQuery serverConnectionQ;

	private EntityQuery serverLoadingDoneQ;

	private float timeScale = 1f;

	private bool pendingQuit;

	private CancellationTokenSource _conversionCancellationTokenSource;

	private List<World> _allWorlds = new List<World>();

	private List<Type> _cachedPugConverterTypes;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("ECSManager.Init");

	public BlobAssetStore BlobAssetStore { get; set; }

	public World ServerWorld { get; private set; }

	public World ClientWorld { get; private set; }

	public bool WorldsAreLoaded { get; private set; }

	public bool IsClosing { get; private set; }

	public EntityQuery ServerConnectionQ => serverConnectionQ;

	public event Action<ClientServerBootstrap.PlayType> EcsStarted;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			World serverWorld = (ClientWorld = null);
			ServerWorld = serverWorld;
			BlobAssetStore = new BlobAssetStore(1024);
			Manager.platform.platformImpl.RegisterSuspendHandler(ProcessSuspension);
			_cachedPugConverterTypes = ConversionManager.FindAllConvertersInCurrentAssembly();
			Debug.Log(string.Format("{0}: Found {1} converter type(s)", "ECSManager", _cachedPugConverterTypes.Count));
			using ConversionManager conversionManager = new ConversionManager(new ConversionManager.ConversionParameters
			{
				TargetWorld = World.DefaultGameObjectInjectionWorld,
				BlobAssetStore = Manager.ecs.BlobAssetStore,
				PropertyBuilder = new PropertyLookupBuilder(),
				GhostConfigOverride = new GhostConfigFromIMonoBehaviourData(),
				ReservedObjectIndices = CalculateReservedObjectIndices(),
				UseHardModeSettings = Manager.saves.IsWorldModeEnabled(WorldMode.Hard),
				UseCasualModeSettings = Manager.saves.IsWorldModeEnabled(WorldMode.Casual)
			}, _cachedPugConverterTypes);
			ConfigurePostConverters(conversionManager);
			PugDatabase.UpdateEntityMonos(pugDatabase.prefabList);
			foreach (MonoBehaviour prefab in pugDatabase.prefabList)
			{
				conversionManager.EnqueueGameObjectHierarchy(prefab.gameObject);
			}
			foreach (MonoBehaviour item in Manager.mod.ExtraAuthoring)
			{
				conversionManager.EnqueueGameObjectHierarchy(item.gameObject);
			}
			conversionManager.EnqueueGameObjectHierarchy(Manager.ecs.serverAuthoringPrefab);
			conversionManager.ConvertEnqueuedObjectsImmediately();
			Entity entity = conversionManager.GetEntity(Manager.ecs.serverAuthoringPrefab);
			World.DefaultGameObjectInjectionWorld.EntityManager.Instantiate(entity);
			PugDatabase.UpdateEntityMonos(Manager.mod.ExtraAuthoring);
			using (EntityQuery entityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DatabaseCD)))
			{
				Manager.mod.Authoring.ObjectProperties = entityQuery.GetSingleton<DatabaseCD>().ObjectPropertyLookup.AsEnum<ObjectID>();
			}
			World.DefaultGameObjectInjectionWorld.Update();
			World.DefaultGameObjectInjectionWorld.QuitUpdate = true;
			Manager.wantsToQuit += WantsToQuitHandler;
			return true;
		}
	}

	public override void Deinit()
	{
		UnloadWorldsInternal();
		if (BlobAssetStore.IsCreated)
		{
			BlobAssetStore.Dispose();
			BlobAssetStore = default(BlobAssetStore);
		}
		base.Deinit();
	}

	public bool TryCalculateGhostCollectionHash(out (ulong GhostCollectionHash, ulong GhostCollectionCount) result)
	{
		using EntityQuery entityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(GhostCollectionPrefab));
		if (entityQuery.IsEmpty)
		{
			Debug.LogError("No ghost collection in default world, can't calculate hash");
			result = (GhostCollectionHash: 0uL, GhostCollectionCount: 0uL);
			return false;
		}
		DynamicBuffer<GhostCollectionPrefab> buffer = World.DefaultGameObjectInjectionWorld.EntityManager.GetBuffer<GhostCollectionPrefab>(entityQuery.GetSingletonEntity());
		if (buffer.IsEmpty)
		{
			Debug.LogError("No ghosts in ghost collection in default world, can't calculate hash");
			result = (GhostCollectionHash: 0uL, GhostCollectionCount: 0uL);
			return false;
		}
		ulong num = 0uL;
		for (int i = 0; i < buffer.Length; i++)
		{
			num ^= buffer[i].Hash;
		}
		result = (GhostCollectionHash: num, GhostCollectionCount: (ulong)buffer.Length);
		return true;
	}

	public static int CalculateReservedObjectIndices()
	{
		int num = (int)ObjectIDExtensions.GetHighestObjectID();
		if (num < 32767)
		{
			num = 32767;
		}
		return num + 1;
	}

	private bool WantsToQuitHandler()
	{
		if (ServerWorld != null)
		{
			SaveSystem existingSystemManaged = ServerWorld.GetExistingSystemManaged<SaveSystem>();
			if (existingSystemManaged == null)
			{
				return true;
			}
			if (existingSystemManaged.SaveIsPending)
			{
				Debug.Log("Save is still pending");
				pendingQuit = true;
				return false;
			}
			if (pendingQuit)
			{
				return true;
			}
			existingSystemManaged.Save();
			pendingQuit = existingSystemManaged.SaveIsPending;
			return !pendingQuit;
		}
		return true;
	}

	private void Update()
	{
		if (!WorldsAreLoaded)
		{
			return;
		}
		if (ServerWorld != null)
		{
			SaveSystem existingSystemManaged = ServerWorld.GetExistingSystemManaged<SaveSystem>();
			if (existingSystemManaged != null && existingSystemManaged.SaveIsPending && existingSystemManaged.SaveDone() && pendingQuit)
			{
				Manager.QuitGame();
			}
		}
		if (ServerWorld == null)
		{
			return;
		}
		SaveSystem existingSystemManaged2 = ServerWorld.GetExistingSystemManaged<SaveSystem>();
		if (!serverLoadingDoneQ.IsEmpty)
		{
			RadicalMenu topMenu = Manager.menu.GetTopMenu();
			if ((((object)topMenu != null && topMenu.pausesGame && serverConnectionQ.CalculateEntityCount() == 1) || Manager.load.IsLoading()) && (existingSystemManaged2 == null || !existingSystemManaged2.SaveIsPending))
			{
				Pause();
				return;
			}
		}
		Resume();
	}

	public void Pause()
	{
		if (Manager.load.IsLoading())
		{
			if (Time.timeScale == 0f)
			{
				Time.timeScale = timeScale;
			}
		}
		else if (Time.timeScale != 0f)
		{
			timeScale = Time.timeScale;
			Time.timeScale = 0f;
			Debug.Log("timescale = 0");
			Manager.trace.GamePause();
		}
		PauseWorld(ServerWorld);
		PauseWorld(ClientWorld);
	}

	public void Resume()
	{
		if (Time.timeScale == 0f)
		{
			Time.timeScale = timeScale;
			Debug.Log($"timescale = {timeScale}");
			Manager.trace.GameResume();
		}
		ResumeWorld(ServerWorld);
		ResumeWorld(ClientWorld);
	}

	private void PauseWorld(World world)
	{
		if (world != null)
		{
			world.GetExistingSystemManaged<SimulationSystemGroup>().Enabled = false;
			WorldExtensions.GetExistingSystem<WorldUpdateAllocatorResetSystem>(world).Update(world.Unmanaged);
			world.GetExistingSystem<BeginSimulationEntityCommandBufferSystem>().Update(world.Unmanaged);
			world.EntityManager.CompleteAllTrackedJobs();
			if (world == ClientWorld)
			{
				world.GetExistingSystem<NetworkCommandClientSystem>().Update(world.Unmanaged);
				world.GetExistingSystem<LocalPresentationCueSystemGroup>().Update(world.Unmanaged);
			}
			else if (world == ServerWorld)
			{
				world.GetExistingSystem<NetworkCommandServerSystem>().Update(world.Unmanaged);
			}
			world.GetExistingSystem<NetworkReceiveSystemGroup>().Update(world.Unmanaged);
			world.GetExistingSystem<RpcCommandRequestSystemGroup>().Update(world.Unmanaged);
			WorldExtensions.GetExistingSystem<RpcSystem>(world).Update(world.Unmanaged);
			world.GetExistingSystem<EndSimulationEntityCommandBufferSystem>().Update(world.Unmanaged);
		}
	}

	private void ResumeWorld(World world)
	{
		if (world != null)
		{
			world.GetExistingSystemManaged<SimulationSystemGroup>().Enabled = true;
		}
	}

	public void OnEarlySceneUnload()
	{
		if (ServerWorld != null)
		{
			ServerWorld.EntityManager.CreateEntity(typeof(QuitPendingCD));
			StartServerSave();
		}
	}

	public bool CanUnloadScene()
	{
		if (ServerWorld == null)
		{
			return true;
		}
		return !ServerWorld.GetExistingSystemManaged<SaveSystem>().SaveIsPending;
	}

	public void OnSceneUnload()
	{
		if (Manager.sceneHandler.isInGame || (Manager.load.GetNameOfNextScene() == "Title" && Manager.sceneHandler.isIntro))
		{
			CancelECSWorldConversionOrUnloadWorlds();
		}
	}

	public void StartEcs(bool startClient, int worldId, WallClockTimer frameWorkloadTimer, Action<bool> onEcsStartCompete)
	{
		IsClosing = false;
		WorldsAreLoaded = false;
		if (ClientWorld != null || ServerWorld != null)
		{
			Debug.LogError("Trying to start new ECS instance without unloading old");
			UnloadWorldsInternal();
		}
		Manager.trace.GameStart();
		ClientServerBootstrap.PlayType requestedPlayType = ClientServerBootstrap.RequestedPlayType;
		this.EcsStarted?.Invoke(requestedPlayType);
		int num = 1;
		if (startClient && requestedPlayType != ClientServerBootstrap.PlayType.Server)
		{
			for (int i = 0; i < num; i++)
			{
				_allWorlds.Add(CreateClientWorld("ClientWorld" + i));
			}
		}
		if (worldId != -1 && requestedPlayType != ClientServerBootstrap.PlayType.Client)
		{
			_allWorlds.Add(CreateServerWorld("ServerWorld", worldId));
		}
		Action callback = delegate
		{
			bool flag = _conversionCancellationTokenSource?.IsCancellationRequested ?? false;
			if (flag)
			{
				UnloadWorlds();
			}
			else
			{
				WorldsAreLoaded = true;
			}
			_conversionCancellationTokenSource.Dispose();
			_conversionCancellationTokenSource = null;
			Debug.Log("ConvertAuthoringDataRoutine complete. Process was " + (flag ? "cancelled" : "successful") + ".");
			onEcsStartCompete?.Invoke(!flag);
		};
		StartCoroutine(ConvertAuthoringDataRoutine(worldId, frameWorkloadTimer, callback));
		foreach (World allWorld in _allWorlds)
		{
			BurstDisabler.AddWorld(allWorld);
		}
	}

	private IEnumerator ConvertAuthoringDataRoutine(int worldId, WallClockTimer frameWorkloadTimer, Action callback)
	{
		AppendOrRemoveWorldsInCurrentPlayerLoop(addToCurrentPlayerLoop: false);
		Debug.Log("ECSManager: converting authoring data.");
		if (ServerWorld != null)
		{
			Debug.Log("ECSManager: converting authoring data for the server world.");
			IEnumerator convertAuthoringData = ConvertAuthoringData(ServerWorld, frameWorkloadTimer);
			while (convertAuthoringData.MoveNext())
			{
				yield return convertAuthoringData.Current;
				if (_conversionCancellationTokenSource.IsCancellationRequested)
				{
					Debug.LogWarning("ECSManager: ConvertAuthoringData cancelled.");
					callback?.Invoke();
					yield break;
				}
			}
			if (_conversionCancellationTokenSource.IsCancellationRequested)
			{
				callback?.Invoke();
				yield break;
			}
			Debug.Log("ECSManager: converting authoring data for the server world complete.");
		}
		yield return new WaitForEndOfFrame();
		if (ClientWorld != null)
		{
			Debug.Log("ECSManager: converting authoring data for the client world.");
			IEnumerator convertAuthoringData = ConvertAuthoringData(ClientWorld, frameWorkloadTimer);
			while (convertAuthoringData.MoveNext())
			{
				yield return convertAuthoringData.Current;
				if (_conversionCancellationTokenSource.IsCancellationRequested)
				{
					Debug.LogWarning("ECSManager: ConvertAuthoringData cancelled.");
					callback?.Invoke();
					yield break;
				}
			}
			if (_conversionCancellationTokenSource.IsCancellationRequested)
			{
				callback?.Invoke();
				yield break;
			}
			Debug.Log("ECSManager: converting authoring data for the client world complete.");
		}
		AppendOrRemoveWorldsInCurrentPlayerLoop(addToCurrentPlayerLoop: true);
		InitWorlds(worldId);
		callback?.Invoke();
	}

	private void InitWorlds(int worldId)
	{
		Debug.Log("ECSManager: initializing worlds.");
		if (ServerWorld != null)
		{
			InitWorld(ServerWorld);
			Manager.mod.Server.WorldCreated();
		}
		if (ClientWorld != null)
		{
			InitWorld(ClientWorld);
			Manager.mod.Client.WorldCreated();
		}
		if (worldId != -1 && ClientServerBootstrap.RequestedPlayType != ClientServerBootstrap.PlayType.Client)
		{
			Manager.networking.StartServer(ServerWorld);
		}
	}

	private void AppendOrRemoveWorldsInCurrentPlayerLoop(bool addToCurrentPlayerLoop)
	{
		Debug.Log("ECSManager: " + (addToCurrentPlayerLoop ? "adding worlds to" : "removing worlds from") + " the update loop.");
		foreach (World allWorld in _allWorlds)
		{
			if (addToCurrentPlayerLoop)
			{
				if (!ScriptBehaviourUpdateOrder.IsWorldInCurrentPlayerLoop(allWorld))
				{
					ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(allWorld);
				}
				else
				{
					Debug.LogWarning("ECSManager: world " + allWorld.Name + " already exists in the current player loop. Can't add it again.");
				}
			}
			else if (ScriptBehaviourUpdateOrder.IsWorldInCurrentPlayerLoop(allWorld))
			{
				ScriptBehaviourUpdateOrder.RemoveWorldFromCurrentPlayerLoop(allWorld);
			}
			else
			{
				Debug.LogWarning("ECSManager: world " + allWorld.Name + " doesn't exist in the current player loop. Can't remove it.");
			}
		}
	}

	private void ProcessSuspension()
	{
		if (_conversionCancellationTokenSource != null)
		{
			Debug.Log("ECSManager: cancelling conversion process.");
			_conversionCancellationTokenSource.Cancel();
		}
	}

	public bool QueueNewServerSave()
	{
		SaveSystem existingSystemManaged = ServerWorld.GetExistingSystemManaged<SaveSystem>();
		if (existingSystemManaged == null)
		{
			return false;
		}
		existingSystemManaged.QueueNewSave();
		return true;
	}

	private bool StartServerSave()
	{
		SaveSystem existingSystemManaged = ServerWorld.GetExistingSystemManaged<SaveSystem>();
		if (existingSystemManaged == null)
		{
			return false;
		}
		if (existingSystemManaged.SaveIsPending)
		{
			return true;
		}
		existingSystemManaged.Save();
		return true;
	}

	private World CreateClientWorld(string name)
	{
		World world = ClientServerBootstrap.CreateClientWorld(name);
		if (ClientWorld == null)
		{
			ClientWorld = world;
			clientDummySystem = world.CreateSystemManaged<ECSManagerDummySystem>();
			clientSyncPointECBS = world.GetOrCreateSystemManaged<BeginSimulationEntityCommandBufferSystem>();
		}
		return world;
	}

	private World CreateThinClientWorld()
	{
		World world = ClientServerBootstrap.CreateThinClientWorld();
		if (ClientWorld == null)
		{
			ClientWorld = world;
			clientDummySystem = world.CreateSystemManaged<ECSManagerDummySystem>();
		}
		return world;
	}

	private World CreateServerWorld(string name, int saveId)
	{
		World world = (ServerWorld = ClientServerBootstrap.CreateServerWorld(name));
		serverDummySystem = world.CreateSystemManaged<ECSManagerDummySystem>();
		Entity entity = world.EntityManager.CreateEntity();
		world.EntityManager.AddComponentData(entity, new ServerSaveIdCD
		{
			Value = saveId
		});
		Entity entity2 = world.EntityManager.CreateEntity();
		world.EntityManager.AddComponentData(entity2, new ServerSessionIdCD
		{
			Value = PlayerConnectRequestSystem.GenerateSessionID()
		});
		serverConnectionQ = GetServerEntityQuery(typeof(NetworkStreamConnection));
		serverLoadingDoneQ = GetServerEntityQuery(typeof(InitialLoadingDoneCD));
		return world;
	}

	public void EnableSave()
	{
		if (ServerWorld != null)
		{
			World serverWorld = ServerWorld;
			serverWorld.GetExistingSystemManaged<SerializationSystemGroup>().AddSystemToUpdateList(serverWorld.CreateSystem<SaveSystem>());
		}
		else
		{
			World clientWorld = ClientWorld;
			clientWorld.GetExistingSystemManaged<SerializationSystemGroup>().AddSystemToUpdateList(clientWorld.CreateSystem<SaveClientSystem>());
		}
	}

	public void UnloadWorlds()
	{
		try
		{
			UnloadWorldsInternal();
			Manager.networking.ResetConnectSettings();
			Manager.main.player = null;
		}
		catch (ArgumentException exception)
		{
			Debug.LogException(exception);
		}
	}

	public void CancelECSWorldConversionOrUnloadWorlds()
	{
		if (_conversionCancellationTokenSource != null)
		{
			_conversionCancellationTokenSource?.Cancel();
		}
		else
		{
			UnloadWorlds();
		}
	}

	public EntityQuery GetServerEntityQuery(params ComponentType[] comps)
	{
		return serverDummySystem.GetEntityQuery(comps);
	}

	public EntityQuery GetServerEntityQuery(params EntityQueryDesc[] descs)
	{
		return serverDummySystem.GetEntityQuery(descs);
	}

	public EntityQuery GetClientEntityQuery(params ComponentType[] components)
	{
		return clientDummySystem.GetEntityQuery(components);
	}

	public EntityQuery GetClientEntityQuery(params EntityQueryDesc[] descs)
	{
		return clientDummySystem.GetEntityQuery(descs);
	}

	private void UnloadWorldsInternal()
	{
		_allWorlds.Clear();
		IsClosing = true;
		if (ClientWorld != null || ServerWorld != null)
		{
			Manager.trace.GameEnd();
		}
		if (ClientWorld != null)
		{
			ClientWorld.EntityManager.CompleteAllTrackedJobs();
			Manager.networking.StopClient(ClientWorld);
			Manager.mod.Client.WorldDestroyed();
			ClientWorld.Dispose();
			ClientWorld = null;
		}
		if (ServerWorld != null)
		{
			ServerWorld.EntityManager.CompleteAllTrackedJobs();
			Manager.networking.StopServer(ServerWorld);
			Manager.mod.Server.WorldDestroyed();
			ServerWorld.Dispose();
			ServerWorld = null;
		}
		BurstDisabler.ResetWorlds();
	}

	private IEnumerator ConvertAuthoringData(World world, WallClockTimer frameWorkloadTimer)
	{
		_conversionCancellationTokenSource = new CancellationTokenSource();
		if (WorldExtensions.GetExistingSystem<SceneSystem>(world) == SystemHandle.Null)
		{
			Debug.Log(world.Name + " has no SceneSystem");
			_conversionCancellationTokenSource.Cancel();
			yield break;
		}
		using ConversionManager converter = new ConversionManager(new ConversionManager.ConversionParameters
		{
			TargetWorld = world,
			BlobAssetStore = Manager.ecs.BlobAssetStore,
			PropertyBuilder = new PropertyLookupBuilder(),
			GhostConfigOverride = new GhostConfigFromIMonoBehaviourData(),
			ReservedObjectIndices = CalculateReservedObjectIndices(),
			UseHardModeSettings = (world.IsServer() && Manager.saves.IsWorldModeEnabled(WorldMode.Hard)),
			UseCasualModeSettings = (world.IsServer() && Manager.saves.IsWorldModeEnabled(WorldMode.Casual)),
			IsServer = world.IsServer()
		}, _cachedPugConverterTypes);
		ConfigurePostConverters(converter);
		GameObject authoringPrefab = (world.IsServer() ? Manager.ecs.serverAuthoringPrefab : Manager.ecs.clientAuthoringPrefab);
		converter.EnqueueGameObjectHierarchy(authoringPrefab);
		IEnumerator convert = converter.ConvertEnqueuedObjects(_conversionCancellationTokenSource, frameWorkloadTimer);
		while (convert.MoveNext())
		{
			yield return convert.Current;
			if (_conversionCancellationTokenSource.IsCancellationRequested)
			{
				Debug.LogWarning("ECSManager: ConvertAuthoringData cancelled.");
				yield break;
			}
		}
		world.EntityManager.Instantiate(converter.GetEntity(authoringPrefab));
		GC.Collect();
		Debug.Log("ECSManager: " + world.Name + " conversion complete.");
	}

	public static void ConfigurePostConverters(ConversionManager conversionManager)
	{
		conversionManager.AddPostConverter(new InteractablePostConverter());
		conversionManager.AddPostConverter(new OutlinePostConverter());
		conversionManager.AddPostConverter(new DropLootPostConverter());
		conversionManager.AddPostConverter(new RotationPostConverter());
		conversionManager.AddPostConverter(new BoatRidingColliderVariationPostConverter());
		conversionManager.AddPostConverter(new ReceivePushbackPostConverter());
		conversionManager.AddPostConverter(new DisablePhysicsRestoreConverter());
		conversionManager.AddPostConverter(new PredictedTransformSmoothingPostConverter());
		conversionManager.AddPostConverter(new MoveToPredictionPostConverter());
		conversionManager.AddPostConverter(new ModPostConverter());
		conversionManager.AddPostConverter(new CustomScenePostConverter());
		conversionManager.AddPostConverter(new PugDatabasePostConverter());
		conversionManager.AddPostConverter(new GhostPostConverter());
	}

	private void InitWorld(World world)
	{
		Manager.networking.InitWorld(world);
		Manager.physics.InitWorld(world);
		DefaultVariantSystemGroup existingSystemManaged = world.GetExistingSystemManaged<DefaultVariantSystemGroup>();
		if (existingSystemManaged != null)
		{
			existingSystemManaged.Enabled = false;
			Debug.Log("disable default variant system group for world " + world.Name);
		}
		SystemHandle existingSystem = WorldExtensions.GetExistingSystem<CompanionGameObjectUpdateTransformSystem>(world);
		if (existingSystem != SystemHandle.Null)
		{
			world.Unmanaged.ResolveSystemStateRef(existingSystem).Enabled = false;
			Debug.Log("disable CompanionGameObjectUpdateTransformSystem for world " + world.Name);
		}
		SystemHandle existingSystem2 = WorldExtensions.GetExistingSystem<ParentSystem>(world);
		if (existingSystem2 != SystemHandle.Null)
		{
			world.Unmanaged.ResolveSystemStateRef(existingSystem2).Enabled = false;
			Debug.Log("disable ParentSystem for world " + world.Name);
		}
	}

	public EntityCommandBuffer CreateSyncPointCommandBufferClient()
	{
		return clientSyncPointECBS.CreateCommandBuffer();
	}
}
