using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Events;

public class WorldTile : IPersistentReference, IWorldTile, IRangeTester
{
	private readonly List<PointOfInterestSpawner> _pointsOfInterest = new List<PointOfInterestSpawner>();

	private readonly List<LandmarkSpawner> _landmarks = new List<LandmarkSpawner>();

	private readonly List<RoadSpawner> _roads = new List<RoadSpawner>(32);

	private readonly List<IWorldRegion> _regions = new List<IWorldRegion>(32);

	private readonly List<WorldRegionType> _regionTypes = new List<WorldRegionType>(8);

	private readonly TileGeneratorBase _tileGenerator;

	private Transform _flotsamParent;

	private Transform _landmarkParent;

	private readonly FlotsamSpawnerGroup _flotsamSpawnerGroup = new FlotsamSpawnerGroup();

	private readonly SpawnPositionProviderBase _initialPositionProvider;

	private Rect _bounds;

	private Rect _worldBounds;

	public TileProperties Properties { get; }

	public TileGenerator TileGeneratorPrefab { get; private set; }

	public TileGeneratorBase SubTileGeneratorPrefab { get; private set; }

	public WorldMapFogOfWar.PersistentData FogOfWarPersistentData { get; private set; }

	public IReadOnlyList<PointOfInterestSpawner> PointsOfInterest => _pointsOfInterest;

	public IReadOnlyList<LandmarkSpawner> Landmarks => _landmarks;

	public IReadOnlyList<RoadSpawner> Roads => _roads;

	public IReadOnlyList<IWorldRegion> Regions => _regions;

	public Rect FogOfWarBounds { get; private set; }

	public byte[] FogOfWarAlphas { get; private set; }

	public float Scale { get; set; }

	public int SalvagedItemCount { get; set; }

	public Vector2 Offset { get; private set; }

	public Vector3 WorldPosition { get; private set; }

	public Rect WorldBounds => _worldBounds;

	public WorldTile Antecede { get; private set; }

	public int Index { get; private set; }

	public Vector3 StartPosition { get; private set; }

	public bool IsActive { get; private set; } = true;

	public bool IsEndTile
	{
		get
		{
			if (SubTileGeneratorPrefab != null)
			{
				return SubTileGeneratorPrefab.IsEndTile;
			}
			return false;
		}
	}

	public UnityEvent<WorldTile> OnInitialized { get; private set; } = new UnityEvent<WorldTile>();

	public int PersistentIndex { get; set; } = -1;

	public WorldTile(TileProperties properties)
		: this(properties.TileGenerator, null)
	{
		Properties = properties;
	}

	public WorldTile(TileGenerator tileGeneratorPrefab, TileGeneratorBase subTileGeneratorPrefab, bool startingTile = false)
	{
		TileGeneratorPrefab = tileGeneratorPrefab;
		SubTileGeneratorPrefab = subTileGeneratorPrefab;
		if (Application.isEditor && tileGeneratorPrefab == null)
		{
			_tileGenerator = Object.Instantiate(subTileGeneratorPrefab);
		}
		else
		{
			_tileGenerator = Object.Instantiate(tileGeneratorPrefab);
			if (subTileGeneratorPrefab != null && _tileGenerator is TileGenerator tileGenerator)
			{
				tileGenerator.OverrideSubTileGenerator(Object.Instantiate(subTileGeneratorPrefab));
			}
		}
		_tileGenerator.Initialize(startingTile);
		_initialPositionProvider = GameManager.Settings.WorldSettings.ActivateTileSpawnPositionProvider;
		_initialPositionProvider.Initialize(GameManager.Settings.GameplaySettings, Vector3.zero);
	}

	public void Initialize(bool synchronous = false)
	{
		InitializeShared();
		if (synchronous)
		{
			CoroutineRunner.RunCoroutine(InitializeCoroutine());
		}
		else
		{
			GameManager.WorldManager.StartCoroutine(InitializeCoroutine());
		}
	}

	private IEnumerator InitializeCoroutine()
	{
		yield return _tileGenerator.Generate(this, WorldManager.ReturnTileGenerationSeed());
		StartPosition = _tileGenerator.StartPosition.Vector3TopDown();
		Scale = _tileGenerator.Scale;
		FogOfWarBounds = (_worldBounds = _bounds);
		OnInitialized.Invoke(this);
	}

	public void Restore(int index)
	{
		InitializeShared();
		Index = index;
		_tileGenerator.Restore(this);
		_worldBounds = _bounds;
	}

	private void InitializeShared()
	{
		_flotsamSpawnerGroup.ClearSpawners();
		_bounds = (_worldBounds = _tileGenerator.MinimumBounds);
	}

	public void RestoreFogOfWar(WorldMapFogOfWar.PersistentData persistentData)
	{
		FogOfWarBounds = (_worldBounds = persistentData.Bounds);
		FogOfWarAlphas = persistentData.Alphas;
		FogOfWarPersistentData = persistentData;
	}

	public void RestoreFogOfWar(byte[] alphas)
	{
		FogOfWarBounds = _bounds;
		FogOfWarAlphas = alphas;
	}

	public void Dispose()
	{
		Despawn(destroyInstance: false);
		_flotsamSpawnerGroup.ClearSpawners();
		_pointsOfInterest.Clear();
		_landmarks.Clear();
		_roads.Clear();
		IsActive = false;
	}

	public bool Despawn(bool destroyInstance)
	{
		_flotsamSpawnerGroup.Despawn(destroyInstance);
		foreach (PointOfInterestSpawner item in _pointsOfInterest)
		{
			item.Despawn(destroyInstance);
		}
		foreach (LandmarkSpawner landmark in _landmarks)
		{
			landmark.Despawn(destroyInstance);
		}
		foreach (RoadSpawner road in _roads)
		{
			road.Despawn(destroyInstance);
		}
		return true;
	}

	public void SetAntecede(WorldTile antecede)
	{
		if (antecede == null)
		{
			return;
		}
		Antecede = antecede;
		Index = antecede.Index + 1;
		Offset = new Vector2(antecede.WorldBounds.xMax + WorldBounds.size.x / 2f, 0f);
		WorldPosition = Offset.Vector3TopDown();
		foreach (PointOfInterestSpawner item in _pointsOfInterest)
		{
			item.SetWorldTileOffset(Offset);
		}
		foreach (LandmarkSpawner landmark in _landmarks)
		{
			landmark.SetWorldTileOffset(Offset);
		}
		foreach (RoadSpawner road in _roads)
		{
			road.SetWorldTileOffset(Offset);
		}
		foreach (IWorldRegion region in _regions)
		{
			region.SetWorldTile(this);
		}
		_worldBounds.center += Offset;
	}

	public void Activate()
	{
		_flotsamParent = GameManager.WorldManager.FlotsamParent;
		_landmarkParent = GameManager.WorldManager.WorldParent;
	}

	public void AddFlotsam(Flotsam flotsam)
	{
		_flotsamSpawnerGroup.AddFlotsam(flotsam);
	}

	public void AddRegion(IWorldRegion region)
	{
		region.SetWorldTile(this);
		_regions.Add(region);
		_regionTypes.AddUnique(region.Type);
	}

	public void AddRegions(IEnumerable<IWorldRegion> regions)
	{
		foreach (IWorldRegion region in regions)
		{
			AddRegion(region);
		}
	}

	public void AddRoadSpawner(RoadSpawner road)
	{
		_roads.Add(road);
	}

	public void AddRoadSpawners(IEnumerable<RoadSpawner> roads)
	{
		_roads.AddRange(roads);
	}

	public void AddLandmarkSpawner(LandmarkSpawner landmarkSpawner)
	{
		_landmarks.Add(landmarkSpawner);
		using (List<IWorldRegion>.Enumerator enumerator = _regions.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.TryAddLandmarkSpawner(landmarkSpawner))
			{
			}
		}
		UpdateSize(landmarkSpawner);
	}

	public void RemoveLandmarkSpawner(LandmarkSpawner landmarkSpawner)
	{
		_landmarks.Remove(landmarkSpawner);
	}

	public void AddPointOfInterestSpawner(PointOfInterestSpawner pointOfInterestSpawner)
	{
		AddPointOfInterestSpawner(pointOfInterestSpawner, initialize: true);
	}

	public void AddPointOfInterestSpawner(PointOfInterestSpawner pointOfInterestSpawner, bool initialize)
	{
		if (initialize)
		{
			pointOfInterestSpawner.Initialize();
		}
		pointOfInterestSpawner.WorldTile = this;
		pointOfInterestSpawner.AddSpawnerListeners();
		_pointsOfInterest.Add(pointOfInterestSpawner);
		UpdateSize(pointOfInterestSpawner);
		MapEvent.DispatchPointOfInterestSpawned(this, pointOfInterestSpawner);
	}

	public void PopulateRegionNeighbors()
	{
	}

	public void RepositionTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
	{
		_flotsamSpawnerGroup.ClearSpawners();
		foreach (LandmarkSpawner landmark in _landmarks)
		{
			landmark.RepositionRelativeToTownheart(townheartPosition, townheartRotation);
		}
		GameEventDispatcher.Dispatch(new GameEvent(GameEventType.UpdateAllObstacles));
		foreach (LandmarkSpawner landmark2 in _landmarks)
		{
			landmark2.Spawn(_landmarkParent);
		}
		foreach (PointOfInterestSpawner item in _pointsOfInterest)
		{
			item.RepositionRelativeToTownheart(townheartPosition, townheartRotation);
			item.Spawn(_flotsamParent);
		}
		foreach (RoadSpawner road in _roads)
		{
			road.RepositionRelativeToTownheart(townheartPosition, townheartRotation);
			road.Spawn();
		}
	}

	private void UpdateSize(ISpawner spawner)
	{
		Vector2 worldPosition2D = spawner.WorldPosition2D;
		if (worldPosition2D.x < _bounds.xMin)
		{
			_bounds.xMin = worldPosition2D.x;
		}
		if (worldPosition2D.y < _bounds.yMin)
		{
			_bounds.yMin = worldPosition2D.y;
		}
		if (_bounds.xMax < worldPosition2D.x)
		{
			_bounds.xMax = worldPosition2D.x;
		}
		if (_bounds.yMax < worldPosition2D.y)
		{
			_bounds.yMax = worldPosition2D.y;
		}
	}

	public Rect ReturnBounds()
	{
		return _bounds;
	}

	public bool IsInRange(Transform transform)
	{
		return transform.position.magnitude < (float)GameManager.Settings.GameplaySettings.DestructionRadius;
	}

	public bool TryReturnTownheartStartPosition(out Vector3 position)
	{
		if ((bool)_tileGenerator)
		{
			return _tileGenerator.TryReturnTownheartStartPosition(out position);
		}
		position = default(Vector3);
		return false;
	}

	public bool TryReturnRegionContainingPosition(out IWorldRegion region, Vector2 worldPosition)
	{
		Vector2 point = worldPosition - Offset;
		if (_bounds.Contains(point))
		{
			for (int i = 0; i < _regions.Count; i++)
			{
				region = _regions[i];
				if (region.Bounds.Contains(worldPosition) && region.ReturnContainsPosition(worldPosition))
				{
					return true;
				}
			}
		}
		region = null;
		return false;
	}

	public bool TryReturnWorldMapRegionMeshAndBounds(out Mesh mesh, out Rect bounds)
	{
		mesh = null;
		bounds = default(Rect);
		if ((bool)_tileGenerator)
		{
			return _tileGenerator.TryReturnWorldMapRegionMeshAndBounds(out mesh, out bounds);
		}
		return false;
	}

	public int ReturnLandmarkIndex(LandmarkBehaviour landmarkBehaviour)
	{
		int count = _landmarks.Count;
		for (int i = 0; i < count; i++)
		{
			if (_landmarks[i].LandmarkBehaviour == landmarkBehaviour)
			{
				return i;
			}
		}
		return -1;
	}

	public void ReturnOverlappingPointsOfInterest(Vector3 spawnPosition, List<PointOfInterestSpawner> pointsOfInterest)
	{
		foreach (PointOfInterestSpawner item in _pointsOfInterest)
		{
			if (item.State == ISpawnerState.Interactable && spawnPosition.IsInRangeXZ(item.SpawnPosition, item.Properties.Radius))
			{
				pointsOfInterest.Add(item);
			}
		}
	}

	public bool IsParentOfLandmarkSpawner(LandmarkSpawner landmarkSpawner)
	{
		foreach (LandmarkSpawner landmark in _landmarks)
		{
			if (landmark == landmarkSpawner)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasRegionOfType(params WorldRegionType[] regionTypes)
	{
		foreach (WorldRegionType item in regionTypes)
		{
			if (_regionTypes.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnTownheartResetPosition(out Vector3 position, float interval = 50f)
	{
		if (WasVisisted())
		{
			float num = GameSettings.Instance.GameplaySettings.ConstructionRadius;
			Rect rect = new Rect(Vector2.zero, new Vector2(num * 2f, num * 2f));
			Vector2 min = _worldBounds.min;
			Vector2 vector = _worldBounds.max - rect.size;
			int num2 = Mathf.FloorToInt((vector.x - min.x) / interval);
			int num3 = Mathf.FloorToInt((vector.y - min.y) / interval);
			for (int i = 0; i < num2; i++)
			{
				rect.x = vector.x - interval * (float)i;
				for (int j = 0; j < num3; j++)
				{
					if (j % 2 == 1)
					{
						rect.y = interval * (float)(-((j + 1) / 2));
					}
					else
					{
						rect.y = interval * (float)(j / 2);
					}
					if (IsPossibleTownPosition(rect))
					{
						position = rect.center.Vector3TopDown();
						return true;
					}
				}
			}
		}
		position = default(Vector3);
		return false;
	}

	private bool WasVisisted()
	{
		foreach (IWorldRegion region in _regions)
		{
			if ((region.Flags & WorldRegionFlags.Visited) != WorldRegionFlags.None)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsPossibleTownPosition(Rect rect)
	{
		if (TryReturnRegionContainingPosition(out var region, rect.center) && (region.Flags & WorldRegionFlags.Visited) != WorldRegionFlags.None)
		{
			if (HasOverlappingLandmark(region.Landmarks, rect))
			{
				return false;
			}
			foreach (IWorldRegion neighbor in region.Neighbors)
			{
				if (HasOverlappingLandmark(neighbor.Landmarks, rect))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool HasOverlappingLandmark(IReadOnlyList<LandmarkSpawner> landmarks, Rect worldSpaceRect)
	{
		worldSpaceRect.xMin -= _worldBounds.xMin;
		foreach (LandmarkSpawner landmark in landmarks)
		{
			if (landmark.TileSpacePolygon != null && landmark.TileSpacePolygon.Bounds.Overlaps(worldSpaceRect))
			{
				return true;
			}
		}
		return false;
	}
}
