using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
	[SerializeField]
	private GroupType travellingOn;

	[SerializeField]
	protected float targetSpeed = 0.3f;

	[SerializeField]
	protected float turningDuration = 0.3f;

	[SerializeField]
	private AnimationCurve turningCurve;

	public Tile initialTile;

	protected Tile currentTile;

	public Queue<Vector3> lastPositions;

	[SerializeField]
	private int lastPositionRememberCount = 100;

	private VehicleState _003CState_003Ek__BackingField;

	[SerializeField]
	private VehicleFollower followingVehicle;

	[SerializeField]
	private VehicleFollower followerPrefab;

	public Action<Tile> OnCurrentTileUpdated;

	private float _003CSpeed_003Ek__BackingField;

	public VehicleState State
	{
		get
		{
			return _003CState_003Ek__BackingField;
		}
		protected set
		{
			_003CState_003Ek__BackingField = value;
		}
	}

	public float Speed
	{
		get
		{
			return _003CSpeed_003Ek__BackingField;
		}
		protected set
		{
			_003CSpeed_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		lastPositions = new Queue<Vector3>();
		lastPositions.Enqueue(base.transform.position - base.transform.forward * 0.3f);
		lastPositions.Enqueue(base.transform.position);
	}

	protected virtual void StoreLastPathPosition(Vector3 positionToStore)
	{
		lastPositions.Enqueue(positionToStore);
		if (lastPositions.Count > lastPositionRememberCount)
		{
			lastPositions.Dequeue();
		}
	}

	protected void MoveAndRotateTowards(Vector3 nextPathPointPosition)
	{
		if (!(Vector3.Distance(base.transform.position, nextPathPointPosition) < 0.01f))
		{
			float maxDistanceDelta = Speed * Time.deltaTime;
			Vector3 vector = Vector3.MoveTowards(base.transform.position, nextPathPointPosition, maxDistanceDelta);
			if (!(vector == base.transform.position))
			{
				Vector3 eulerAngles = Quaternion.LookRotation((vector - base.transform.position).normalized, Vector3.up).eulerAngles;
				base.transform.position = vector;
				TweenSettingsExtensions.SetEase(ShortcutExtensions.DORotate(base.transform, eulerAngles, turningDuration), turningCurve);
			}
		}
	}

	public void SpawnWagon()
	{
		if (followerPrefab == null)
		{
			return;
		}
		if ((bool)followingVehicle)
		{
			followingVehicle.SpawnWagon();
			return;
		}
		List<Vector3> list = Enumerable.ToList(Enumerable.Reverse(lastPositions));
		float num = 0f;
		for (int i = 1; i < list.Count; i++)
		{
			float num2 = num + Vector3.Distance(list[i], list[i - 1]);
			if (num2 >= followerPrefab.followDistance)
			{
				Vector3 vector = Vector3.MoveTowards(list[i - 1], list[i], followerPrefab.followDistance - num);
				vector = list[i];
				followingVehicle = UnityEngine.Object.Instantiate(followerPrefab, vector, base.transform.rotation);
				followingVehicle.Follow(this);
				break;
			}
			num = num2;
		}
		if ((bool)followingVehicle.GetComponent<Element>())
		{
			followingVehicle.GetComponent<Element>().Randomize();
			BiomeManager.ApplyBiomeToObject(followingVehicle.GetComponent<Element>(), currentTile.CurrentBiomeInfluence);
		}
	}

	protected void UpdateCurrentTile(Tile newTile)
	{
		if ((bool)currentTile)
		{
			currentTile.OnDestroyed -= ResetToInitialTile;
		}
		currentTile = newTile;
		OnCurrentTileUpdated?.Invoke(newTile);
		base.transform.SetParent(currentTile.TileVisual.transform, worldPositionStays: true);
		if (newTile != initialTile)
		{
			currentTile.OnDestroyed += ResetToInitialTile;
		}
	}

	protected virtual void ResetToInitialTile()
	{
		currentTile.OnDestroyed -= ResetToInitialTile;
	}

	private void OnDestroy()
	{
		if ((bool)currentTile)
		{
			currentTile.OnDestroyed -= ResetToInitialTile;
		}
	}
}
