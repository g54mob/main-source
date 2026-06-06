using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

public class WorldManager : SceneBehaviour
{
	public delegate bool IsInRadius(Vector3 position);

	public bool LoadWorld = true;

	[Header("Debug")]
	[Tooltip("Seeds used for the tile generator. 0 -> first region, 1 -> second region, etc. When no seed is specified for a reagion, the seed is randomly generated.")]
	[SerializeField]
	private int[] _tileGenerationsSeeds;

	private WorldProperties _properties;

	private IWorldRegion _region;

	private WorldRegionProperties _regionProperties;

	private Rigidbody _terrainRigidBody;

	private Transform _worldHeader;

	private CircleWaveHighlighter _constructionRadiusBorder;

	private Vector3 _townheartScenePosition = Vector3.zero;

	private float _swimmingRadius;

	private float _mapRadius;

	private float _destructionRadius;

	private GameData _gameData;

	private int _tileGenerationIndex;

	private CircleWaveHighlighter _swimmingRangeHighlighter;

	private CircleWaveHighlighter _boatRangeHighlighter;

	private WorldMapTownheart _worldMapTownheart;

	public bool Initialized { get; private set; }

	public World World { get; private set; }

	public Transform WorldParent { get; private set; }

	public Transform FlotsamParent { get; private set; }

	public List<Flotsam> FlotsamInWorld { get; } = new List<Flotsam>();

	public Vector3 WorldCenter { get; private set; } = Vector3.zero;

	public float InteractableRadius { get; private set; }

	public IWorldRegion CurrentRegion => ReturnCurrentRegion();

	public static TileProperties TileProperties { get; private set; }

	public static GameMode GameMode
	{
		get
		{
			if (TryReturnWorld(out var world))
			{
				return world.TileProperties.GameMode;
			}
			if ((bool)TileProperties)
			{
				return TileProperties.GameMode;
			}
			return GameMode.Classic;
		}
	}

	public static bool IsProcedural { get; private set; }

	public static bool HasEndTile
	{
		get
		{
			if (TryReturnWorld(out var world))
			{
				return world.HasEndTile;
			}
			return false;
		}
	}

	public static List<WorldTileSpawningBlocker> SpawningBlockers { get; private set; } = new List<WorldTileSpawningBlocker>();

	private void LateUpdate()
	{
		if ((bool)_worldMapTownheart && _worldMapTownheart.IsMoving)
		{
			OnTownheartMoved(_worldMapTownheart.Position.Vector2TopDown());
		}
		int count = SpawningBlockers.Count;
		while (0 < count--)
		{
			SpawningBlockers[count].LateUpdate();
		}
	}

	private void FixedUpdate()
	{
		if (GameManager.Instance.InitializeEnvironment)
		{
			MoveWorld();
		}
	}

	private void OnDestroy()
	{
		Community.DestroyAll();
		World?.OnDestroy();
		SpawningBlockers.Clear();
		GameEventDispatcher.RemoveListener(GameEventType.ItemSalvaged, OnItemSalvaged);
	}

	private void OnDrawGizmos()
	{
	}

	public void Initialize()
	{
		_properties = GameManager.Settings.WorldSettings;
		string text = "==WorldVisuals==";
		if (_worldHeader == null)
		{
			_worldHeader = new GameObject(text).transform;
		}
		CreateWorldParent();
		if (FlotsamParent == null)
		{
			FlotsamParent = new GameObject("FlotsamParent").transform;
		}
		_mapRadius = GameManager.Settings.GameplaySettings.MapRadius;
		InteractableRadius = GameSettings.Instance.GameplaySettings.InteractionRadius + 50;
		_destructionRadius = GameManager.Settings.GameplaySettings.DestructionRadius;
		_swimmingRadius = GameManager.Settings.GameplaySettings.SwimmingRadius;
		_gameData = GameManager.GameStatsManager.GameData;
		GameEventDispatcher.AddListener(GameEventType.ItemSalvaged, OnItemSalvaged);
		Initialized = true;
	}

	public void SetWorld(World world)
	{
		World = world;
		IsProcedural = world.ReturnIsProcedural();
	}

	private void OnTownheartMoved(Vector2 townheartPosition)
	{
		if (World == null)
		{
			return;
		}
		if (World.TryReturnRegionContainingPosition(out var region, townheartPosition))
		{
			if (_region != region)
			{
				_region = region;
				_regionProperties = _properties.ReturnRegionProperties(_region.Type);
				_region.Enter();
			}
		}
		else
		{
			_region = null;
			_regionProperties = _properties.ReturnRegionProperties(WorldRegionType.None);
		}
	}

	public void GenerateCommunitiesAndPopulateWorld()
	{
		GenerateCommunities();
		if (TileProperties == null)
		{
			TileProperties = _properties.DefaultTileProperties;
			SetTileProperties(TileProperties);
		}
		World world = new World(TileProperties);
		world.Spawn().Activate();
		SetWorld(world);
		if (_region is VoronoiWorldRegion { ScoutingLandmark: not null } voronoiWorldRegion)
		{
			voronoiWorldRegion.ScoutingLandmark.SetScoutingState(ScoutingState.Scouted);
		}
	}

	private void GenerateCommunities()
	{
		for (int i = 0; i < 5; i++)
		{
			new Community();
		}
		new Community("", Community.Type.Player);
		new Community("", Community.Type.Abandoned);
	}

	public void ShowConstructionBorder(bool enabled)
	{
		if (_constructionRadiusBorder == null)
		{
			_constructionRadiusBorder = UnityEngine.Object.Instantiate(GameManager.Settings.FXSettings.BuildingRadiusPrefab);
			_constructionRadiusBorder.name = "Construction Border";
			_constructionRadiusBorder.Initialize(GameManager.Settings.GameplaySettings.ConstructionRadius, Vector3.zero, GameManager.Settings.FXSettings.BuildingRadiusColor);
		}
		_constructionRadiusBorder.gameObject.transform.position = _townheartScenePosition;
		_constructionRadiusBorder.gameObject.SetActive(enabled);
	}

	public Vector3 ReturnSpawnPoint(float spawnRadius, float spawnRadiusDeviation, float spawnArc)
	{
		Vector3 positionTownheart = GameManager.Settings.SessionSettings.StartingScenario.PositionTownheart;
		float num = UnityEngine.Random.Range(spawnRadius - spawnRadiusDeviation, spawnRadius);
		float angle = UnityEngine.Random.Range((0f - spawnRadiusDeviation) / 2f, spawnRadiusDeviation / 2f);
		return positionTownheart + Quaternion.AngleAxis(angle, Vector3.up) * (-GameManager.PhysicsManager.MovingFlotsamDirection * num);
	}

	public Vector3 ReturnSpawnPoint(bool canBeOutsideReachableRadius = true)
	{
		int num = (canBeOutsideReachableRadius ? GameManager.Settings.GameplaySettings.DestructionRadius : GameManager.Settings.GameplaySettings.MapRadius);
		return ReturnSpawnPoint(num, GameManager.Settings.GameplaySettings.SpawnRadiusDeviation, GameManager.Settings.GameplaySettings.SpawningArcLength);
	}

	public bool IsInteractable(Vector3 position)
	{
		return position.IsInRange(_townheartScenePosition, InteractableRadius);
	}

	public bool IsInSpawnRadius(Vector3 position)
	{
		return position.IsInRange(_townheartScenePosition, _mapRadius + 250f);
	}

	public bool IsInSwimmingRadius(Vector3 position)
	{
		return position.IsInRange(_townheartScenePosition, _swimmingRadius);
	}

	public bool IsInSwimmingRadiusOnWorldMap(Vector3 position)
	{
		if (UIManager.State != UIState.Map)
		{
			return IsInSwimmingRadius(position);
		}
		return position.IsInRange(GameManager.WorldMapManager.WorldMap.Townheart.Position, _swimmingRadius);
	}

	public bool IsInBoatRadius(Vector3 position)
	{
		return position.IsInRange(_townheartScenePosition, GameManager.Settings.GameplaySettings.InteractionRadius);
	}

	public bool IsNearInteractableRadius(Vector3 position, float threshold)
	{
		float num = _mapRadius * _mapRadius;
		float num2 = _townheartScenePosition.DistanceToLeveledSquared(position);
		float num3 = threshold * threshold;
		if (num2 < num)
		{
			return num - num2 < num3;
		}
		return num2 - num < num3;
	}

	public bool IsOutsideDestructionRadius(Vector3 position)
	{
		return !position.IsInRange(_townheartScenePosition, _destructionRadius);
	}

	public FlotsamBehaviour SpawnAndThrowFlotsam(ThrowProperties throwProperties)
	{
		FlotsamPool.Instance.Aquire(out var flotsam, throwProperties.FlotsamProperties, throwProperties.StartPosition, !throwProperties.VisualsOnly);
		flotsam.Throw(throwProperties);
		return flotsam;
	}

	public void AddFlotsam(Flotsam flotsam)
	{
		World.AddFlotsam(flotsam);
	}

	public void ShowSwimmingRange()
	{
		if (_swimmingRangeHighlighter == null)
		{
			_swimmingRangeHighlighter = UnityEngine.Object.Instantiate(GameManager.Settings.FXSettings.CircleHighlighterPrefab.gameObject, Buildable.BuildableParent).GetComponent<CircleWaveHighlighter>();
			_swimmingRangeHighlighter.Initialize(GameManager.Settings.GameplaySettings.SwimmingRadius, Vector3.zero, GameManager.Settings.FXSettings.SwimmingRangeHighlighterColor);
		}
		_swimmingRangeHighlighter.gameObject.SetActive(value: true);
	}

	public void HideSwimmingRange()
	{
		if (!(_swimmingRangeHighlighter == null))
		{
			_swimmingRangeHighlighter.gameObject.SetActive(value: false);
		}
	}

	public void ShowBoatRange()
	{
		if (_boatRangeHighlighter == null)
		{
			_boatRangeHighlighter = UnityEngine.Object.Instantiate(GameManager.Settings.FXSettings.CircleHighlighterPrefab.gameObject, Buildable.BuildableParent).GetComponent<CircleWaveHighlighter>();
			_boatRangeHighlighter.Initialize(GameManager.Settings.GameplaySettings.InteractionRadius, Vector3.zero, GameManager.Settings.FXSettings.BoatRangeHighlighterColor);
		}
		_boatRangeHighlighter.gameObject.SetActive(value: true);
	}

	public void HideBoatRange()
	{
		if (!(_boatRangeHighlighter == null))
		{
			_boatRangeHighlighter.gameObject.SetActive(value: false);
		}
	}

	private int ReturnItemCount(ItemProperties itemProperties, Community community, InventoryAuditor itemsInRange)
	{
		int num = community.Inventory.ReturnCount(itemProperties);
		foreach (Agent agent in community.Agents)
		{
			num += agent.Inventory.ReturnCount(itemProperties, SubInventoryType.Storage);
		}
		return num + itemsInRange.ReturnItemCount(itemProperties);
	}

	private void OnItemSalvaged(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent)
		{
			World.OnItemSalvaged(itemEvent.Item);
		}
	}

	public static void SetTileProperties(TileProperties tileProperties)
	{
		TileProperties = tileProperties;
	}

	public static void ClearFogOfWar(ISpawner spawner)
	{
		if (TryReturnWorld(out var world))
		{
			world.ClearFogOfWar(spawner);
		}
	}

	public int ReturnTileSeed()
	{
		return (int)DateTime.Now.Ticks;
	}

	public WorldRegionProperties ReturnRegionProperties(WorldRegionType type)
	{
		return _properties.ReturnRegionProperties(type);
	}

	private IWorldRegion ReturnCurrentRegion()
	{
		if (_region == null)
		{
			if ((bool)GameManager.WorldMapManager && (bool)GameManager.WorldMapManager.WorldMap)
			{
				_worldMapTownheart = GameManager.WorldMapManager.WorldMap.Townheart;
			}
			if (_worldMapTownheart == null)
			{
				Debug.LogException(new Exception("WorldManager._worldMapTownheart == null"));
			}
			else
			{
				OnTownheartMoved((_worldMapTownheart.Initialized ? _worldMapTownheart.Position : World.TownheartWorldPosition).Vector2TopDown());
			}
		}
		return _region;
	}

	public static bool TryReturnCurrentRegion(out IWorldRegion region)
	{
		region = (TryReturnInstance(out var instance) ? instance.CurrentRegion : null);
		return region != null;
	}

	public static float ReturnTownheartMaxX()
	{
		if (!TryReturnWorld(out var world))
		{
			return 0f;
		}
		return world.TownheartMaxX;
	}

	public static bool TryReturnRegionContainingWorldPosition(out IWorldRegion region, Vector3 worldPosition)
	{
		region = null;
		if (TryReturnWorld(out var world))
		{
			return world.TryReturnRegionContainingPosition(out region, worldPosition.Vector2TopDown());
		}
		return false;
	}

	public static bool TryReturnRegionProperties(out WorldRegionProperties regionProperties)
	{
		regionProperties = (TryReturnInstance(out var instance) ? instance._regionProperties : null);
		return regionProperties != null;
	}

	public static bool IsInInteractionRadius(Vector3 position)
	{
		return position.IsInRange(Construction.TownheartPosition, GameSettings.Instance.GameplaySettings.InteractionRadius);
	}

	public static int ReturnTileGenerationSeed()
	{
		if (!TryReturnInstance(out var instance))
		{
			return (int)DateTime.Now.Ticks;
		}
		return instance.ReturnTileSeed();
	}

	public static int ReturnSalvagedItemCount()
	{
		if (TryReturnWorld(out var world))
		{
			return world.SalvagedItemCount;
		}
		return 0;
	}

	public static bool TryReturnClosestRoadInRange(out RoadSpawner closestRoad, Vector3 position, float range)
	{
		throw new NotImplementedException();
	}

	public static bool TryReturnClosestFlotsamItemProperties(Vector3 position, float range, out ItemProperties itemProperties)
	{
		using (ListPool<FlotsamSpawner>.Get())
		{
			itemProperties = null;
			if (TryReturnWorld(out var world))
			{
				float shortestDistanceSquared = float.MaxValue;
				FlotsamSpawner flotsamSpawner = null;
				using ListPool<PointOfInterestSpawner>.List list = ListPool<PointOfInterestSpawner>.Get();
				world.ReturnOverlappingPointsOfInterest(position, list);
				foreach (PointOfInterestSpawner item in list)
				{
					flotsamSpawner = item.ReturnClosestFlotsamSpawner(position, ref shortestDistanceSquared, flotsamSpawner);
				}
				if (flotsamSpawner == null || !flotsamSpawner.Instance.transform.position.IsInRange(position, range))
				{
					return false;
				}
				InventoryAuditor.Global.Reset();
				flotsamSpawner.CountItems(InventoryAuditor.Global);
				itemProperties = InventoryAuditor.Global.ReturnNonZeroItem();
				return itemProperties != null;
			}
			return false;
		}
	}

	public static Vector3 ReturnLocalToWorldPosition(Vector3 localPosition)
	{
		if (TryReturnWorld(out var world))
		{
			return world.TownheartRotation * localPosition + world.TownheartWorldPosition;
		}
		return localPosition;
	}

	public static int ReturnLandmarkIndex(LandmarkBehaviour landmarkBehaviour)
	{
		throw new NotImplementedException();
	}

	public static bool TryReturnClosestSpawnerWithLandmarkAction<T>(out LandmarkSpawner spawner, float range, ScoutingState maximumScouting) where T : LandmarkAction
	{
		spawner = null;
		if (TryReturnWorld(out var world))
		{
			return world.TryReturnClosestSpawnerWithLandmarkAction<T>(out spawner, range, maximumScouting);
		}
		return false;
	}

	public static bool TryReturnClosestUnscoutedLandmarkInRange(out LandmarkSpawner spawner, float range, float offsetMinimumX = 0f, WorldMapScoutingId filter = WorldMapScoutingId.None)
	{
		spawner = null;
		if (TryReturnWorld(out var world))
		{
			return world.TryReturnClosestUnscoutedLandmarkInRange(out spawner, range, offsetMinimumX, filter);
		}
		return false;
	}

	public static bool TryReturnLandmarkSpawner(out LandmarkSpawner landmarkSpawner, int tileIndex, int spawnerIndex)
	{
		landmarkSpawner = null;
		if (TryReturnWorld(out var world))
		{
			return world.TryReturnLandmarkSpawner(out landmarkSpawner, tileIndex, spawnerIndex);
		}
		return false;
	}

	public static bool CanAddNextTile()
	{
		if (TryReturnWorld(out var world))
		{
			return world.CanAddNextTile();
		}
		return false;
	}

	public static bool CanPruneWorldTile(WorldTile worldTile)
	{
		foreach (WorldTileSpawningBlocker spawningBlocker in SpawningBlockers)
		{
			if (spawningBlocker.BlocksPruning(worldTile))
			{
				return false;
			}
		}
		return true;
	}

	public static bool TryReturnNextTile(WorldTile currentTile, out WorldTile nextTile)
	{
		if (TryReturnWorld(out var world))
		{
			for (int i = 0; i < world.Tiles.Count; i++)
			{
				int num = i + 1;
				if (world.Tiles[i] == currentTile && num < world.Tiles.Count)
				{
					nextTile = world.Tiles[num];
					return true;
				}
			}
		}
		nextTile = null;
		return false;
	}

	public static int ReturnLastTileIndex()
	{
		if (TryReturnWorld(out var world) && !world.Tiles.IsNullOrEmpty())
		{
			return world.Tiles[world.Tiles.Count - 1].Index;
		}
		return 0;
	}

	public static bool TryReturnWorldTileSpawningBlocker(out WorldTileSpawningBlocker worldTileSpawningBlocker)
	{
		worldTileSpawningBlocker = null;
		if (TryReturnWorld(out var world))
		{
			return world.TryReturnWorldTileSpawningBlocker(out worldTileSpawningBlocker);
		}
		return false;
	}

	private static bool TryReturnInstance(out WorldManager instance)
	{
		instance = GameManager.WorldManager;
		return instance != null;
	}

	private static bool TryReturnWorld(out World world)
	{
		world = (TryReturnInstance(out var instance) ? instance.World : null);
		return world != null;
	}

	public static Vector3 WaterAdjustedPosition(Vector3 inputPosition)
	{
		return FlotsamGame.SetY(inputPosition, WaterManager.ReturnWaterHeight(inputPosition.x, inputPosition.z));
	}

	public static Vector3 WaterAdjustedPosition(Vector2 inputPosition)
	{
		return inputPosition.Vector3TopDown(WaterManager.ReturnWaterHeight(inputPosition.x, inputPosition.y));
	}

	public static float WaterHeight(float groundPositionX, float groundPositionZ)
	{
		return WaterManager.Instance.ReturnWaterHeightOnPoint(groundPositionX, groundPositionZ);
	}

	public static Rect ReturnWorldBounds()
	{
		if (TryReturnWorld(out var world) && !world.Tiles.IsNullOrEmpty())
		{
			Rect worldBounds = world.Tiles[0].WorldBounds;
			Vector2 min = worldBounds.min;
			Vector2 max = worldBounds.max;
			for (int i = 1; i < world.Tiles.Count; i++)
			{
				worldBounds = world.Tiles[i].WorldBounds;
				if (worldBounds.min.x < min.x)
				{
					min.x = worldBounds.min.x;
				}
				if (worldBounds.min.y < min.y)
				{
					min.y = worldBounds.min.y;
				}
				if (max.x < worldBounds.max.x)
				{
					max.x = worldBounds.max.x;
				}
				if (max.y < worldBounds.max.y)
				{
					max.y = worldBounds.max.y;
				}
			}
			return new Rect(min, max - min);
		}
		return default(Rect);
	}

	public static float ReturnFirstTileOffsetX()
	{
		if (!TryReturnWorld(out var world))
		{
			return 0f;
		}
		return world.FirstTileOffsetX;
	}

	public void CreateWorldParent()
	{
		if (!(WorldParent != null))
		{
			WorldParent = new GameObject().transform;
			WorldParent.name = "WorldParent";
			_terrainRigidBody = WorldParent.gameObject.AddComponent<Rigidbody>();
			_terrainRigidBody.mass = GameManager.Settings.GameplaySettings.WorldPhysics.WorldMass;
			_terrainRigidBody.linearDamping = GameManager.Settings.GameplaySettings.WorldPhysics.WorldDrag;
			_terrainRigidBody.angularDamping = GameManager.Settings.GameplaySettings.WorldPhysics.WorldAngularDrag;
			_terrainRigidBody.useGravity = false;
		}
	}

	public void SetWorldDistanceTravelled(float distanceTravelled)
	{
		Vector3 position = _terrainRigidBody.transform.position;
		position.z = distanceTravelled;
		_terrainRigidBody.transform.position = position;
	}

	private void MoveWorld()
	{
		Vector3 force = GameManager.PhysicsManager.MovingWorldDirection * GameManager.PhysicsManager.MovingWorldForce * Time.fixedDeltaTime;
		_terrainRigidBody.AddForce(force);
		_gameData.DistanceTravelled = _terrainRigidBody.transform.position.z;
		_gameData.CurrentVelocity = _terrainRigidBody.linearVelocity.magnitude;
	}

	public void StopWorldMovement()
	{
		_terrainRigidBody.linearVelocity = Vector3.zero;
	}
}
