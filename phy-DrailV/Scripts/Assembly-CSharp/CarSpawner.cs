using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.JObjectExtstensions;
using DV.Logic.Job;
using DV.MultipleUnit;
using DV.PointSet;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CarSpawner : SingletonBehaviour<CarSpawner>
{
	[Serializable]
	public class PooledCarTypeSetup
	{
		public TrainCarType_v2 carType;

		public int numberOfPooledInstancesPerLivery;

		public PooledCarTypeSetup(TrainCarType_v2 carType, int numberOfPooledInstancesPerLivery)
		{
			this.carType = carType;
			this.numberOfPooledInstancesPerLivery = numberOfPooledInstancesPerLivery;
		}
	}

	public enum SpawnDataResult
	{
		Uninitialized = 0,
		Invalid = 1,
		OK = 2,
		Blocked = 3,
		CannotFitOnTrack = 4
	}

	public struct SpawnData
	{
		public RailTrack track;

		public float trainLength;

		public float carSpacing;

		public SpawnDataResult result;

		public CarSpawnData[] carData;

		public bool flipped;

		public string message;

		public SpawnData(RailTrack track, float trainLength, float carSpacing, SpawnDataResult result, CarSpawnData[] carData, bool flipped, string message = "")
		{
			this.track = track;
			this.trainLength = trainLength;
			this.carSpacing = carSpacing;
			this.result = result;
			this.carData = carData;
			this.flipped = flipped;
			this.message = message;
		}
	}

	public struct CarSpawnData
	{
		public GameObject prefab;

		public Bounds bounds;

		public Vector3 position;

		public Vector3 forward;

		public bool orientationReversed;

		public CarSpawnData(GameObject prefab, Bounds bounds, Vector3 position, Vector3 forward, bool orientationReversed)
		{
			this.prefab = prefab ?? throw new ArgumentNullException("prefab");
			this.bounds = bounds;
			this.position = position;
			this.forward = forward;
			this.orientationReversed = orientationReversed;
		}
	}

	public delegate void CarSpawnEvent(TrainCar car);

	private const float REQ_DIST_FROM_CAR_END_TO_END_OF_TRACK = 2.5f;

	private const float REQ_DIST_FROM_CAR_END_TO_JUNCTION_OUT_BRANCH = 15f;

	private const float SEPARATION_BETWEEN_TRAIN_CARS = 0.3f;

	private Dictionary<TrainCarLivery, float> carLiveryToCarLength;

	private bool useCarPooling = true;

	public PooledCarTypeSetup[] poolSetup;

	public GarageType_v2[] crewVehicleGarages;

	public TrainCarLivery[] vehiclesWithoutGarage;

	private bool poolInitialized;

	private Dictionary<TrainCarLivery, List<TrainCar>> carLiveryToTrainCarPool = new Dictionary<TrainCarLivery, List<TrainCar>>();

	private HashSet<TrainCar> trainCarPoolHashSet = new HashSet<TrainCar>();

	private Dictionary<TrainCarLivery, JObject> deletedUniqueCarLiveryToLastCarState = new Dictionary<TrainCarLivery, JObject>();

	private List<TrainCar> allCars;

	private List<TrainCar> allLocos;

	private List<TrainCar> allSpecialCars;

	private static Collider[] colOverlappingResults = new Collider[15];

	private static int _trainCheckLayerMask = 0;

	public bool PoolSetupInProgress
	{
		get
		{
			if (useCarPooling)
			{
				return !poolInitialized;
			}
			return false;
		}
	}

	public List<TrainCar> AllCars => allCars;

	public List<TrainCar> AllLocos => allLocos;

	public List<TrainCar> AllSpecialCars => allSpecialCars;

	private static int TrainCheckLayerMask
	{
		get
		{
			if (_trainCheckLayerMask == 0)
			{
				_trainCheckLayerMask = LayerMask.GetMask("Train_Big_Collider", "Default", "Terrain");
			}
			return _trainCheckLayerMask;
		}
	}

	public event CarSpawnEvent CarSpawned;

	public event CarSpawnEvent CarAboutToBeDeleted;

	public JObject GetDeletedUniqueCarData()
	{
		JObject jObject = new JObject();
		foreach (TrainCarLivery key in deletedUniqueCarLiveryToLastCarState.Keys)
		{
			jObject.SetJObject(key.id, deletedUniqueCarLiveryToLastCarState[key]);
		}
		return jObject;
	}

	public void LoadDeletedUniqueCarData(JObject data)
	{
		foreach (KeyValuePair<string, JToken> datum in data)
		{
			if (Globals.G.Types.TryGetLivery(datum.Key, out var livery) && datum.Value is JObject jObject)
			{
				deletedUniqueCarLiveryToLastCarState.Add(livery, jObject);
				string idFromCarData = CarsSaveManager.UniqueCarDataToLoad.GetIdFromCarData(jObject);
				if (idFromCarData != null)
				{
					SingletonBehaviour<IdGenerator>.Instance.ReserveCarId(idFromCarData);
				}
				else
				{
					Debug.LogError("Unexpected state: Missing id data from carLiveryToJObjectData. Ignoring id reservation");
				}
			}
			else
			{
				Debug.LogError("Unexpected state: carLiveryToJObjectData key: " + datum.Key + " couldn't be extracted. Ignoring load request");
			}
		}
	}

	public bool IsCarInPool(TrainCar trainCar)
	{
		return trainCarPoolHashSet.Contains(trainCar);
	}

	public bool IsCarLiveryPooled(TrainCarLivery carLivery)
	{
		return carLiveryToTrainCarPool.ContainsKey(carLivery);
	}

	private void DeinitPool()
	{
		poolInitialized = false;
		carLiveryToTrainCarPool.Clear();
		trainCarPoolHashSet.Clear();
	}

	private void InitPool()
	{
		DeinitPool();
		SingletonBehaviour<CoroutineManager>.Instance.Run(InitPoolCoro());
	}

	private IEnumerator InitPoolCoro()
	{
		yield return null;
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			while (WorldMover.OriginShiftParent == null)
			{
				yield return null;
			}
		}
		float num = 0f;
		float startingOffsetX = 0f;
		List<TrainCar> spawnedCarsForPool = new List<TrainCar>();
		PooledCarTypeSetup[] array = poolSetup;
		foreach (PooledCarTypeSetup carTypeSetup in array)
		{
			foreach (TrainCarLivery livery in carTypeSetup.carType.liveries)
			{
				if (CarTypes.IsAnyLocomotiveOrTender(livery))
				{
					Debug.LogError("Unexpected state: Locos [" + livery.id + "] can't be pooled currently, skipping.");
					continue;
				}
				GameObject prefab = livery.prefab;
				if (prefab == null)
				{
					Debug.LogError("Unexpected state: Pooled car livery " + livery.id + " has null for prefab, ignoring pooling.");
					continue;
				}
				List<TrainCar> value = new List<TrainCar>();
				carLiveryToTrainCarPool.Add(livery, value);
				for (int j = 0; j < carTypeSetup.numberOfPooledInstancesPerLivery; j++)
				{
					TrainCar component = UnityEngine.Object.Instantiate(prefab, new Vector3(startingOffsetX, -2000f, num), Quaternion.identity).GetComponent<TrainCar>();
					component.rb.isKinematic = true;
					num += 30f;
					spawnedCarsForPool.Add(component);
				}
				yield return WaitFor.EndOfFrame;
				foreach (TrainCar item in spawnedCarsForPool)
				{
					ReturnToPool(item);
				}
				spawnedCarsForPool.Clear();
				for (int k = 0; k < 2; k++)
				{
					yield return null;
				}
				startingOffsetX += 10f;
				num = 0f;
			}
		}
		poolInitialized = true;
		Debug.Log("Car pool initialized.");
	}

	public void ReturnToPool(TrainCar car)
	{
		if (carLiveryToTrainCarPool.TryGetValue(car.carLivery, out var value))
		{
			value.Add(car);
			trainCarPoolHashSet.Add(car);
			car.transform.SetParent(SingletonBehaviour<CarSpawner>.Instance.transform);
			car.gameObject.SetActive(value: false);
			car.interior.transform.SetParent(SingletonBehaviour<CarSpawner>.Instance.transform);
			car.interior.gameObject.SetActive(value: false);
		}
		else
		{
			Debug.LogError("Attempted to add unpooled car type to pool: " + car.carLivery.id, car);
		}
	}

	public GameObject GetFromPool(GameObject carToSpawnPrefab)
	{
		TrainCar component = carToSpawnPrefab.GetComponent<TrainCar>();
		if (carLiveryToTrainCarPool.TryGetValue(component.carLivery, out var value))
		{
			int count = value.Count;
			if (count > 0)
			{
				int index = count - 1;
				TrainCar trainCar = value[index];
				value.RemoveAt(index);
				if (!trainCarPoolHashSet.Remove(trainCar))
				{
					Debug.LogError("No entry in hashset!", trainCar);
				}
				if (trainCar != null)
				{
					trainCar.transform.SetParent(null);
					trainCar.transform.localScale = Vector3.one;
					trainCar.gameObject.SetActive(value: true);
					trainCar.interior.transform.SetParent(null);
					trainCar.interior.transform.localScale = Vector3.one;
					trainCar.interior.gameObject.SetActive(value: true);
					trainCar.rb.isKinematic = false;
					trainCar.AwakeForPooledCar();
					return trainCar.gameObject;
				}
				Debug.LogError("NOT WORKING!! null entry in pool");
				return UnityEngine.Object.Instantiate(carToSpawnPrefab);
			}
			return UnityEngine.Object.Instantiate(carToSpawnPrefab);
		}
		return UnityEngine.Object.Instantiate(carToSpawnPrefab);
	}

	protected override void Awake()
	{
		base.Awake();
		carLiveryToCarLength = new Dictionary<TrainCarLivery, float>();
		foreach (TrainCarLivery livery in Globals.G.Types.Liveries)
		{
			float value = ((livery.prefab != null) ? livery.prefab.GetComponent<TrainCar>().InterCouplerDistance : 20f);
			carLiveryToCarLength.Add(livery, value);
		}
		allCars = UnityEngine.Object.FindObjectsOfType<TrainCar>().ToList();
		allLocos = allCars.Where((TrainCar t) => t.IsLoco).ToList();
		allSpecialCars = allCars.Where((TrainCar t) => CarTypes.IsCaboose(t.carLivery)).ToList();
		UnloadWatcher.UnloadRequested += OnGameUnload;
		if (useCarPooling)
		{
			InitPool();
		}
		else
		{
			Debug.Log("Not using car pooling");
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		UnloadWatcher.UnloadRequested -= OnGameUnload;
		DeinitPool();
	}

	private void FireCarSpawned(TrainCar car)
	{
		allCars.Add(car);
		if (car.IsLoco)
		{
			allLocos.Add(car);
		}
		if (car.IsCaboose)
		{
			allSpecialCars.Add(car);
		}
		this.CarSpawned?.Invoke(car);
	}

	private void FireCarAboutToBeDeleted(TrainCar car)
	{
		allCars.Remove(car);
		if (car.IsLoco)
		{
			allLocos.Remove(car);
		}
		if (CarTypes.IsCaboose(car.carLivery))
		{
			allSpecialCars.Remove(car);
		}
		car.Fire_OnCarAboutToBeDestroyed();
		this.CarAboutToBeDeleted?.Invoke(car);
	}

	private void OnGameUnload()
	{
		UnloadWatcher.UnloadRequested -= OnGameUnload;
		DeleteTrainCars(allCars, forceInstantDestroy: true);
	}

	public TrainCar SpawnCarOnClosestTrack(Vector3 spawnPosition, TrainCarLivery carLivery, bool flipRotation, bool playerSpawnedCar, bool uniqueCar)
	{
		GameObject prefab = carLivery.prefab;
		if (prefab == null)
		{
			Debug.LogError("Unexpected state: carLivery." + carLivery.id + " is missing prefab! Ignoring spawn request.");
			return null;
		}
		Bounds boundsOfCar = GetBoundsOfCar(prefab);
		int closestNodeIndex;
		RailTrack trackClosestTo = GetTrackClosestTo(spawnPosition, boundsOfCar.extents.z, out closestNodeIndex);
		if (trackClosestTo == null)
		{
			Debug.LogError("Couldn't find closest track! No tracks in scene");
			return null;
		}
		var (flag, position, forward, _) = FindNearestAvailableSpace(trackClosestTo, boundsOfCar, closestNodeIndex, flipRotation);
		if (flag)
		{
			return SpawnCar(prefab, trackClosestTo, position, forward, playerSpawnedCar, uniqueCar);
		}
		return null;
	}

	public TrainCar SpawnCrewVehicle(TrainCarLivery livery, RailTrack track, Vector3 absolutePosition, Vector3 forward, GarageCarSpawner selectedGarageSpawner = null)
	{
		bool flag = selectedGarageSpawner != null || GarageCarSpawner.Spawners.TryGetValue(livery, out selectedGarageSpawner);
		Vector3 vector = absolutePosition + WorldMover.currentMove;
		TrainCar trainCar = (flag ? selectedGarageSpawner.GetCar(livery) : AllCars.FirstOrDefault((TrainCar c) => c.carLivery == livery));
		TrainCar trainCar2 = null;
		if (trainCar != null)
		{
			if (trainCar.derailed)
			{
				trainCar.Rerail(track, vector, forward);
			}
			else
			{
				trainCar.MoveToTrackWithCarUncouple(track, vector, forward);
			}
			if (trainCar != null)
			{
				BaseControlsOverrider baseControlsOverrider = trainCar.SimController?.controlsOverrider;
				if (baseControlsOverrider != null)
				{
					baseControlsOverrider.SetNeutralState();
				}
			}
			trainCar2 = trainCar;
		}
		else
		{
			TrainCar trainCar3 = SpawnCar(livery.prefab, track, vector, forward, playerSpawnedCar: true, uniqueCar: true);
			if (trainCar3 != null)
			{
				trainCar2 = trainCar3;
			}
			if (flag)
			{
				selectedGarageSpawner.OverrideSpawnedCarReference(trainCar3);
			}
		}
		if (trainCar2 != null)
		{
			trainCar2.SetupHandbrakesOnManualSpawn();
		}
		return trainCar2;
	}

	public TrainCar SpawnCarFromRemote(GameObject carToSpawn, RailTrack track, Vector3 absolutePosition, Vector3 forward)
	{
		TrainCar trainCar = SpawnCar(carToSpawn, track, absolutePosition + WorldMover.currentMove, forward, playerSpawnedCar: true);
		if (trainCar == null)
		{
			return null;
		}
		SingletonBehaviour<UnusedTrainCarDeleter>.Instance.MarkForDelete(trainCar.logicCar);
		trainCar.SetupHandbrakesOnManualSpawn();
		return trainCar;
	}

	public TrainCar SpawnCar(GameObject carToSpawn, RailTrack track, Vector3 position, Vector3 forward, bool playerSpawnedCar = false, bool uniqueCar = false)
	{
		TrainCar trainCar = BaseSpawn(carToSpawn, playerSpawnedCar, uniqueCar);
		trainCar.SetTrack(track, position, forward);
		trainCar.TryAddFastTravelDestination();
		FireCarSpawned(trainCar);
		trainCar.frontCoupler.AttemptAutoCouple();
		trainCar.rearCoupler.AttemptAutoCouple();
		return trainCar;
	}

	public TrainCar SpawnDerailedCar(GameObject carToSpawn, Vector3 position, Quaternion rotation, bool playerSpawnedCar = false, bool uniqueCar = false)
	{
		TrainCar trainCar = BaseSpawn(carToSpawn, playerSpawnedCar, uniqueCar);
		trainCar.transform.position = position;
		trainCar.transform.rotation = rotation;
		trainCar.FrontBogie.SetDerailedOnLoadFlag(set: true);
		trainCar.RearBogie.SetDerailedOnLoadFlag(set: true);
		trainCar.TryAddFastTravelDestination();
		FireCarSpawned(trainCar);
		return trainCar;
	}

	private TrainCar BaseSpawn(GameObject carToSpawn, bool playerSpawnedCar, bool uniqueCar)
	{
		TrainCar componentInChildren = (useCarPooling ? GetFromPool(carToSpawn) : UnityEngine.Object.Instantiate(carToSpawn)).GetComponentInChildren<TrainCar>();
		componentInChildren.playerSpawnedCar = playerSpawnedCar;
		componentInChildren.uniqueCar = uniqueCar;
		if (uniqueCar && deletedUniqueCarLiveryToLastCarState.TryGetValue(componentInChildren.carLivery, out var value))
		{
			CarsSaveManager.UniqueCarDataToLoad uniqueCarDataToLoad = new CarsSaveManager.UniqueCarDataToLoad(value);
			if (!string.IsNullOrEmpty(uniqueCarDataToLoad.id) && !string.IsNullOrEmpty(uniqueCarDataToLoad.carGuid))
			{
				deletedUniqueCarLiveryToLastCarState.Remove(componentInChildren.carLivery);
				SingletonBehaviour<IdGenerator>.Instance.UnReserveCarId(uniqueCarDataToLoad.id);
				componentInChildren.InitializeExistingLogicCar(uniqueCarDataToLoad.id, uniqueCarDataToLoad.carGuid);
				CarsSaveManager.RestoreCarState(componentInChildren, uniqueCarDataToLoad.loadedCargoType, uniqueCarDataToLoad.loadedCargoModel, uniqueCarDataToLoad.isExploded, uniqueCarDataToLoad.paintThemeExterior, uniqueCarDataToLoad.paintThemeInterior, uniqueCarDataToLoad.handbrakePosition, uniqueCarDataToLoad.brakePipePressure, uniqueCarDataToLoad.auxResPressure, uniqueCarDataToLoad.mainResPressure, uniqueCarDataToLoad.controlResPressure, uniqueCarDataToLoad.brakeCylPressure, uniqueCarDataToLoad.visitCheckerTimeLeftData, uniqueCarDataToLoad.carState, uniqueCarDataToLoad.simCarState, uniqueCarDataToLoad.modCarState);
			}
			else
			{
				Debug.LogError("Unexpected state: UniqueCarDataToLoad has uninitialized car id/guid. Treating as new spawn");
				componentInChildren.InitializeNewLogicCar();
			}
		}
		else
		{
			componentInChildren.InitializeNewLogicCar();
		}
		return componentInChildren;
	}

	public TrainCar SpawnLoadedCar(GameObject carToSpawn, string carId, string carGuid, bool playerSpawnedCar, bool uniqueCar, Vector3 position, Quaternion rotation, bool bogie1Derailed, RailTrack bogie1Track, double bogie1PositionAlongTrack, bool bogie2Derailed, RailTrack bogie2Track, double bogie2PositionAlongTrack)
	{
		TrainCar componentInChildren = UnityEngine.Object.Instantiate(carToSpawn, position, rotation).GetComponentInChildren<TrainCar>();
		componentInChildren.playerSpawnedCar = playerSpawnedCar;
		componentInChildren.uniqueCar = uniqueCar;
		componentInChildren.InitializeExistingLogicCar(carId, carGuid);
		if (!bogie1Derailed)
		{
			componentInChildren.RearBogie.SetTrack(bogie1Track, bogie1PositionAlongTrack);
		}
		else
		{
			componentInChildren.RearBogie.SetDerailedOnLoadFlag(set: true);
		}
		if (!bogie2Derailed)
		{
			componentInChildren.FrontBogie.SetTrack(bogie2Track, bogie2PositionAlongTrack);
		}
		else
		{
			componentInChildren.FrontBogie.SetDerailedOnLoadFlag(set: true);
		}
		componentInChildren.TryAddFastTravelDestination();
		FireCarSpawned(componentInChildren);
		return componentInChildren;
	}

	public TrainCar SpawnLoadedCarAtNearestAvailableSpace(GameObject carToSpawn, Bounds carBounds, string carId, string carGuid, bool playerSpawnedCar, bool uniqueCar, Vector3 targetPosition, float searchRange)
	{
		(RailTrack, EquiPointSet.Point)? pointOnClosestAvailableTrackForCar = GetPointOnClosestAvailableTrackForCar(targetPosition, carBounds.extents, SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks, 1f, 5f, searchRange);
		if (!pointOnClosestAvailableTrackForCar.HasValue)
		{
			Debug.LogError($"Couldn't find place for car in {searchRange}m radius!");
			return null;
		}
		RailTrack item = pointOnClosestAvailableTrackForCar.Value.Item1;
		EquiPointSet.Point item2 = pointOnClosestAvailableTrackForCar.Value.Item2;
		Vector3 forward = item2.forward;
		Vector3 worldPosition = (Vector3)item2.position + WorldMover.currentMove;
		TrainCar componentInChildren = UnityEngine.Object.Instantiate(carToSpawn).GetComponentInChildren<TrainCar>();
		componentInChildren.playerSpawnedCar = playerSpawnedCar;
		componentInChildren.uniqueCar = uniqueCar;
		componentInChildren.InitializeExistingLogicCar(carId, carGuid);
		componentInChildren.SetTrack(item, worldPosition, forward);
		componentInChildren.GetComponent<TrainCarInteriorPhysics>()?.SyncPosition();
		componentInChildren.TryAddFastTravelDestination();
		FireCarSpawned(componentInChildren);
		componentInChildren.frontCoupler.AttemptAutoCouple();
		componentInChildren.rearCoupler.AttemptAutoCouple();
		return componentInChildren;
	}

	public List<TrainCar> SpawnCars(SpawnData spawnData, bool preventAutoCoupleOnLastCars, bool applyHandbrakeOnLastCars, bool playerSpawnedCars = false, bool uniqueSpawnedCars = false)
	{
		List<TrainCar> list = new List<TrainCar>();
		int num = spawnData.carData.Length;
		for (int i = 0; i < num; i++)
		{
			CarSpawnData carSpawnData = spawnData.carData[i];
			TrainCar item = SpawnCar(carSpawnData.prefab, spawnData.track, carSpawnData.position, carSpawnData.forward, playerSpawnedCars, uniqueSpawnedCars);
			list.Add(item);
		}
		if (preventAutoCoupleOnLastCars)
		{
			int num2 = 0;
			int num3 = num - 1;
			Coupler coupler = (spawnData.carData[num2].orientationReversed ? list[num2].rearCoupler : list[num2].frontCoupler);
			Coupler obj = (spawnData.carData[num3].orientationReversed ? list[num3].frontCoupler : list[num3].rearCoupler);
			coupler.preventAutoCouple = true;
			obj.preventAutoCouple = true;
		}
		if (applyHandbrakeOnLastCars)
		{
			int index = ((!(UnityEngine.Random.value < 0.5f) || !list[0].brakeSystem.hasHandbrake) ? (num - 1) : 0);
			BrakeSystem brakeSystem = list[index].brakeSystem;
			if (brakeSystem.hasHandbrake)
			{
				brakeSystem.SetHandbrakePosition(1f);
			}
			else
			{
				Debug.LogError($"Unexpected state: last car {brakeSystem.gameObject} has no handbrake, so it can't be set!");
			}
		}
		return list;
	}

	public List<TrainCar> SpawnCarTypesOnTrack(List<TrainCarLivery> trainCarTypes, List<bool> carsOrientationReversed, RailTrack railTrack, bool preventAutoCoupleOnLastCars, bool applyHandbrakeOnLastCars, double startSpan = 0.0, bool flipTrainConsist = false, bool playerSpawnedCars = false)
	{
		SpawnData trackMiddleBasedSpawnData = GetTrackMiddleBasedSpawnData(trainCarTypes, carsOrientationReversed, railTrack, startSpan, flipTrainConsist);
		if (trackMiddleBasedSpawnData.result == SpawnDataResult.OK)
		{
			return SpawnCars(trackMiddleBasedSpawnData, preventAutoCoupleOnLastCars, applyHandbrakeOnLastCars, playerSpawnedCars);
		}
		return null;
	}

	public List<TrainCar> SpawnCarTypesOnTrackRandomOrientation(List<TrainCarLivery> trainCarTypes, RailTrack railTrack, bool preventAutoCoupleOnLastCars, bool applyHandbrakeOnLastCars, double startSpan = 0.0, bool flipTrainConsist = false, bool playerSpawnedCars = false)
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < trainCarTypes.Count; i++)
		{
			list.Add(UnityEngine.Random.value <= 0.5f);
		}
		return SpawnCarTypesOnTrack(trainCarTypes, list, railTrack, preventAutoCoupleOnLastCars, applyHandbrakeOnLastCars, startSpan, flipTrainConsist, playerSpawnedCars);
	}

	public List<TrainCar> SpawnCarTypesOnTrackStrict(List<TrainCarLivery> trainCarTypes, RailTrack railTrack, bool preventAutoCoupleOnLastcars, bool applyHandbrakeOnLastCars, double startSpan = 0.0, bool flipTrainConsist = false, bool randomCarOrientation = false, bool playerSpawnedCars = false)
	{
		List<bool> list = null;
		if (randomCarOrientation)
		{
			list = new List<bool>();
			for (int i = 0; i < trainCarTypes.Count; i++)
			{
				list.Add(UnityEngine.Random.value <= 0.5f);
			}
		}
		SpawnData spawnData = GetUninitializedSpawnData(trainCarTypes, list, railTrack, flipTrainConsist);
		PopulateSpawnData(ref spawnData, startSpan);
		if (spawnData.result != SpawnDataResult.OK)
		{
			Debug.LogWarning($"Couldn't spawn cars (strict), result: '{spawnData.result}', message: '{spawnData.message}'");
			return null;
		}
		return SpawnCars(spawnData, preventAutoCoupleOnLastcars, applyHandbrakeOnLastCars, playerSpawnedCars);
	}

	public List<TrainCar> SpawnCarTypesOnClosestTrack(List<TrainCarLivery> trainCarTypes, Vector3 spawnPosition, List<bool> carsOrientationReversed, bool preventAutoCoupleOnLastCars, bool applyHandbrakeOnLastCars, double startSpan = 0.0, bool flipTrainConsist = false, bool playerSpawnedCars = false, bool uniqueSpawnedCars = false)
	{
		HashSet<RailTrack> hashSet = new HashSet<RailTrack>(SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks);
		while (hashSet.Any())
		{
			(RailTrack, EquiPointSet.Point?) closest = RailTrack.GetClosest(spawnPosition, 0f, hashSet);
			SpawnData trackMiddleBasedSpawnData = GetTrackMiddleBasedSpawnData(trainCarTypes, carsOrientationReversed, closest.Item1, startSpan, flipTrainConsist);
			if (trackMiddleBasedSpawnData.result == SpawnDataResult.OK)
			{
				return SpawnCars(trackMiddleBasedSpawnData, preventAutoCoupleOnLastCars, applyHandbrakeOnLastCars, playerSpawnedCars, uniqueSpawnedCars);
			}
			hashSet.Remove(closest.Item1);
		}
		return null;
	}

	public void DeleteCar(TrainCar trainCar)
	{
		if (trainCar == null)
		{
			Debug.LogError("TrainCar passed to delete is null!");
			return;
		}
		PrepareTrainCarForDeleting(trainCar);
		ActuallyDeletingTrainCar(trainCar);
	}

	private void PrepareTrainCarForDeleting(TrainCar trainCar)
	{
		Coupler[] couplers = trainCar.couplers;
		foreach (Coupler coupler in couplers)
		{
			if (coupler.IsCoupled())
			{
				coupler.Uncouple(playAudio: false);
			}
			else if (coupler.hoseAndCock.IsHoseConnected)
			{
				HoseAndCock connectedTo = coupler.hoseAndCock.connectedTo;
				TrainCar trainCar2 = TrainCar.Resolve(connectedTo.parentSystem.gameObject);
				(connectedTo.isFront ? trainCar2.frontCoupler : trainCar2.rearCoupler).IsCockOpen = false;
				coupler.IsCockOpen = false;
				coupler.DisconnectAirHose(playAudio: false);
			}
			else if (coupler.IsCockOpen)
			{
				coupler.IsCockOpen = false;
			}
		}
		MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(trainCar);
		trainCar.logicCar.ClearTracks();
		if (trainCar.uniqueCar)
		{
			deletedUniqueCarLiveryToLastCarState[trainCar.carLivery] = CarsSaveManager.GetCarSaveData(trainCar, null, includeWorldBogieCouplerData: false);
			SingletonBehaviour<IdGenerator>.Instance.ReserveCarId(trainCar.ID);
		}
		FireCarAboutToBeDeleted(trainCar);
	}

	private void ActuallyDeletingTrainCar(TrainCar trainCar)
	{
		bool flag = trainCar.AreBogiesFullyInitialized();
		bool flag2 = !UnloadWatcher.isUnloading && useCarPooling && IsCarLiveryPooled(trainCar.carLivery) && flag;
		if (trainCar.interior != null)
		{
			trainCar.InteriorOnDestroy();
			if (!flag2)
			{
				UnityEngine.Object.Destroy(trainCar.interior.gameObject);
			}
		}
		if (flag2)
		{
			trainCar.ReturnCarToPool();
			return;
		}
		trainCar.PrepareForDestroy();
		UnityEngine.Object.Destroy(trainCar.gameObject);
	}

	public void DeleteTrainCarsFromTrack(RailTrack railTrack)
	{
		HashSet<TrainCar> hashSet = new HashSet<TrainCar>();
		foreach (Bogie item in railTrack.BogiesOnTrack())
		{
			hashSet.Add(item.Car);
		}
		StartCoroutine(DeleteTrainCarsThroughPeriodOfTime(hashSet.ToList()));
	}

	public void DeleteTrainCars(List<TrainCar> trainCarsToDelete, bool forceInstantDestroy = false)
	{
		if (trainCarsToDelete != null && trainCarsToDelete.Count != 0)
		{
			if (forceInstantDestroy)
			{
				DeleteTrainCarsInstant(trainCarsToDelete);
			}
			else
			{
				StartCoroutine(DeleteTrainCarsThroughPeriodOfTime(trainCarsToDelete));
			}
		}
	}

	private void DeleteTrainCarsInstant(List<TrainCar> trainCarsToDelete)
	{
		for (int num = trainCarsToDelete.Count - 1; num >= 0; num--)
		{
			TrainCar trainCar = trainCarsToDelete[num];
			if (trainCar == null)
			{
				Debug.LogError("Reference of trainCarToDelete we want to deleting is null! This shouldn't happen, skipping this entry to try to recover!");
			}
			else
			{
				DeleteCar(trainCar);
			}
		}
	}

	private IEnumerator DeleteTrainCarsThroughPeriodOfTime(List<TrainCar> trainCarsToDelete)
	{
		for (int i = trainCarsToDelete.Count - 1; i >= 0; i--)
		{
			TrainCar trainCar = trainCarsToDelete[i];
			if (trainCar == null)
			{
				Debug.LogError("Reference of trainCarToPrepareForDelete we want to prepare for deleting is null! This shouldn't happen, skipping this entry to try to recover!");
			}
			else
			{
				PrepareTrainCarForDeleting(trainCar);
				trainCar.gameObject.SetActive(value: false);
				trainCar.interior.gameObject.SetActive(value: false);
				yield return null;
				yield return null;
			}
		}
		for (int i = trainCarsToDelete.Count - 1; i >= 0; i--)
		{
			TrainCar trainCar2 = trainCarsToDelete[i];
			if (trainCar2 == null)
			{
				Debug.LogError("Reference of trainCarToDelete we want to destroy is null! This shouldn't happen, skipping this entry to try to recover!");
			}
			else
			{
				ActuallyDeletingTrainCar(trainCar2);
				trainCarsToDelete.RemoveAt(i);
				yield return WaitFor.SecondsRealtime(0.05f);
			}
		}
	}

	public float GetTotalCarLiveriesLength(List<TrainCarLivery> carLiveries, bool includeSeparationBetweenCars = false)
	{
		float num = 0f;
		for (int i = 0; i < carLiveries.Count; i++)
		{
			num += carLiveryToCarLength[carLiveries[i]];
		}
		if (includeSeparationBetweenCars)
		{
			num += GetSeparationLengthBetweenCars(carLiveries.Count);
		}
		return num;
	}

	public float GetTotalTrainCarsLength(List<Car> trainCars, bool includeSeparationBetweenCars = false)
	{
		float num = 0f;
		for (int i = 0; i < trainCars.Count; i++)
		{
			num += carLiveryToCarLength[trainCars[i].carType];
		}
		if (includeSeparationBetweenCars)
		{
			num += GetSeparationLengthBetweenCars(trainCars.Count);
		}
		return num;
	}

	public float GetTotalCarsLength(List<Car> cars, bool includeSeparationBetweenCars = false)
	{
		float num = 0f;
		for (int i = 0; i < cars.Count; i++)
		{
			num += cars[i].length;
		}
		if (includeSeparationBetweenCars)
		{
			num += GetSeparationLengthBetweenCars(cars.Count);
		}
		return num;
	}

	public float GetSeparationLengthBetweenCars(int numOfCars)
	{
		return 0.3f * (float)(numOfCars + 1);
	}

	public static RailTrack GetTrackClosestTo(Vector3 referencePoint, float minDistFromTrackEnd, out int closestNodeIndex)
	{
		var (railTrack, point) = RailTrack.GetClosest(referencePoint, minDistFromTrackEnd);
		if (railTrack == null)
		{
			Debug.LogWarning("No tracks found", railTrack);
			closestNodeIndex = -1;
			return null;
		}
		closestNodeIndex = point.Value.index;
		return railTrack;
	}

	public static (RailTrack track, EquiPointSet.Point point)? GetPointOnClosestAvailableTrackForCar(Vector3 targetPosition, Vector3 carHalfExtents, RailTrack[] tracksToCheck, float startRange, float rangeIncrement, float maxRange)
	{
		if (tracksToCheck == null || tracksToCheck.Length == 0)
		{
			Debug.LogError("Unexpected state: tracksToCheck is null or has no tracks provided!");
			return null;
		}
		float num = startRange;
		HashSet<RailTrack> hashSet = new HashSet<RailTrack>(tracksToCheck);
		List<(RailTrack, EquiPointSet.Point)> list = new List<(RailTrack, EquiPointSet.Point)>();
		do
		{
			list.Clear();
			foreach (RailTrack item in hashSet)
			{
				EquiPointSet.Point? pointWithinRangeWithYOffset = RailTrack.GetPointWithinRangeWithYOffset(item, targetPosition, num);
				if (pointWithinRangeWithYOffset.HasValue)
				{
					list.Add((item, pointWithinRangeWithYOffset.Value));
				}
			}
			foreach (var item2 in list)
			{
				EquiPointSet.Point[] points = item2.Item1.GetKinkedPointSet().points;
				int index = item2.Item2.index;
				EquiPointSet.Point? point = FindClosestValidPointForCarStartingFromIndex(points, index, carHalfExtents);
				if (point.HasValue)
				{
					return (item2.Item1, point.Value);
				}
				hashSet.Remove(item2.Item1);
			}
			num += rangeIncrement;
		}
		while (!(num > maxRange));
		Debug.LogWarning($"Couldn't find appropriate place in radius of {maxRange}m!");
		return null;
	}

	public GameObject GetCarClosestToReferencePoint(Vector3 referencePoint)
	{
		if (allCars == null)
		{
			return null;
		}
		GameObject result = null;
		float num = float.PositiveInfinity;
		foreach (TrainCar allCar in allCars)
		{
			float num2 = Vector3.SqrMagnitude(allCar.transform.position - referencePoint);
			if (num2 < num)
			{
				num = num2;
				result = allCar.gameObject;
			}
		}
		return result;
	}

	public static SpawnData GetTrackMiddleBasedSpawnData(List<TrainCarLivery> trainCarTypes, List<bool> carsOrientationReversed, RailTrack railTrack, double startSpan = 0.0, bool flipTrainConsist = false)
	{
		double span = railTrack.GetKinkedPointSet().span;
		SpawnData spawnData = GetUninitializedSpawnData(trainCarTypes, carsOrientationReversed, railTrack, flipTrainConsist);
		if (spawnData.result != SpawnDataResult.Uninitialized)
		{
			Debug.LogError($"Couldn't spawn cars (failed before loop), result: '{spawnData.result}', message: '{spawnData.message}'");
			return spawnData;
		}
		startSpan = Math.Max(startSpan, IsConnectedToJunctionOutBranch(railTrack.inBranch) ? 15f : 2.5f);
		float num = (IsConnectedToJunctionOutBranch(railTrack.outBranch) ? 15f : 2.5f);
		double num2 = span - (double)num - (double)spawnData.trainLength;
		bool flag = false;
		bool flag2 = false;
		double num3 = span / 2.0 - (double)(spawnData.trainLength / 2f) + (double)UnityEngine.Random.value * 3.75;
		for (double num4 = 0.0; num4 < span; num4 += 3.75)
		{
			double num5 = num3 + num4;
			if (num5 > num2 && !flag)
			{
				num5 = num2;
				flag = true;
			}
			bool flag3 = num5 <= num2;
			bool flag4 = num5 >= startSpan;
			if (flag3 && flag4)
			{
				PopulateSpawnData(ref spawnData, num5, num);
				if (SpawnDataResult.Blocked != spawnData.result)
				{
					if (SpawnDataResult.CannotFitOnTrack == spawnData.result)
					{
						Debug.LogError("Unexpected outcome: " + SpawnDataResult.CannotFitOnTrack.ToString() + "!");
						return spawnData;
					}
					if (SpawnDataResult.OK == spawnData.result)
					{
						return spawnData;
					}
					Debug.LogError("Unexpected outcome: " + spawnData.result.ToString() + ", message: '" + spawnData.message + "'");
					return spawnData;
				}
			}
			if (num4 == 0.0)
			{
				continue;
			}
			double num6 = num3 - num4;
			if (num6 < startSpan && !flag2)
			{
				num6 = startSpan;
				flag2 = true;
			}
			bool flag5 = num6 >= startSpan;
			bool flag6 = num6 <= num2;
			if (flag5 && flag6)
			{
				PopulateSpawnData(ref spawnData, num6, num);
				if (SpawnDataResult.Blocked != spawnData.result)
				{
					if (SpawnDataResult.CannotFitOnTrack == spawnData.result)
					{
						Debug.LogError("Unexpected outcome: " + SpawnDataResult.CannotFitOnTrack.ToString() + "!");
						return spawnData;
					}
					if (SpawnDataResult.OK == spawnData.result)
					{
						return spawnData;
					}
					Debug.LogError("Unexpected outcome: " + spawnData.result.ToString() + ", message: '" + spawnData.message + "'");
					return spawnData;
				}
			}
			if (!flag3 && !flag5)
			{
				return spawnData;
			}
		}
		Debug.LogError("Unexpected outcome: check algorithm is bugged!");
		return spawnData;
	}

	public static SpawnData GetTrackMiddleBasedSpawnDataRandomOrientation(List<TrainCarLivery> trainCarTypes, RailTrack railTrack, double startSpan = 0.0, bool flipTrainConsist = false)
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < trainCarTypes.Count; i++)
		{
			list.Add(UnityEngine.Random.value <= 0.5f);
		}
		return GetTrackMiddleBasedSpawnData(trainCarTypes, list, railTrack, startSpan, flipTrainConsist);
	}

	private static SpawnData GetUninitializedSpawnData(List<TrainCarLivery> trainCarTypes, List<bool> carsOrientationReversed, RailTrack railTrack, bool flipTrainConsist)
	{
		if (railTrack == null)
		{
			string message = "Given railTrack is null";
			return new SpawnData(railTrack, -1f, 0f, SpawnDataResult.Invalid, null, flipTrainConsist, message);
		}
		EquiPointSet kinkedPointSet = railTrack.GetKinkedPointSet();
		if (kinkedPointSet == null)
		{
			string message2 = $"Given track '{railTrack}' has null pointset";
			return new SpawnData(railTrack, -1f, 0f, SpawnDataResult.Invalid, null, flipTrainConsist, message2);
		}
		for (int i = 0; i < trainCarTypes.Count; i++)
		{
			TrainCarLivery trainCarLivery = trainCarTypes[i];
			string text = null;
			if (trainCarLivery == null)
			{
				text = $"Livery at index {i} is null";
			}
			else if (trainCarLivery.prefab == null)
			{
				text = $"Livery at index {i} has null prefab";
			}
			else if (trainCarLivery.prefab.GetComponent<TrainCar>() == null)
			{
				text = string.Format("Livery at index {0} has prefab that doesn't have {1} component", i, "TrainCar");
			}
			if (text != null)
			{
				return new SpawnData(railTrack, -1f, 0f, SpawnDataResult.Invalid, null, flipTrainConsist, text);
			}
		}
		if (!flipTrainConsist)
		{
			trainCarTypes = new List<TrainCarLivery>(trainCarTypes);
			trainCarTypes.Reverse();
			if (carsOrientationReversed != null)
			{
				carsOrientationReversed = new List<bool>(carsOrientationReversed);
				carsOrientationReversed.Reverse();
			}
		}
		CarSpawnData[] array = new CarSpawnData[trainCarTypes.Count];
		float num = 0f;
		for (int j = 0; j < trainCarTypes.Count; j++)
		{
			GameObject prefab = trainCarTypes[j].prefab;
			Bounds bounds = prefab.GetComponent<TrainCar>().Bounds;
			bool orientationReversed = carsOrientationReversed?[j] ?? false;
			array[j] = new CarSpawnData(prefab, bounds, Vector3.zero, Vector3.zero, orientationReversed);
			num += bounds.size.z;
			if (j < trainCarTypes.Count)
			{
				num += 0f;
			}
		}
		if ((double)num > kinkedPointSet.span)
		{
			return new SpawnData(railTrack, num, 0f, SpawnDataResult.CannotFitOnTrack, null, flipTrainConsist);
		}
		return new SpawnData(railTrack, num, 0f, SpawnDataResult.Uninitialized, array, flipTrainConsist);
	}

	private static void PopulateSpawnData(ref SpawnData spawnData, double startSpan, double minDistFromEndOfTrack = 0.0)
	{
		if (startSpan < 0.0)
		{
			spawnData.result = SpawnDataResult.Invalid;
			spawnData.message = "startSpan must be >= 0";
			return;
		}
		EquiPointSet kinkedPointSet = spawnData.track.GetKinkedPointSet();
		if (startSpan + (double)spawnData.trainLength > kinkedPointSet.span - minDistFromEndOfTrack)
		{
			spawnData.result = SpawnDataResult.CannotFitOnTrack;
			spawnData.message = $"startSpan ({startSpan:0.##}) + trainLength ({spawnData.trainLength:0.##}) > pointSet.span ({kinkedPointSet.span} - minDistFromTrackEnd ({minDistFromEndOfTrack}))";
			return;
		}
		PointSetTraveller pointSetTraveller = new PointSetTraveller(kinkedPointSet);
		pointSetTraveller.Travel(startSpan);
		for (int i = 0; i < spawnData.carData.Length; i++)
		{
			Bounds bounds = spawnData.carData[i].bounds;
			if (bounds.extents.z < 0.5f)
			{
				spawnData.message = "car length is impossibly small";
				spawnData.result = SpawnDataResult.Invalid;
				return;
			}
			double num = pointSetTraveller.Travel(bounds.extents.z);
			if (num != 0.0)
			{
				spawnData.message = $"unexpected overflow {num}";
				spawnData.result = SpawnDataResult.Invalid;
				return;
			}
			Vector3 vector = (Vector3)pointSetTraveller.worldPosition + WorldMover.currentMove;
			Vector3 vector2 = pointSetTraveller.worldForward;
			if (spawnData.carData[i].orientationReversed)
			{
				vector2 = -vector2;
			}
			if (spawnData.flipped)
			{
				vector2 = -vector2;
			}
			if (IsBoxOverlapping(vector, bounds.extents, Quaternion.LookRotation(vector2)))
			{
				spawnData.message = string.Empty;
				spawnData.result = SpawnDataResult.Blocked;
				return;
			}
			spawnData.carData[i].position = vector;
			spawnData.carData[i].forward = vector2;
			pointSetTraveller.Travel(bounds.extents.z + spawnData.carSpacing);
		}
		if (!spawnData.flipped)
		{
			Array.Reverse((Array)spawnData.carData);
		}
		spawnData.message = string.Empty;
		spawnData.result = SpawnDataResult.OK;
	}

	private static bool IsConnectedToJunctionOutBranch(Junction.Branch branch)
	{
		if (branch != null && branch.track != null && branch.track.inJunction != null)
		{
			foreach (Junction.Branch outBranch in branch.track.inJunction.outBranches)
			{
				if (outBranch.track == branch.track)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static Bounds GetBoundsOfCar(GameObject car)
	{
		return car.GetComponent<TrainCar>().Bounds;
	}

	public static bool IsBoxOverlapping(Vector3 positionOnTrack, Vector3 halfExtent, Quaternion rotation, TrainCar carToIgnore = null)
	{
		positionOnTrack.y += halfExtent.y;
		float num = 1.5f;
		float num2 = Mathf.Max(0f, num - halfExtent.y);
		halfExtent.y += num2;
		positionOnTrack.y += num2;
		positionOnTrack.y += 0.15f;
		int num3 = Physics.OverlapBoxNonAlloc(positionOnTrack, halfExtent, colOverlappingResults, rotation, TrainCheckLayerMask, QueryTriggerInteraction.Ignore);
		if (num3 > 0 && carToIgnore != null)
		{
			Transform transform = carToIgnore.transform;
			for (int i = 0; i < num3; i++)
			{
				if (colOverlappingResults[i].transform.root != transform)
				{
					return true;
				}
			}
			return false;
		}
		return num3 > 0;
	}

	public static bool IsBoxOverlappingSimple(Vector3 positionOnTrack, Vector3 halfExtent, Quaternion rotation)
	{
		return Physics.OverlapBoxNonAlloc(positionOnTrack, halfExtent, colOverlappingResults, rotation, TrainCheckLayerMask, QueryTriggerInteraction.Ignore) > 0;
	}

	private static bool IsCloseToEndOfTrack(Vector3 positionToCheck, Vector3 startTrackPosition, Vector3 endTrackPosition, float requiredDistanceFromPivotToTrackEnd)
	{
		float num = Vector3.SqrMagnitude(startTrackPosition - positionToCheck);
		float num2 = Vector3.SqrMagnitude(endTrackPosition - positionToCheck);
		float num3 = requiredDistanceFromPivotToTrackEnd * requiredDistanceFromPivotToTrackEnd;
		if (!(num < num3))
		{
			return num2 < num3;
		}
		return true;
	}

	public static EquiPointSet.Point? FindClosestValidPointForCarStartingFromIndex(EquiPointSet.Point[] trackPoints, int startPointIndex, Vector3 carBoundsHalfExtents, TrainCar carToIgnore = null)
	{
		int num = trackPoints.Length;
		Vector3 trackStart = (Vector3)trackPoints[0].position + WorldMover.currentMove;
		Vector3 trackEnd = (Vector3)trackPoints[num - 1].position + WorldMover.currentMove;
		for (int i = 0; i < num; i++)
		{
			int num2 = startPointIndex + i;
			bool flag = num2 <= num - 1;
			if (flag)
			{
				EquiPointSet.Point point = trackPoints[num2];
				if (IsThereSpaceForCarOnPoint(point, trackStart, trackEnd, carBoundsHalfExtents, carToIgnore))
				{
					return point;
				}
			}
			if (i == 0)
			{
				continue;
			}
			int num3 = startPointIndex - i;
			bool flag2 = num3 >= 0;
			if (flag2)
			{
				EquiPointSet.Point point2 = trackPoints[num3];
				if (IsThereSpaceForCarOnPoint(point2, trackStart, trackEnd, carBoundsHalfExtents, carToIgnore))
				{
					return point2;
				}
			}
			if (!flag && !flag2)
			{
				return null;
			}
		}
		return null;
	}

	public static EquiPointSet.Point? FindValidPointInOneDirectionForCarStartingFromIndex(EquiPointSet.Point[] trackPoints, int startPointIndex, Vector3 carBoundsHalfExtents, bool forwardDirection, TrainCar carToIgnore = null)
	{
		int num = trackPoints.Length;
		Vector3 trackStart = (Vector3)trackPoints[0].position + WorldMover.currentMove;
		Vector3 trackEnd = (Vector3)trackPoints[num - 1].position + WorldMover.currentMove;
		for (int i = 0; i < num; i++)
		{
			int num2 = startPointIndex + (forwardDirection ? i : (-i));
			if (num2 <= num - 1 && num2 >= 0)
			{
				EquiPointSet.Point point = trackPoints[num2];
				if (IsThereSpaceForCarOnPoint(point, trackStart, trackEnd, carBoundsHalfExtents, carToIgnore))
				{
					return point;
				}
				continue;
			}
			return null;
		}
		return null;
	}

	private static bool IsThereSpaceForCarOnPoint(EquiPointSet.Point trackPoint, Vector3 trackStart, Vector3 trackEnd, Vector3 carBoundsHalfExtents, TrainCar carToIgnore = null)
	{
		Vector3 vector = (Vector3)trackPoint.position;
		Vector3 forward = trackPoint.forward;
		Vector3 vector2 = vector + WorldMover.currentMove;
		if (IsBoxOverlapping(vector2, carBoundsHalfExtents, Quaternion.LookRotation(forward), carToIgnore))
		{
			return false;
		}
		return !IsCloseToEndOfTrack(vector2, trackStart, trackEnd, carBoundsHalfExtents.z);
	}

	public static (bool ok, Vector3 position, Vector3 forward, int nodeIndex) FindNearestAvailableSpace(RailTrack track, Bounds bounds, int nodeIndex, bool reverse)
	{
		EquiPointSet kinkedPointSet = track.GetKinkedPointSet();
		bool flag = false;
		Vector3 zero = Vector3.zero;
		Vector3 one = Vector3.one;
		Vector3 startTrackPosition = (Vector3)kinkedPointSet.points[0].position;
		Vector3 endTrackPosition = (Vector3)kinkedPointSet.points[kinkedPointSet.points.Length - 1].position;
		bool flag2;
		while (true)
		{
			EquiPointSet.Point point = kinkedPointSet.points[nodeIndex];
			zero = (Vector3)point.position + WorldMover.currentMove;
			one = ((!reverse) ? 1 : (-1)) * point.forward;
			flag2 = IsBoxOverlapping(zero, bounds.extents, Quaternion.LookRotation(one));
			bool flag3 = IsCloseToEndOfTrack((Vector3)kinkedPointSet.points[nodeIndex + ((!reverse) ? 1 : (-1))].position, startTrackPosition, endTrackPosition, bounds.extents.z);
			bool flag4 = reverse && nodeIndex == 0;
			bool flag5 = !reverse && nodeIndex == kinkedPointSet.points.Length - 1;
			if (!flag2 || flag4 || flag5 || flag3)
			{
				break;
			}
			nodeIndex += ((!reverse) ? 1 : (-1));
		}
		flag = !flag2;
		return (ok: flag, position: zero, forward: one, nodeIndex: nodeIndex);
	}
}
