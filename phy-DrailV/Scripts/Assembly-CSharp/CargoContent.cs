using System;
using System.Collections;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class CargoContent : MonoBehaviour, ICargoContent
{
	private const float RETURN_TO_POOL_DELAY = 5f;

	private float cargoMassFull;

	private float cargoMassCurrent;

	private float cargoMassMin;

	private TrainCar trainCar;

	private CargoType cargoType;

	private CargoPhase cargoPhase;

	private CargoEffectsType cargoEffectsType;

	private CargoComponentData cargoComponentData;

	private Coroutine delayedReturnToPoolCoro;

	private event Action _aboutToReturnToPool;

	event Action ICargoContent.AboutToReturnToPool
	{
		add
		{
			_aboutToReturnToPool += value;
		}
		remove
		{
			_aboutToReturnToPool -= value;
		}
	}

	public void OnCreated(TrainCar trainCar)
	{
		this.trainCar = trainCar;
		SetupListeners(on: true);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			trainCar.CargoLoaded += OnCargoLoaded;
			trainCar.CargoUnloaded += ReturnToPool;
			trainCar.InteriorAboutToBeDestroyed += ReturnToPool;
		}
		else
		{
			trainCar.CargoLoaded -= OnCargoLoaded;
			trainCar.CargoUnloaded -= ReturnToPool;
			trainCar.InteriorAboutToBeDestroyed -= ReturnToPool;
		}
	}

	private void OnCargoLoaded(CargoType cargoType)
	{
		this.cargoType = cargoType;
		cargoMassFull = (cargoMassCurrent = cargoType.ToV2().massPerUnit);
		CalculateMinCargoMass();
		cargoPhase = TrainCarAndCargoDamageProperties.GetCargoPhase(cargoType);
		cargoEffectsType = TrainCarAndCargoDamageProperties.CargoTypeToEffectsType(cargoType);
		cargoComponentData = SingletonBehaviour<TrainComponentPool>.Instance.RequestEffectsFromPool(TrainCarAndCargoDamageProperties.CargoTypeToEffectsType(cargoType), this);
		if (!(cargoComponentData.cargoGO == null))
		{
			cargoComponentData.cargoGO.transform.SetParent(trainCar.interior);
			cargoComponentData.cargoLeak?.SetupForContent(this);
			cargoComponentData.cargoReaction?.SetupForContent(this);
			cargoComponentData.cargoEffects?.SetupForContent(this);
			cargoComponentData.cargoGO.SetActive(value: true);
		}
	}

	private void ReturnToPool(TrainCar _)
	{
		ReturnToPool();
	}

	private void ReturnToPool()
	{
		if (cargoType != CargoType.None)
		{
			this._aboutToReturnToPool?.Invoke();
			SingletonBehaviour<TrainComponentPool>.Instance.ReturnCargoComponentToPool(cargoEffectsType, cargoComponentData);
			ResetCargoValues();
			if (delayedReturnToPoolCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedReturnToPoolCoro);
				delayedReturnToPoolCoro = null;
			}
		}
	}

	private void ResetCargoValues()
	{
		cargoType = CargoType.None;
		cargoPhase = CargoPhase.None;
		cargoEffectsType = CargoEffectsType.None;
		cargoMassFull = 0f;
		cargoMassCurrent = 0f;
		cargoMassMin = 0f;
		cargoComponentData = default(CargoComponentData);
	}

	private void CalculateMinCargoMass()
	{
		if (cargoPhase != CargoPhase.Liquid)
		{
			cargoMassMin = 0f;
			return;
		}
		AnimationCurveAsset item = HazmatCurvesReferences.HazmatCurveInfos.GetLeakAndReactionCurves(cargoType).leakCurve;
		AnimationCurve animationCurve = ((item != null) ? item.curve : null);
		if (animationCurve == null)
		{
			cargoMassMin = 0f;
			return;
		}
		float num = 1f;
		Keyframe[] keys = animationCurve.keys;
		for (int i = 0; i < keys.Length - 1; i++)
		{
			float time = keys[i].time;
			if (!(animationCurve.Evaluate(time) > 0f))
			{
				num = time;
				break;
			}
		}
		cargoMassMin = (1f - num) * cargoMassFull;
	}

	float ICargoContent.GetCurrentCargo()
	{
		return cargoMassCurrent;
	}

	float ICargoContent.GetMaxCargo()
	{
		return cargoMassFull;
	}

	float ICargoContent.GetMinCargo()
	{
		return cargoMassMin;
	}

	bool ICargoContent.IsEmpty()
	{
		return cargoMassCurrent <= cargoMassMin;
	}

	TrainCar ICargoContent.Car()
	{
		return trainCar;
	}

	void ICargoContent.ReduceCargo(float amount, bool overrideMin)
	{
		if (cargoMassCurrent != 0f)
		{
			cargoMassCurrent = Mathf.Max(cargoMassCurrent -= amount, overrideMin ? 0f : cargoMassMin);
		}
	}

	CargoPhase ICargoContent.GetCargoPhase()
	{
		return cargoPhase;
	}

	CargoType ICargoContent.GetCargoType()
	{
		return cargoType;
	}

	void ICargoContent.OnCargoExploded()
	{
		if (delayedReturnToPoolCoro != null)
		{
			Debug.LogError("delayedReturnToPoolCoro is already running!");
		}
		else
		{
			delayedReturnToPoolCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedReturnToPool());
		}
	}

	private IEnumerator DelayedReturnToPool()
	{
		yield return WaitFor.Seconds(5f);
		ReturnToPool();
		delayedReturnToPoolCoro = null;
	}
}
