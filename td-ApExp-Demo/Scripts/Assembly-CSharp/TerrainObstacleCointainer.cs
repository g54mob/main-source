using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainObstacleCointainer : MonoBehaviour
{
	[Header("Obstacle Regions")]
	[SerializeField]
	private BoxCollider2D[] _randomObstacleRegions;

	[SerializeField]
	private Transform[] _fixedObstaclePositions;

	private float _randomObstaclesChance = 0.1f;

	private Vector2 _randomObstaclesDensity;

	private TrackObstacleWithChance[] _randomObstaclePrefabs;

	private float _fixedObstacleChance = 0.1f;

	private Vector2 _fixedObstacelDensity;

	private TrackObstacleWithChance[] _fixedObstaclePrefabs;

	private float _overTrackObstacleChance = 0.1f;

	private GameObject _overTrackObstaclePrefab;

	private float _adjustedRandomObstacleChance;

	private float _adjustedFixedObstacleChance;

	private int _totalRandomObstacleAbundance;

	private int _totalFixedObstacleAbundance;

	private GameObject[] _weightedRandomObstacles;

	private GameObject[] _weightedFixedObstaclesList;

	private int _lastUsedWorldIndex = -1;

	private int _randomObstacelPooslSize;

	private GameObject[] _randomObstacles;

	private int _fixedObstacelPoolSize;

	private GameObject[] _fixedObstaclesPool;

	private GameObject _overTrackObstacle;

	[Obsolete("Should be removed if pooling will never be implemented")]
	private int _randomObstaclePoolIndex;

	[Obsolete("Should be removed if pooling will never be implemented")]
	private int _fixedObstaclePoolIndex;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	public void SetObstacles()
	{
		if (ZoneManager.Instance.CurrentZoneIndex != -1)
		{
			if (_lastUsedWorldIndex != ZoneManager.Instance.CurrentZoneIndex)
			{
				_lastUsedWorldIndex = ZoneManager.Instance.CurrentZoneIndex;
				ForceSetObstacles(_lastUsedWorldIndex);
			}
			DisableAllObstacles();
			TryAddRandomObstacles();
			AddFixedObstacles();
			AddOverTrackObstacle();
		}
	}

	private void Initialize()
	{
		_adjustedRandomObstacleChance = _randomObstaclesChance;
		_adjustedFixedObstacleChance = _fixedObstacleChance;
		if (_randomObstaclePrefabs != null && _randomObstaclePrefabs.Length != 0)
		{
			_totalRandomObstacleAbundance = _randomObstaclePrefabs.Select((TrackObstacleWithChance t) => t.RelativeChance).Sum();
		}
		if (_fixedObstaclePrefabs != null && _fixedObstaclePrefabs.Length != 0)
		{
			_totalFixedObstacleAbundance = _fixedObstaclePrefabs.Select((TrackObstacleWithChance t) => t.RelativeChance).Sum();
		}
		ClearAllPools();
		_randomObstacelPooslSize = Mathf.Max((int)UnityEngine.Random.Range(_randomObstaclesDensity.x, _randomObstaclesDensity.y), _totalRandomObstacleAbundance * 2);
		_randomObstacles = new GameObject[_randomObstacelPooslSize];
		_fixedObstacelPoolSize = Mathf.Max((int)UnityEngine.Random.Range(_fixedObstacelDensity.x, _fixedObstacelDensity.y), _totalFixedObstacleAbundance * 2);
		_fixedObstaclesPool = new GameObject[_fixedObstacelPoolSize];
		_overTrackObstacle = null;
		_randomObstaclePoolIndex = 0;
		_fixedObstaclePoolIndex = 0;
		List<GameObject> list = new List<GameObject>();
		TrackObstacleWithChance[] randomObstaclePrefabs = _randomObstaclePrefabs;
		foreach (TrackObstacleWithChance trackObstacleWithChance in randomObstaclePrefabs)
		{
			for (int num2 = 0; num2 < trackObstacleWithChance.RelativeChance; num2++)
			{
				list.Add(trackObstacleWithChance.Prefab);
			}
		}
		_weightedRandomObstacles = list.ToArray();
		List<GameObject> list2 = new List<GameObject>();
		randomObstaclePrefabs = _fixedObstaclePrefabs;
		foreach (TrackObstacleWithChance trackObstacleWithChance2 in randomObstaclePrefabs)
		{
			for (int num3 = 0; num3 < trackObstacleWithChance2.RelativeChance; num3++)
			{
				list2.Add(trackObstacleWithChance2.Prefab);
			}
		}
		_weightedFixedObstaclesList = list2.ToArray();
	}

	private void TryAddRandomObstacles()
	{
		if (_randomObstaclePrefabs == null || _randomObstaclePrefabs.Length == 0)
		{
			Debug.LogWarning("No random obstacle prefabs assigned.");
			return;
		}
		if (UnityEngine.Random.Range(0f, 1f) > _adjustedRandomObstacleChance)
		{
			_adjustedRandomObstacleChance += _randomObstaclesChance;
			DisableRandomObstacels();
			return;
		}
		_adjustedRandomObstacleChance = _randomObstaclesChance;
		_randomObstaclePoolIndex = 0;
		int num = (int)UnityEngine.Random.Range(_randomObstaclesDensity.x, _randomObstaclesDensity.y);
		for (int i = 0; i < num; i++)
		{
			int num2 = UnityEngine.Random.Range(0, _totalRandomObstacleAbundance);
			AddRandomObstacleToRegion(_weightedRandomObstacles[num2], _randomObstacleRegions[UnityEngine.Random.Range(0, _randomObstacleRegions.Length)]);
		}
	}

	private void AddRandomObstacleToRegion(GameObject obstacle, BoxCollider2D regionCollider)
	{
		Vector2 size = regionCollider.size;
		if (++_randomObstaclePoolIndex >= _randomObstacelPooslSize)
		{
			_randomObstaclePoolIndex = 0;
		}
		_randomObstacles[_randomObstaclePoolIndex] = UnityEngine.Object.Instantiate(obstacle, new Vector2(regionCollider.offset.x + regionCollider.transform.position.x + UnityEngine.Random.Range((0f - size.x) / 2f, size.x / 2f), regionCollider.offset.y + regionCollider.transform.position.y + UnityEngine.Random.Range((0f - size.y) / 2f, size.y / 2f)), Quaternion.identity, regionCollider.transform);
		MoveObstacleToFreeSpace(_randomObstaclePoolIndex);
	}

	private void MoveObstacleToFreeSpace(int obstacleIndex)
	{
		int num = obstacleIndex;
		GameObject gameObject = _randomObstacles[num];
		if (gameObject == null)
		{
			return;
		}
		Collider2D component = gameObject.GetComponent<Collider2D>();
		if ((object)component == null)
		{
			return;
		}
		while (--num >= 0)
		{
			GameObject gameObject2 = _randomObstacles[num];
			if ((object)gameObject2 != null)
			{
				Collider2D component2 = gameObject2.GetComponent<Collider2D>();
				if ((object)component2 != null && CheckObstacleOverlap(component, component2))
				{
					component.transform.position = new Vector3(component2.transform.position.x + component.SizeX() / 2f + component2.SizeX() / 2f, gameObject.transform.position.y);
				}
				continue;
			}
			break;
		}
	}

	private bool CheckObstacleOverlap(Collider2D col1, Collider2D col2)
	{
		float num = col1.SizeX() / 2f;
		float num2 = col2.SizeX() / 2f;
		float num3 = col1.SizeY() / 2f;
		float num4 = col2.SizeY() / 2f;
		Vector2 vector = col1.transform.position;
		Vector2 vector2 = col2.transform.position;
		if (MathF.Abs(vector.x - vector2.x) <= num + num2 && MathF.Abs(vector.y - vector2.y) <= num3 + num4)
		{
			return true;
		}
		return false;
	}

	private void AddFixedObstacles()
	{
		int num = (int)UnityEngine.Random.Range(_fixedObstacelDensity.x, _fixedObstacelDensity.y);
		if (num == 0 || _fixedObstaclePrefabs == null || _fixedObstaclePrefabs.Length == 0)
		{
			return;
		}
		if (UnityEngine.Random.Range(0f, 1f) > _adjustedFixedObstacleChance)
		{
			_adjustedFixedObstacleChance += _fixedObstacleChance;
			DisableFixedObstacels();
			return;
		}
		_fixedObstaclePoolIndex = 0;
		List<Transform> list = new List<Transform>(_fixedObstaclePositions);
		while (num > 0)
		{
			int num2 = UnityEngine.Random.Range(0, _totalFixedObstacleAbundance);
			Transform transform = list[UnityEngine.Random.Range(0, list.Count)];
			list.Remove(transform);
			if (++_fixedObstaclePoolIndex >= _fixedObstacelPoolSize)
			{
				_fixedObstaclePoolIndex = 0;
			}
			if ((bool)_fixedObstaclesPool[_fixedObstaclePoolIndex])
			{
				_fixedObstaclesPool[_fixedObstaclePoolIndex].SetActive(value: true);
				_fixedObstaclesPool[_fixedObstaclePoolIndex].transform.position = transform.position;
			}
			else
			{
				_fixedObstaclesPool[_fixedObstaclePoolIndex] = UnityEngine.Object.Instantiate(_weightedFixedObstaclesList[num2], transform.position, Quaternion.identity, transform);
			}
			num--;
		}
	}

	private void AddOverTrackObstacle()
	{
		if (UnityEngine.Random.Range(0f, 1f) <= _overTrackObstacleChance)
		{
			try
			{
				if ((bool)_overTrackObstacle)
				{
					_overTrackObstacle.SetActive(value: true);
				}
				else
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(_overTrackObstaclePrefab, Vector3.zero, Quaternion.identity, base.transform);
					gameObject.transform.localPosition = Vector3.zero;
					_overTrackObstacle = gameObject;
				}
				return;
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to instantiate over track obstacle: " + ex.Message);
				return;
			}
		}
		if ((bool)_overTrackObstacle)
		{
			_overTrackObstacle.SetActive(value: false);
		}
	}

	public void TrySetObstacles(int worldIndex)
	{
		if (_lastUsedWorldIndex != worldIndex)
		{
			_lastUsedWorldIndex = worldIndex;
			ForceSetObstacles(worldIndex);
		}
	}

	private void ForceSetObstacles(int worldIndex)
	{
		SetObstaclePrefabsForWorld(worldIndex);
		SetRandomObstacleChancesForWorld(worldIndex);
		SetFixedObstacleChanceForWorld(worldIndex);
		SetObstacleDensitiesForWorld(worldIndex);
		Initialize();
		SetOverTrackObstacleChanceForWorld(worldIndex);
	}

	private void SetObstaclePrefabsForWorld(int worldIndex)
	{
		SetRandomObstacles(TrackManager.Instance.worldRandomObstacleObjects[worldIndex]);
		SetFixedObstacles(TrackManager.Instance.worldFixedObstacleObjects[worldIndex]);
		SetOverTrackObstacleForWorld(TrackManager.Instance.worldOverTrackObstacleObjects[worldIndex]);
	}

	private void SetRandomObstacles(TrackObstacleWithChance[] obstaclePrefabs)
	{
		_randomObstaclePrefabs = obstaclePrefabs;
	}

	private void SetFixedObstacles(TrackObstacleWithChance[] obstaclePrefabs)
	{
		_fixedObstaclePrefabs = obstaclePrefabs;
	}

	private void SetObstacleDensitiesForWorld(int worldIndex)
	{
		_randomObstaclesDensity = TrackManager.Instance.worldRandomObstaclesDensityRange[worldIndex];
		_fixedObstacelDensity = TrackManager.Instance.worldFixedObstaclesDensity[worldIndex];
	}

	private void SetRandomObstacleChancesForWorld(int worldIndex)
	{
		_randomObstaclesChance = TrackManager.Instance.worldRandomObstacleChances[worldIndex];
	}

	private void SetFixedObstacleChanceForWorld(int worldIndex)
	{
		_fixedObstacleChance = TrackManager.Instance.worldFixedObstacleChances[worldIndex];
	}

	private void SetOverTrackObstacleForWorld(GameObject prefab)
	{
		_overTrackObstaclePrefab = prefab;
	}

	private void SetOverTrackObstacleChanceForWorld(int worldIndex)
	{
		_overTrackObstacleChance = TrackManager.Instance.worldOverTrackObstacleChances[worldIndex];
	}

	public void ClearAllPools()
	{
		if (_randomObstacles != null)
		{
			for (int i = 0; i < _randomObstacles.Length; i++)
			{
				if (_randomObstacles[i] != null)
				{
					UnityEngine.Object.Destroy(_randomObstacles[i]);
				}
			}
		}
		if (_fixedObstaclesPool != null)
		{
			for (int j = 0; j < _fixedObstaclesPool.Length; j++)
			{
				if (_fixedObstaclesPool[j] != null)
				{
					UnityEngine.Object.Destroy(_fixedObstaclesPool[j]);
				}
			}
		}
		if (_overTrackObstacle != null)
		{
			UnityEngine.Object.Destroy(_overTrackObstacle);
		}
	}

	public void DisableAllObstacles()
	{
		DisableRandomObstacels();
		DisableFixedObstacels();
		DisableOverTrackObstacle();
	}

	private void DisableRandomObstacels()
	{
		if (_randomObstacles == null)
		{
			return;
		}
		for (int i = 0; i < _randomObstacles.Length; i++)
		{
			if (_randomObstacles[i] != null)
			{
				UnityEngine.Object.Destroy(_randomObstacles[i]);
			}
		}
	}

	private void DisableFixedObstacels()
	{
		if (_fixedObstaclesPool == null)
		{
			return;
		}
		for (int i = 0; i < _fixedObstaclesPool.Length; i++)
		{
			if (_fixedObstaclesPool[i] != null)
			{
				UnityEngine.Object.Destroy(_fixedObstaclesPool[i]);
			}
		}
	}

	private void DisableOverTrackObstacle()
	{
		if (_overTrackObstacle != null)
		{
			UnityEngine.Object.Destroy(_overTrackObstacle);
		}
	}
}
