using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

public class WorldMapTile : MonoBehaviour
{
	[SerializeField]
	private WorldMapSea _worldMapSea;

	[SerializeField]
	private WorldMapFlotsam _pointOfInterestVisualPrefab;

	[SerializeField]
	private WorldMapScoutableLandmark _scoutableLandmarkPrefab;

	[SerializeField]
	private Renderer _seaRenderer;

	[SerializeField]
	private WorldMapFogOfWar _fogOfWar;

	[Header("Physics")]
	[SerializeField]
	private Transform _physicsParent;

	[SerializeField]
	private PolygonCollider2D _landmarkPhysicsPrefab;

	private List<WorldMapScoutableLandmark>[] _landmarkClusters;

	private readonly List<WorldMapScoutableLandmark> _allLandmarks = new List<WorldMapScoutableLandmark>();

	private readonly List<WorldMapFlotsam> _pointsOfInterest = new List<WorldMapFlotsam>();

	private float _landmarksInterval;

	private Transform _landmarkVisualsParent;

	private Transform _pointOfInterestVisualsParent;

	private Coroutine _initializeCoroutine;

	public WorldTile WorldTile { get; private set; }

	public void Initialize(WorldTile worldTile, float landmarksInterval, bool async)
	{
		WorldTile = worldTile;
		_landmarksInterval = landmarksInterval;
		GameEventDispatcher.AddListener(GameEventType.LandmarkSpawned, OnLandmarkSpawned);
		GameEventDispatcher.AddListener(GameEventType.LandmarkDisposed, OnLandmarkDisposed);
		GameEventDispatcher.AddListener(GameEventType.PointOfInterestSpawned, OnPointOfInterestSpawned);
		if (async)
		{
			_initializeCoroutine = CoroutineMotor.StartRoutine(InitializeCoroutine(worldTile, instant: false));
		}
		else
		{
			InitializeCoroutine(worldTile, instant: true).MoveNext();
		}
	}

	public void UpdateScouting(Vector3 townPosition, float fowRange, float scoutRange)
	{
		foreach (LandmarkSpawner landmark in WorldTile.Landmarks)
		{
			if (landmark.ScoutingState != ScoutingState.Scouted)
			{
				float num = landmark.WorldPosition.DistanceToLeveled(townPosition);
				if (num < scoutRange)
				{
					landmark.SetScoutingState(ScoutingState.Scouted);
				}
				else if (num < fowRange)
				{
					landmark.SetScoutingState(ScoutingState.Confirmed);
				}
			}
		}
		foreach (PointOfInterestSpawner item in WorldTile.PointsOfInterest)
		{
			if (item.ScoutingState != ScoutingState.Scouted && item.WorldPosition.IsInRange(townPosition, fowRange))
			{
				item.SetScoutingState(ScoutingState.Scouted);
			}
		}
	}

	public void Destroy()
	{
		if (_initializeCoroutine != null)
		{
			CoroutineMotor.StopRoutine(_initializeCoroutine);
		}
		DestroyLandmarkVisuals();
		DestroyPointOfInterestVisuals();
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSpawned, OnLandmarkSpawned);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkDisposed, OnLandmarkDisposed);
		GameEventDispatcher.RemoveListener(GameEventType.PointOfInterestSpawned, OnPointOfInterestSpawned);
	}

	public void RestoreLastTileFOW()
	{
		_fogOfWar.RestoreLastTileAlphas();
	}

	private IEnumerator InitializeCoroutine(WorldTile worldTile, bool instant)
	{
		_fogOfWar.Initialize(worldTile);
		Vector3 localScale = _seaRenderer.transform.localScale;
		localScale.x = _fogOfWar.GridSizeX * _fogOfWar.TileSizeX;
		localScale.y = _fogOfWar.GridSizeZ * _fogOfWar.TileSizeZ;
		_seaRenderer.sharedMaterial.SetFloat("_MapOverlayScale", worldTile.Scale);
		_seaRenderer.transform.localScale = localScale;
		_worldMapSea.Initialize(worldTile);
		base.transform.localPosition = worldTile.WorldPosition;
		base.gameObject.SetActive(value: true);
		if (instant)
		{
			SpawnLandmarkVisuals(worldTile.Landmarks);
			SpawnPointOfInterestVisuals(worldTile.PointsOfInterest);
		}
		else
		{
			using ListPool<ISpawner>.List spawners = ListPool<ISpawner>.Get();
			spawners.AddRange(worldTile.Landmarks);
			spawners.AddRange(worldTile.PointsOfInterest);
			yield return SpawnVisualsAsync(spawners);
		}
		_initializeCoroutine = null;
	}

	private void SpawnLandmarkVisuals(IReadOnlyList<LandmarkSpawner> landmarks)
	{
		float x = WorldTile.WorldBounds.x;
		InitializeLandmarkVisualsSpawning();
		int i = 0;
		for (int count = landmarks.Count; i < count; i++)
		{
			SpawnLandmarkVisual(landmarks[i], x);
		}
	}

	private void InitializeLandmarkVisualsSpawning()
	{
		if (_landmarkVisualsParent == null)
		{
			_landmarkVisualsParent = new GameObject("Landmarks").transform;
			_landmarkVisualsParent.SetParent(base.transform);
			_landmarkVisualsParent.Reset();
		}
		int num = Mathf.CeilToInt(WorldTile.WorldBounds.size.x / _landmarksInterval);
		_landmarkClusters = new List<WorldMapScoutableLandmark>[num];
		for (int i = 0; i < num; i++)
		{
			_landmarkClusters[i] = new List<WorldMapScoutableLandmark>();
		}
	}

	private void OnLandmarkSpawned(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && WorldTile.IsParentOfLandmarkSpawner(landmarkNotificationEvent.LandmarkSpawner))
		{
			SpawnLandmarkVisual(landmarkNotificationEvent.LandmarkSpawner, WorldTile.WorldBounds.x);
		}
	}

	private void OnLandmarkDisposed(GameEvent gameEvent)
	{
		if (!(gameEvent is LandmarkNotificationEvent landmarkNotificationEvent))
		{
			return;
		}
		List<WorldMapScoutableLandmark>[] landmarkClusters = _landmarkClusters;
		foreach (List<WorldMapScoutableLandmark> list in landmarkClusters)
		{
			for (int j = 0; j < list.Count; j++)
			{
				WorldMapScoutableLandmark worldMapScoutableLandmark = list[j];
				if (worldMapScoutableLandmark.Landmark.LandmarkSpawner == landmarkNotificationEvent.LandmarkSpawner)
				{
					list.RemoveAt(j);
					UnityEngine.Object.Destroy(worldMapScoutableLandmark.gameObject);
				}
			}
		}
	}

	private bool SpawnLandmarkVisual(LandmarkSpawner spawner, float tileX)
	{
		if (!spawner.Enabled || !spawner.LandmarkBehaviour.Validate())
		{
			return false;
		}
		WorldMapLandmark worldMapLandmark = UnityEngine.Object.Instantiate(spawner.LandmarkBehaviour.MapPrefab, _landmarkVisualsParent);
		worldMapLandmark.Initialize(spawner);
		WorldMapScoutableLandmark worldMapScoutableLandmark = UnityEngine.Object.Instantiate(_scoutableLandmarkPrefab, _landmarkVisualsParent);
		worldMapScoutableLandmark.Initialize(worldMapLandmark, spawner);
		int num = Mathf.FloorToInt((spawner.WorldPosition.x - tileX) / _landmarksInterval);
		_landmarkClusters[num].Add(worldMapScoutableLandmark);
		return true;
	}

	private void DestroyLandmarkVisuals()
	{
		if (_landmarkClusters == null)
		{
			return;
		}
		List<WorldMapScoutableLandmark>[] landmarkClusters = _landmarkClusters;
		foreach (List<WorldMapScoutableLandmark> list in landmarkClusters)
		{
			foreach (WorldMapScoutableLandmark item in list)
			{
				if (!(item == null))
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			list.Clear();
		}
		_landmarkClusters = null;
	}

	private void SpawnPointOfInterestVisuals(IReadOnlyList<PointOfInterestSpawner> spawners, bool instant = true)
	{
		InitializePointOfInterestVisualsSpawning();
		int i = 0;
		for (int count = spawners.Count; i < count; i++)
		{
			SpawnPointOfInterestVisual(spawners[i]);
		}
	}

	private void InitializePointOfInterestVisualsSpawning()
	{
		if (_pointOfInterestVisualsParent == null)
		{
			_pointOfInterestVisualsParent = new GameObject("POIs").transform;
			_pointOfInterestVisualsParent.SetParent(base.transform);
			_pointOfInterestVisualsParent.Reset();
		}
		_pointsOfInterest.Clear();
	}

	private void OnPointOfInterestSpawned(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent && mapEvent.WorldTile == WorldTile)
		{
			SpawnPointOfInterestVisual(mapEvent.PointOfInterestSpawner);
		}
	}

	private void SpawnPointOfInterestVisual(PointOfInterestSpawner spawner)
	{
		WorldMapFlotsam worldMapFlotsam = UnityEngine.Object.Instantiate(_pointOfInterestVisualPrefab, _pointOfInterestVisualsParent);
		worldMapFlotsam.Initialize(spawner);
		_pointsOfInterest.Add(worldMapFlotsam);
	}

	private void DestroyPointOfInterestVisuals()
	{
		if (_pointsOfInterest.Count == 0)
		{
			return;
		}
		foreach (WorldMapFlotsam item in _pointsOfInterest)
		{
			if (!(item == null))
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		_pointsOfInterest.Clear();
	}

	private IEnumerator SpawnVisualsAsync(List<ISpawner> spawners)
	{
		float tileX = WorldTile.WorldBounds.x;
		InitializeLandmarkVisualsSpawning();
		InitializePointOfInterestVisualsSpawning();
		SpawnerSorting.ByDistanceToTownheart(spawners);
		foreach (ISpawner spawner in spawners)
		{
			switch (spawner.Type)
			{
			case ISpawnerType.Landmark:
				if (!SpawnLandmarkVisual(spawner as LandmarkSpawner, tileX))
				{
					continue;
				}
				break;
			case ISpawnerType.PointOfInterest:
				SpawnPointOfInterestVisual(spawner as PointOfInterestSpawner);
				break;
			default:
				Debug.LogException(new NotImplementedException(spawner.Type.ToString()));
				break;
			}
			yield return null;
		}
	}

	public WorldMapLandmark ReturnClosestWorldmapLandmark(Vector3 position)
	{
		using ListPool<WorldMapScoutableLandmark>.List list = ReturnLandmarks(position.Vector2TopDown());
		int count = list.Count;
		WorldMapLandmark result = null;
		float num = float.MaxValue;
		for (int i = 0; i < count; i++)
		{
			WorldMapLandmark landmark = list[i].Landmark;
			float sqrMagnitude = (landmark.transform.position - position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				result = landmark;
				num = sqrMagnitude;
			}
		}
		return result;
	}

	public bool HasLandmarkInSquareRadius(Vector2 center, float squareRadius)
	{
		using ListPool<WorldMapScoutableLandmark>.List list = ReturnLandmarks(center);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].IsInSquareRadius(center, squareRadius))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnRaycastLandmarkInRadius(out WorldMapLandmark landmark, Ray ray, Vector2 center, float radius)
	{
		using ListPool<WorldMapScoutableLandmark>.List list = ReturnLandmarks(center);
		float num = radius * radius;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			landmark = list[i].Landmark;
			if (landmark.Spawner.WorldPosition2D.DistanceToSquared(center) < num && landmark.RayCast(ray, float.MaxValue))
			{
				return true;
			}
		}
		landmark = null;
		return false;
	}

	public bool TryReturnPointOfInterest(out WorldMapPointOfInterest poi, ISpawner spawner)
	{
		if (WorldTile.WorldBounds.Contains(spawner.WorldPosition2D))
		{
			switch (spawner.Type)
			{
			case ISpawnerType.Landmark:
			{
				int num = Mathf.FloorToInt((spawner.WorldPosition.x - WorldTile.WorldBounds.x) / _landmarksInterval);
				List<WorldMapScoutableLandmark> list = _landmarkClusters[num];
				int count2 = list.Count;
				while (0 < count2--)
				{
					poi = list[count2].Landmark;
					if (poi.Spawner == spawner)
					{
						return true;
					}
				}
				break;
			}
			case ISpawnerType.PointOfInterest:
			{
				int count = _pointsOfInterest.Count;
				while (0 < count--)
				{
					poi = _pointsOfInterest[count];
					if (poi.Spawner == spawner)
					{
						return true;
					}
				}
				break;
			}
			default:
				Debug.LogException(new NotImplementedException());
				break;
			}
		}
		poi = null;
		return false;
	}

	public WorldMapFogOfWar.PersistentData ReturnFogOfWarPersistentData()
	{
		if ((bool)_fogOfWar)
		{
			return new WorldMapFogOfWar.PersistentData(_fogOfWar);
		}
		return null;
	}

	public void UpdatePhyscis(Vector2 position, float rangeSquared)
	{
		using ListPool<WorldMapScoutableLandmark>.List list = ReturnLandmarks(position);
		foreach (WorldMapScoutableLandmark item in list)
		{
			if ((bool)item.Landmark.Collider2D)
			{
				if (!item.Landmark.IsInSquareRadius(position, rangeSquared))
				{
					item.Landmark.ReleaseCollider();
				}
			}
			else if (item.Landmark.Spawner.WorldPosition2D.DistanceToSquared(position) <= rangeSquared)
			{
				item.Landmark.AquireCollider(_landmarkPhysicsPrefab, _physicsParent);
			}
		}
	}

	public ListPool<WorldMapScoutableLandmark>.List ReturnLandmarks(Vector2 position, int range = 1)
	{
		ListPool<WorldMapScoutableLandmark>.List list = ListPool<WorldMapScoutableLandmark>.Get();
		PopulateLandmarks(list, position, range);
		return list;
	}

	public void PopulateLandmarks(List<WorldMapScoutableLandmark> landmarks, Vector2 position, int range = 1)
	{
		int num = Mathf.FloorToInt((position.x - WorldTile.WorldBounds.x) / _landmarksInterval);
		int num2 = num + range;
		for (int i = num - range; i <= num2; i++)
		{
			if (i >= 0 && _landmarkClusters.Length > i)
			{
				landmarks.AddRange(_landmarkClusters[i]);
			}
		}
	}

	public IReadOnlyList<WorldMapFlotsam> GetAllFlotsam()
	{
		return _pointsOfInterest;
	}
}
