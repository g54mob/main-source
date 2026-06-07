using DV;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class CargoModelController : MonoBehaviour
{
	public byte? currentCargoModelIndex;

	private GameObject currentCargoModel;

	private TrainCar trainCar;

	private TrainCarColliders trainColliders;

	public void InitializeCargoModelController(TrainCar trainCar, TrainCarColliders trainColliders)
	{
		this.trainCar = trainCar;
		this.trainColliders = trainColliders;
		if (trainColliders == null)
		{
			Debug.LogError("CargoModelController got a missing reference to TrainCarColliders");
		}
		SetupListeners(set: true);
	}

	private void SetupListeners(bool set)
	{
		if (set)
		{
			trainCar.CargoLoaded += OnCargoLoaded;
			trainCar.CargoUnloaded += OnCargoUnloaded;
		}
		else
		{
			trainCar.CargoLoaded -= OnCargoLoaded;
			trainCar.CargoUnloaded -= OnCargoUnloaded;
		}
	}

	private void OnCargoLoaded(CargoType _)
	{
		if (SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload != null && trainCar.IsCargoLoadedUnloadedByMachine)
		{
			SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload.Play(trainCar.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, trainCar.transform);
		}
		if (currentCargoModel != null)
		{
			Debug.LogWarning("This shouldn't happen, cargo already instantiated, but new cargo is loaded, deleting currentCargoModel: " + currentCargoModel.name, this);
			DestroyCurrentCargoModel();
		}
		TrainCarType_v2 parentType = trainCar.carLivery.parentType;
		GameObject[] cargoPrefabsForCarType = trainCar.LoadedCargo.ToV2().GetCargoPrefabsForCarType(parentType);
		if (cargoPrefabsForCarType != null && cargoPrefabsForCarType.Length != 0)
		{
			if (!currentCargoModelIndex.HasValue)
			{
				currentCargoModelIndex = (byte)Random.Range(0, cargoPrefabsForCarType.Length);
			}
			GameObject original = cargoPrefabsForCarType[Mathf.Min(currentCargoModelIndex.Value, cargoPrefabsForCarType.Length - 1)];
			currentCargoModel = Object.Instantiate(original, trainCar.interior.transform, worldPositionStays: false);
			currentCargoModel.transform.localPosition = Vector3.zero;
			currentCargoModel.transform.localRotation = Quaternion.identity;
			trainColliders.SetupCargo(currentCargoModel);
		}
	}

	private void OnCargoUnloaded()
	{
		if (SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload != null && trainCar.IsCargoLoadedUnloadedByMachine)
		{
			SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload.Play(trainCar.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, trainCar.transform);
		}
		currentCargoModelIndex = null;
		if (currentCargoModel != null)
		{
			DestroyCurrentCargoModel();
			trainColliders.SetupCargo(null);
		}
	}

	private void DestroyCurrentCargoModel()
	{
		Object.Destroy(currentCargoModel);
		currentCargoModel = null;
	}

	public void CargoExplosion()
	{
		if (!(currentCargoModel == null))
		{
			ExplosionModelHandler componentInChildren = currentCargoModel.GetComponentInChildren<ExplosionModelHandler>();
			if (componentInChildren != null)
			{
				componentInChildren.HandleExplosionModelChange();
			}
		}
	}

	public GameObject GetCurrentCargoModel()
	{
		return currentCargoModel;
	}

	public Option<Bounds> GetCurrentCargoModelBounds()
	{
		if (!currentCargoModelIndex.HasValue || !currentCargoModel)
		{
			return Option<Bounds>.None;
		}
		Renderer[] componentsInChildren = currentCargoModel.GetComponentsInChildren<Renderer>();
		if (componentsInChildren.Length == 0)
		{
			return Option<Bounds>.None;
		}
		Bounds bounds = componentsInChildren[0].bounds;
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			bounds.Encapsulate(componentsInChildren[i].bounds);
		}
		return Option<Bounds>.Some(bounds);
	}
}
