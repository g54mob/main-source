using System.Collections.Generic;
using DV;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class TrainComponentPool : SingletonBehaviour<TrainComponentPool>
{
	[Header("Cargo effects data")]
	public CargoPoolReferences cargoPoolReferences;

	[Header("Default audio data")]
	public GameObject defaultAudioPrefab;

	public int defaultAudioPoolSize = 50;

	private GameObject poolParent;

	private const string AUDIO_POOL_PARENT = "[ComponentPoolParent]";

	private Dictionary<TrainCarType_v2, List<TrainAudio>> carTypeToAudioPool = new Dictionary<TrainCarType_v2, List<TrainAudio>>();

	private List<TrainAudio> defaultAudioPool = new List<TrainAudio>();

	private Dictionary<CargoEffectsType, List<CargoComponentData>> cargoComponentToCargoComponentPool = new Dictionary<CargoEffectsType, List<CargoComponentData>>();

	private Dictionary<CargoEffectsType, CargoPoolReferences.CargoPoolData> cargoComponentToPoolData = new Dictionary<CargoEffectsType, CargoPoolReferences.CargoPoolData>();

	protected override void Awake()
	{
		base.Awake();
		poolParent = new GameObject("[ComponentPoolParent]");
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			poolParent.transform.parent = WorldMover.OriginShiftParent;
			poolParent.transform.localPosition = Vector3.zero;
			poolParent.transform.localRotation = Quaternion.identity;
		}
		GeneratePools();
	}

	private void GeneratePools()
	{
		foreach (TrainCarType_v2 carType in Globals.G.Types.carTypes)
		{
			if (!(carType.audioPrefab == null))
			{
				carTypeToAudioPool.Add(carType, new List<TrainAudio>());
				for (int i = 0; i < carType.audioPoolSize; i++)
				{
					InstantiateAudioPrefabAndAddToPool(carType.audioPrefab, carTypeToAudioPool[carType]);
				}
			}
		}
		for (int j = 0; j < defaultAudioPoolSize; j++)
		{
			InstantiateAudioPrefabAndAddToPool(defaultAudioPrefab, defaultAudioPool);
		}
		foreach (CargoPoolReferences.CargoPoolData poolDatum in cargoPoolReferences.poolData)
		{
			CargoEffectsType cargoEffectsType = poolDatum.cargoEffectsType;
			if (cargoEffectsType != CargoEffectsType.None)
			{
				cargoComponentToCargoComponentPool.Add(cargoEffectsType, new List<CargoComponentData>());
				cargoComponentToPoolData.Add(cargoEffectsType, poolDatum);
				for (int k = 0; k < poolDatum.poolSize; k++)
				{
					InstantiateEffectsAndAddToPool(poolDatum.cargoEffectsPrefab, cargoComponentToCargoComponentPool[cargoEffectsType]);
				}
			}
		}
	}

	public void ReturnCargoComponentToPool(CargoEffectsType cargoEffectsType, CargoComponentData cargoComponentData)
	{
		if (cargoComponentToCargoComponentPool.TryGetValue(cargoEffectsType, out var value))
		{
			value.Add(cargoComponentData);
			cargoComponentData.cargoGO.SetActive(value: false);
			cargoComponentData.cargoGO.transform.SetParent(poolParent.transform);
		}
	}

	private void InstantiateEffectsAndAddToPool(GameObject prefab, List<CargoComponentData> pool)
	{
		CargoComponentData item = InstantiateEffects(prefab);
		item.cargoGO.SetActive(value: false);
		item.cargoGO.transform.SetParent(poolParent.transform);
		pool.Add(item);
	}

	private CargoComponentData InstantiateEffects(GameObject prefab)
	{
		GameObject gameObject = Object.Instantiate(prefab);
		ICargoEffects component = gameObject.GetComponent<ICargoEffects>();
		ICargoLeak component2 = gameObject.GetComponent<ICargoLeak>();
		ICargoReaction component3 = gameObject.GetComponent<ICargoReaction>();
		return new CargoComponentData(gameObject, component, component2, component3);
	}

	public CargoComponentData RequestEffectsFromPool(CargoEffectsType effectsType, ICargoContent cargoContent)
	{
		return GetEffectsFromPool(effectsType);
	}

	private CargoComponentData GetEffectsFromPool(CargoEffectsType effectsType)
	{
		if (cargoComponentToCargoComponentPool.TryGetValue(effectsType, out var value))
		{
			CargoComponentData result = FetchFromPool(value);
			if (result.cargoGO != null)
			{
				return result;
			}
			if (cargoComponentToPoolData.TryGetValue(effectsType, out var value2))
			{
				return InstantiateEffects(value2.cargoEffectsPrefab);
			}
		}
		return default(CargoComponentData);
	}

	private CargoComponentData FetchFromPool(List<CargoComponentData> pool)
	{
		int num = pool.Count - 1;
		if (num >= 0)
		{
			CargoComponentData result = pool[num];
			pool.RemoveAt(num);
			return result;
		}
		return default(CargoComponentData);
	}

	private void InstantiateAudioPrefabAndAddToPool(GameObject prefab, List<TrainAudio> pool)
	{
		TrainAudio trainAudio = InstantiateTrainAudio(prefab);
		if (!(trainAudio == null))
		{
			ResetAudioTransform(trainAudio.transform);
			trainAudio.gameObject.SetActive(value: false);
			trainAudio.enabled = false;
			pool.Add(trainAudio);
		}
	}

	private TrainAudio InstantiateTrainAudio(GameObject prefab)
	{
		GameObject gameObject = Object.Instantiate(prefab);
		TrainAudio component = gameObject.GetComponent<TrainAudio>();
		if (component == null)
		{
			Debug.LogError("'" + prefab.name + "' doesn't have TrainAudio component required for audio pool. Destroying instance.", prefab);
			Object.Destroy(gameObject);
		}
		return component;
	}

	public TrainAudio RequestTrainAudioFromPool(TrainCar car)
	{
		if (car == null)
		{
			Debug.LogError("Cannot give audio to null car. Returning null.", this);
			return null;
		}
		TrainAudio trainAudioObject = GetTrainAudioObject(car);
		if (trainAudioObject != null)
		{
			trainAudioObject.SetupForCar(car);
		}
		return trainAudioObject;
	}

	private TrainAudio GetDefaultAudioFromPool()
	{
		TrainAudio trainAudio = FetchFromPool(defaultAudioPool);
		if (trainAudio == null)
		{
			trainAudio = InstantiateTrainAudio(defaultAudioPrefab);
		}
		return trainAudio;
	}

	private TrainAudio GetTrainAudioObject(TrainCar car)
	{
		TrainCarType_v2 parentType = car.carLivery.parentType;
		if (carTypeToAudioPool.TryGetValue(parentType, out var value))
		{
			TrainAudio trainAudio = FetchFromPool(value);
			if (trainAudio != null)
			{
				return trainAudio;
			}
			return InstantiateTrainAudio(parentType.audioPrefab);
		}
		return GetDefaultAudioFromPool();
	}

	private TrainAudio FetchFromPool(List<TrainAudio> pool)
	{
		TrainAudio result = null;
		if (pool.Count > 0)
		{
			for (int num = pool.Count - 1; num >= 0; num--)
			{
				if (pool[num] != null)
				{
					result = pool[num];
					pool.RemoveAt(num);
					break;
				}
				Debug.LogWarning("Audio pool contains null item. Cleaning up.", this);
				pool.RemoveAt(num);
			}
		}
		return result;
	}

	public void ReturnAudioToPool(TrainCar car, TrainAudio trainAudio)
	{
		if (trainAudio == null)
		{
			Debug.LogError("Trying to return null object to audio pool. Aborting.", this);
			return;
		}
		TrainCarType_v2 parentType = car.carLivery.parentType;
		if (carTypeToAudioPool.TryGetValue(parentType, out var value))
		{
			value.Add(trainAudio);
		}
		else
		{
			defaultAudioPool.Add(trainAudio);
		}
		ResetAudioTransform(trainAudio.transform);
		trainAudio.gameObject.SetActive(value: false);
		trainAudio.enabled = false;
	}

	private void ResetAudioTransform(Transform audioTransform)
	{
		audioTransform.parent = poolParent.transform;
		audioTransform.localPosition = Vector3.zero;
		audioTransform.localRotation = Quaternion.identity;
	}
}
