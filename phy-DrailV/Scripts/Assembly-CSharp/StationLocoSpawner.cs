using System;
using System.Collections.Generic;
using System.Linq;
using DV.Logic.Job;
using DV.PointSet;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StationLocoSpawner : MonoBehaviour
{
	public float spawnLocoPlayerSqrDistanceFromTrack = 1210000f;

	public List<ListTrainCarTypeWrapper> locoTypeGroupsToSpawn;

	public string locoSpawnTrackName;

	[NonSerialized]
	public RailTrack locoSpawnTrack;

	[Tooltip("Spawn loco rotation will align with green to red sphere gizmo direction on track")]
	public bool spawnRotationFlipped;

	private bool playerEnteredLocoSpawnRange;

	private GameObject spawnTrackMiddleAnchor;

	private int nextLocoGroupSpawnIndex = -1;

	private void Awake()
	{
		nextLocoGroupSpawnIndex = UnityEngine.Random.Range(0, locoTypeGroupsToSpawn.Count);
	}

	private void Start()
	{
		locoSpawnTrack = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetTrackWithName(locoSpawnTrackName);
		if (locoSpawnTrack == null || locoTypeGroupsToSpawn == null || locoTypeGroupsToSpawn.Count == 0)
		{
			Debug.LogError("StationLocoSpawner is not initialized correctly. Destroying this script!", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		foreach (ListTrainCarTypeWrapper item in locoTypeGroupsToSpawn)
		{
			if (item.liveries == null || item.liveries.Count == 0)
			{
				Debug.LogError("StationLocoSpawner is not initialized correctly. Group in locoTypeGroupsToSpawn is not initialized. Destroying this script!", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			foreach (TrainCarLivery livery in item.liveries)
			{
				if (!CarTypes.IsAnyLocomotiveOrTender(livery))
				{
					Debug.LogError("StationLocoSpawner is not initialized correctly. locoTypeGroupsToSpawn has invalid (non-loco related) TrainCarType. Destroying this script!", base.gameObject);
					UnityEngine.Object.Destroy(this);
					return;
				}
			}
		}
		EquiPointSet kinkedPointSet = locoSpawnTrack.GetKinkedPointSet();
		if (kinkedPointSet == null)
		{
			Debug.LogError(string.Format("No {0} defined on {1} {2}", "EquiPointSet", "RailTrack", locoSpawnTrack), this);
			return;
		}
		Vector3 position = (Vector3)kinkedPointSet.points[kinkedPointSet.points.Length / 2].position;
		spawnTrackMiddleAnchor = new GameObject("TrackMidPoint");
		spawnTrackMiddleAnchor.transform.SetParent(base.transform);
		spawnTrackMiddleAnchor.transform.position = position;
		ValidateDistances();
	}

	private void Update()
	{
		Transform playerTransform = PlayerManager.PlayerTransform;
		if (playerTransform == null || !AStartGameData.carsAndJobsLoadingFinished || SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
		{
			return;
		}
		bool flag = (playerTransform.position - spawnTrackMiddleAnchor.transform.position).sqrMagnitude < spawnLocoPlayerSqrDistanceFromTrack;
		if (!playerEnteredLocoSpawnRange && flag)
		{
			playerEnteredLocoSpawnRange = true;
			List<Car> carsFullyOnTrack = locoSpawnTrack.LogicTrack().GetCarsFullyOnTrack();
			if (carsFullyOnTrack.Count != 0 && carsFullyOnTrack.Any((Car car) => CarTypes.IsLocomotive(car.carType)))
			{
				return;
			}
			List<TrainCarLivery> trainCarTypes = new List<TrainCarLivery>(locoTypeGroupsToSpawn[nextLocoGroupSpawnIndex].liveries);
			nextLocoGroupSpawnIndex = UnityEngine.Random.Range(0, locoTypeGroupsToSpawn.Count);
			Physics.SyncTransforms();
			List<TrainCar> list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrack(trainCarTypes, null, locoSpawnTrack, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, spawnRotationFlipped);
			if (list != null)
			{
				List<Car> unusedCars = list.Select((TrainCar tc) => tc.logicCar).ToList();
				SingletonBehaviour<UnusedTrainCarDeleter>.Instance.MarkForDelete(unusedCars);
			}
		}
		else if (playerEnteredLocoSpawnRange && !flag)
		{
			playerEnteredLocoSpawnRange = false;
		}
	}

	public List<TrainCarLivery> GetLocoTypesCurrentlyOnSpawnTrack()
	{
		return (from l in locoSpawnTrack.LogicTrack().GetCarsFullyOnTrack()
			where CarTypes.IsLocomotive(l.carType)
			select l.carType).ToList();
	}

	public List<TrainCarLivery> GetNextSpawnLocoList()
	{
		return locoTypeGroupsToSpawn[nextLocoGroupSpawnIndex].liveries;
	}

	private void ValidateDistances()
	{
		double span = locoSpawnTrack.GetKinkedPointSet().span;
		float num = Mathf.Sqrt(spawnLocoPlayerSqrDistanceFromTrack);
		float num2 = Mathf.Sqrt(16000000f);
		double num3 = (double)num + span + 10.0;
		if ((double)num2 < num3)
		{
			float num4 = (float)((double)num - (num3 - (double)num2));
			if (num4 <= 0f)
			{
				Debug.LogError("Invalid setup, need to update REQUIRED_SQR_DISTANCE_FROM_LOCO_TO_DELETE_IT." + string.Format(" It can't be lower than {0}[{1}] + {2}", "spawnTrackLength", span, "DELETE_LOCO_ADDITIONAL_SAFETY_DISTANCE"));
				return;
			}
			spawnLocoPlayerSqrDistanceFromTrack = Mathf.Pow(num4, 2f);
			Debug.LogWarning(string.Format("{0} needs to be higher than {1} by at least length of {2} + {3} ({4} + {5} = {6}).", "REQUIRED_SQR_DISTANCE_FROM_LOCO_TO_DELETE_IT", "spawnLocoPlayerSqrDistanceFromTrack", "locoSpawnTrack", "DELETE_LOCO_ADDITIONAL_SAFETY_DISTANCE", span, 10f, span + 10.0) + string.Format("\n Updated {0} to appropriate value ({1})", "spawnLocoPlayerSqrDistanceFromTrack", spawnLocoPlayerSqrDistanceFromTrack), this);
		}
	}
}
