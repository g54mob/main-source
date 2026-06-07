using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class TrainCarTileInteraction : MonoBehaviour
{
	public float splitResolution = 1f;

	private const float HEIGHT_THRESHOLD = 8f;

	private const int MIN_NUMBER_OF_SEGMENTS = 2;

	private const float CHECK_DELAY = 1f;

	private const float MAX_FORWARD_SPEED = 5f;

	private const float BUFFER_OFFSET_Z = 1.5f;

	private const float HALF_TILE_SIZE = 4f;

	private List<HazmatGridTile> positionTiles = new List<HazmatGridTile>();

	private Vector3[] localReferencePoints;

	private TrainCar car;

	private bool shouldCheckForFireDamage = true;

	private float elapsedTime;

	private Vector3Int previousPosition;

	public bool canDamageCar = true;

	public bool canDamageCargo;

	[NonSerialized]
	public bool hasExplosiveResource;

	public List<int> GridPosition { get; private set; } = new List<int>();

	public event Action<float> CarBurning;

	public void OnCreated(TrainCar car)
	{
		this.car = car;
		if (car == null)
		{
			Debug.LogError("TrainCarTileInteraction requires a valid TrainCar reference. Disabling self.", this);
			base.enabled = false;
		}
		else if (!SingletonBehaviour<HazmatTileManager>.Instance)
		{
			Debug.LogWarning("TrainCarTileInteraction requires HazmatTileManager singleton. Disabling self.", this);
			base.enabled = false;
		}
		else
		{
			CalculateLocalReferencePoints();
			CalculateGridPosition();
			previousPosition = Vector3Int.FloorToInt(base.transform.position);
		}
	}

	private void OnEnable()
	{
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading && (bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
		}
	}

	public void StopCheckingForFire()
	{
		shouldCheckForFireDamage = false;
	}

	private void OnWorldMoved(WorldMover arg1, Vector3 arg2)
	{
		previousPosition = Vector3Int.FloorToInt(base.transform.position);
	}

	private void Update()
	{
		if (!ShouldCheckForFire())
		{
			return;
		}
		if (elapsedTime < 1f)
		{
			elapsedTime += Time.deltaTime;
			return;
		}
		if (ShouldRecalculateGridPosition())
		{
			CalculateGridPosition();
		}
		CheckForFire(elapsedTime);
		elapsedTime = 0f;
	}

	private bool ShouldRecalculateGridPosition()
	{
		Vector3Int vector3Int = Vector3Int.FloorToInt(base.transform.position);
		Vector3Int vector3Int2 = previousPosition - vector3Int;
		if ((float)Mathf.Abs(vector3Int2.x) > 4f || (float)Mathf.Abs(vector3Int2.z) > 4f)
		{
			previousPosition = vector3Int;
			return true;
		}
		return false;
	}

	private bool ShouldCheckForFire()
	{
		if (!shouldCheckForFireDamage || SingletonBehaviour<HazmatTileManager>.Instance.IgnitedTileCoords.Count <= 0 || (car.isExploded && !hasExplosiveResource) || car.GetAbsSpeed() > 5f)
		{
			return false;
		}
		if (!canDamageCar && !canDamageCargo)
		{
			return hasExplosiveResource;
		}
		return true;
	}

	private void CalculateLocalReferencePoints()
	{
		Vector3 center = car.Bounds.center;
		center.x = (center.y = 0f);
		Vector3 size = car.Bounds.size;
		size.x = (size.y = 0f);
		size.z -= 3f;
		int num = Mathf.CeilToInt(splitResolution * size.z / 8f) - 1;
		if (num < 0)
		{
			num = 0;
		}
		localReferencePoints = new Vector3[num + 2];
		localReferencePoints[0] = center - size * 0.5f;
		localReferencePoints[localReferencePoints.Length - 1] = center + size * 0.5f;
		Vector3 vector = size / (num + 1);
		for (int num2 = num; num2 > 0; num2--)
		{
			localReferencePoints[num2] = localReferencePoints[0] + num2 * vector;
		}
	}

	private void CalculateGridPosition()
	{
		GridPosition.Clear();
		int num = 0;
		for (int i = 0; i < localReferencePoints.Length; i++)
		{
			Vector3 pos = base.transform.position + base.transform.forward * localReferencePoints[i].z;
			int gridPositionFromWorldPosition = SingletonBehaviour<HazmatTileManager>.Instance.GetGridPositionFromWorldPosition(pos);
			if (i == 0 || gridPositionFromWorldPosition != num)
			{
				GridPosition.Add(gridPositionFromWorldPosition);
				num = gridPositionFromWorldPosition;
			}
		}
		GetPositionTiles();
	}

	private void GetPositionTiles()
	{
		positionTiles.Clear();
		foreach (int item in GridPosition)
		{
			if (SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary.TryGetValue(item, out var value))
			{
				positionTiles.Add(value);
			}
		}
	}

	private void CheckForFire(float elapsedTime)
	{
		for (int i = 0; i < GridPosition.Count; i++)
		{
			if (SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary.TryGetValue(GridPosition[i], out var value) && value.IsIgnited && base.transform.position.y - value.flowHeight < 8f)
			{
				this.CarBurning?.Invoke(elapsedTime);
				break;
			}
		}
	}

	public List<HazmatGridTile> RequestPositionTiles()
	{
		if (ShouldRecalculateGridPosition())
		{
			CalculateGridPosition();
		}
		else if (SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary.Count > 0)
		{
			GetPositionTiles();
		}
		return positionTiles;
	}
}
