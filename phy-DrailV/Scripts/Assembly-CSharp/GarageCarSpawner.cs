using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Garages;
using DV.PointSet;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class GarageCarSpawner : MonoBehaviour
{
	public static readonly Dictionary<TrainCarLivery, GarageCarSpawner> Spawners = new Dictionary<TrainCarLivery, GarageCarSpawner>();

	public GarageType_v2 garageType;

	public float spawnLocoPlayerSqrDistanceFromTrack = 250000f;

	public GameObject locoSpawnPoint;

	public bool flipSpawnLoco;

	[NonSerialized]
	public TrainCar[] garageCars;

	private bool playerEnteredLocoSpawnRange;

	private bool spawnAllowed;

	private Coroutine reorderCoro;

	public TrainCarLivery[] GarageCarLiveries => garageType.garageCarLiveries;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		Spawners.Clear();
	}

	public TrainCar GetCar(TrainCarLivery livery)
	{
		TrainCar[] array = garageCars;
		foreach (TrainCar trainCar in array)
		{
			if (trainCar != null && trainCar.carLivery == livery)
			{
				return trainCar;
			}
		}
		return null;
	}

	private void Awake()
	{
		if (garageType == null)
		{
			Debug.LogError("Unexpected state: GarageCarSpawner needs garageType. Aborting.", this);
			UnityEngine.Object.Destroy(this);
			return;
		}
		if (locoSpawnPoint == null)
		{
			Debug.LogError("Unexpected state: GarageCarSpawner needs a reference transform for spawn position. Aborting", this);
			UnityEngine.Object.Destroy(this);
			return;
		}
		TrainCarLivery[] garageCarLiveries = GarageCarLiveries;
		foreach (TrainCarLivery key in garageCarLiveries)
		{
			if (Spawners.ContainsKey(key))
			{
				Debug.LogError(string.Format("Unexpected state: {0} for {1} already exists. Destroying self.", "GarageCarSpawner", garageType), this);
				UnityEngine.Object.Destroy(this);
				return;
			}
			Spawners[key] = this;
		}
		garageCars = new TrainCar[GarageCarLiveries.Length];
	}

	private void OnDestroy()
	{
		TrainCarTeleporter.TeleportSuccessfulEventBeforeCoupling -= OnTeleportSuccessfulBeforeCoupling;
		TrainCarLivery[] garageCarLiveries = GarageCarLiveries;
		foreach (TrainCarLivery key in garageCarLiveries)
		{
			Spawners.Remove(key);
		}
	}

	public void AllowSpawning()
	{
		spawnAllowed = true;
	}

	private void Update()
	{
		if (!spawnAllowed || !AStartGameData.carsAndJobsLoadingFinished)
		{
			return;
		}
		Transform playerTransform = PlayerManager.PlayerTransform;
		if (!(playerTransform == null))
		{
			bool flag = (playerTransform.position - locoSpawnPoint.transform.position).sqrMagnitude < spawnLocoPlayerSqrDistanceFromTrack;
			if (!playerEnteredLocoSpawnRange && flag)
			{
				playerEnteredLocoSpawnRange = true;
				ForceCarsRespawn();
			}
			else if (playerEnteredLocoSpawnRange && !flag)
			{
				playerEnteredLocoSpawnRange = false;
			}
		}
	}

	public List<TrainCar> ForceCarsRespawn()
	{
		List<TrainCar> list = null;
		if (garageCars.Count((TrainCar c) => c == null) > 1)
		{
			List<TrainCarLivery> list2 = new List<TrainCarLivery>();
			for (int num = 0; num < garageCars.Length; num++)
			{
				if (garageCars[num] == null)
				{
					list2.Add(GarageCarLiveries[num]);
				}
			}
			list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnClosestTrack(list2, locoSpawnPoint.transform.position, null, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, flipSpawnLoco, playerSpawnedCars: true, uniqueSpawnedCars: true);
			if (list != null)
			{
				int num2 = 0;
				for (int num3 = 0; num3 < garageCars.Length; num3++)
				{
					if (garageCars[num3] == null)
					{
						TrainCar trainCar = list[num2++];
						garageCars[num3] = trainCar;
						HandleSpawnedGarageCar(trainCar);
					}
				}
			}
			else
			{
				Debug.LogError("Couldn't spawn garage cars, something is wrong!", this);
			}
			return list;
		}
		for (int num4 = 0; num4 < garageCars.Length; num4++)
		{
			if (garageCars[num4] != null)
			{
				continue;
			}
			garageCars[num4] = SingletonBehaviour<CarSpawner>.Instance.SpawnCarOnClosestTrack(locoSpawnPoint.transform.position, GarageCarLiveries[num4], flipSpawnLoco, playerSpawnedCar: true, uniqueCar: true);
			if (garageCars[num4] != null)
			{
				if (list == null)
				{
					list = new List<TrainCar>();
				}
				list.Add(garageCars[num4]);
				HandleSpawnedGarageCar(garageCars[num4]);
			}
			else
			{
				Debug.LogError("Couldn't spawn garage car!", this);
			}
		}
		return list;
		void HandleSpawnedGarageCar(TrainCar car)
		{
			car.OnDestroyCar += OnGarageCarDeleted;
			car.SetupHandbrakesOnManualSpawn();
			car.gameObject.AddComponent<HomeGarageReference>().garageCarSpawner = this;
		}
	}

	public void OverrideSpawnedCarReference(TrainCar carReference)
	{
		int num = Array.IndexOf(GarageCarLiveries, carReference.carLivery);
		if (num < 0)
		{
			Debug.LogError("Unexpected state: OverrideSpawnedCarReference attempted on " + garageType.id + ", unsupported livery!");
			return;
		}
		if (garageCars[num] != null)
		{
			Debug.LogError("Override is available only if car is not already spawned!");
			return;
		}
		garageCars[num] = carReference;
		if (carReference != null)
		{
			carReference.OnDestroyCar += OnGarageCarDeleted;
		}
		HomeGarageReference homeGarageReference = carReference.GetComponent<HomeGarageReference>();
		if (homeGarageReference != null)
		{
			Debug.LogError("Unexpected state: carReference already has HomeGarageReference component attached!", this);
		}
		else
		{
			homeGarageReference = carReference.gameObject.AddComponent<HomeGarageReference>();
		}
		homeGarageReference.garageCarSpawner = this;
	}

	public void ReturnCarHome(TrainCar car)
	{
		if (car == null)
		{
			Debug.LogError("Unexpected state: car is null but ReturnCarHome is called. Something is not right. Ignoring request.");
		}
		else
		{
			if (reorderCoro != null)
			{
				return;
			}
			TrainCar[] array = garageCars;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != car)
				{
					continue;
				}
				Bounds bounds = car.Bounds;
				(RailTrack, EquiPointSet.Point)? pointOnClosestAvailableTrackForCar = CarSpawner.GetPointOnClosestAvailableTrackForCar(locoSpawnPoint.transform.position, bounds.extents, SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks, 1f, 5f, 5000f);
				if (pointOnClosestAvailableTrackForCar.HasValue)
				{
					bool flag = false;
					if (garageCars.Length > 1)
					{
						flag = true;
						TrainCar[] array2 = garageCars;
						foreach (TrainCar trainCar in array2)
						{
							if (!(trainCar == car) && trainCar.logicCar.CurrentTrack != pointOnClosestAvailableTrackForCar.Value.Item1.LogicTrack())
							{
								flag = false;
								break;
							}
						}
					}
					RailTrack item = pointOnClosestAvailableTrackForCar.Value.Item1;
					EquiPointSet.Point item2 = pointOnClosestAvailableTrackForCar.Value.Item2;
					Vector3 forward = item2.forward;
					if (flipSpawnLoco)
					{
						forward *= -1f;
					}
					Vector3 worldPos = (Vector3)item2.position + WorldMover.currentMove;
					if (car.derailed)
					{
						car.Rerail(item, worldPos, forward);
					}
					else
					{
						car.MoveToTrackWithCarUncouple(item, worldPos, forward);
					}
					car.SimController?.controlsOverrider?.SetNeutralState();
					if (flag)
					{
						reorderCoro = StartCoroutine(ReorderCars());
					}
				}
				else
				{
					Debug.LogError("Couldn't find place for car in 5000m radius!");
				}
				return;
			}
			Debug.LogError("Unexpected state: car not part of garageCars, but ReturnCarHome is called. Something is not right. Ignoring request.");
		}
	}

	private IEnumerator ReorderCars()
	{
		while (!garageCars.All((TrainCar c) => !c.IsTeleporting))
		{
			yield return null;
		}
		TrainCar[] array = garageCars;
		foreach (TrainCar obj in array)
		{
			obj.carColliders.TempDisableCollisionColliders(disable: true);
			Coupler[] couplers = obj.couplers;
			for (int num2 = 0; num2 < couplers.Length; num2++)
			{
				couplers[num2].TempDisableOfBufferColliders(disable: true);
			}
		}
		List<TrainCar> list = garageCars.ToList();
		list.Reverse();
		TrainCarTeleporter.TeleportSuccessfulEventBeforeCoupling += OnTeleportSuccessfulBeforeCoupling;
		yield return TrainCarTeleporter.TeleportTrainset(list, locoSpawnPoint.transform.position, forceRegularDirection: true);
		TrainCarTeleporter.TeleportSuccessfulEventBeforeCoupling -= OnTeleportSuccessfulBeforeCoupling;
		array = garageCars;
		foreach (TrainCar obj2 in array)
		{
			obj2.carColliders.TempDisableCollisionColliders(disable: false);
			Coupler[] couplers = obj2.couplers;
			for (int num2 = 0; num2 < couplers.Length; num2++)
			{
				couplers[num2].TempDisableOfBufferColliders(disable: false);
			}
		}
		reorderCoro = null;
	}

	private void OnTeleportSuccessfulBeforeCoupling()
	{
		TrainCar[] array = garageCars;
		foreach (TrainCar obj in array)
		{
			obj.carColliders.TempDisableCollisionColliders(disable: false);
			Coupler[] couplers = obj.couplers;
			for (int j = 0; j < couplers.Length; j++)
			{
				couplers[j].TempDisableOfBufferColliders(disable: false);
			}
		}
	}

	private void OnGarageCarDeleted(TrainCar deletedCar)
	{
		if (deletedCar == null)
		{
			Debug.LogError("Unexpected state: OnGarageCarDeleted: deletedCar is null");
			return;
		}
		for (int i = 0; i < garageCars.Length; i++)
		{
			TrainCar trainCar = garageCars[i];
			if (!(trainCar != deletedCar))
			{
				trainCar.OnDestroyCar -= OnGarageCarDeleted;
				garageCars[i] = null;
			}
		}
	}
}
