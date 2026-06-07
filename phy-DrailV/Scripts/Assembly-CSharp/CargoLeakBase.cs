using System;
using DV.Damage;
using DV.ThingTypes;
using UnityEngine;

public abstract class CargoLeakBase : MonoBehaviour, ICargoLeak
{
	private ICargoContent cargoContent;

	private ICargoEffects cargoEffects;

	protected CargoLeakProperties cargoLeakProperties;

	protected Vector3 leakColliderSize;

	protected Vector3 leakColliderCenter;

	protected float maxLeakColliderSize;

	protected float cargoMassLeaked;

	protected float previousMassLeaked;

	protected float cargoVolumeLeaked;

	protected float inverseDensity;

	protected float maxLeakFlow;

	protected float minLeakFlow;

	protected float ruptureArea;

	protected float vaporRadius;

	protected float leakFlow;

	protected bool isLeaking;

	protected bool isRuptured;

	protected const float VOLUME_CONSTANT = 4.1887903f;

	protected const float MIN_CURVE_VALUE = 0.1f;

	protected const float MIN_RUPTURE_SIZE = 0.2f;

	protected const string LEAK_COLLIDER_GO_NAME = "HazmatLeakColliders";

	private CargoType cargoType;

	protected BoxCollider leakCollider;

	private AnimationCurve massToLeakCurve;

	private CargoDamageModel cargoDamage;

	private TrainCar trainCar;

	private float inverseCargoMassFull;

	public bool HasGasBuildup { get; protected set; }

	private float CargoLostMassPercentage => GetCargoLostMassPercentage();

	private event Action _ruptured;

	event Action ICargoLeak.Ruptured
	{
		add
		{
			_ruptured += value;
		}
		remove
		{
			_ruptured -= value;
		}
	}

	protected abstract void SetupLeakColliders(GameObject colliderParentGO);

	protected abstract void ResetLeakColliders();

	protected abstract void ManageColliders();

	protected abstract void CalculateLeakedMass();

	private void Awake()
	{
		cargoEffects = GetComponent<ICargoEffects>();
		GameObject gameObject = new GameObject("HazmatLeakColliders");
		gameObject.transform.SetParent(base.transform);
		gameObject.layer = LayerMask.NameToLayer("Hazmat");
		SetupLeakColliders(gameObject);
	}

	protected virtual void InitializeCargoSpecificValues(CargoType cargoType)
	{
		this.cargoType = cargoType;
		ResetLeakColliders();
		if (!TrainCarAndCargoDamageProperties.CargoLeakProperties.TryGetValue(cargoType, out cargoLeakProperties))
		{
			cargoLeakProperties = TrainCarAndCargoDamageProperties.StandardLeakProperties;
		}
		inverseCargoMassFull = 1f / cargoContent.GetMaxCargo();
		inverseDensity = cargoLeakProperties.inverseDensity;
		maxLeakFlow = cargoLeakProperties.maxLeakFlow;
		minLeakFlow = cargoLeakProperties.minLeakFlow;
		massToLeakCurve = HazmatCurvesReferences.HazmatCurveInfos.GetLeakAndReactionCurves(cargoType).leakCurve?.curve;
		base.enabled = massToLeakCurve != null;
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (!(cargoDamage == null))
		{
			if (on)
			{
				cargoDamage.CargoDamaged += OnCargoDamaged;
				trainCar.CargoLoaded += InitializeCargoSpecificValues;
				cargoContent.AboutToReturnToPool += ResetAndDisable;
			}
			else
			{
				cargoDamage.CargoDamaged -= OnCargoDamaged;
				trainCar.CargoLoaded -= InitializeCargoSpecificValues;
				cargoContent.AboutToReturnToPool -= ResetAndDisable;
			}
		}
	}

	private void OnCargoDamaged(float remainingIntegrity)
	{
		float num = Mathf.Clamp01(1f - remainingIntegrity);
		if (!(num <= float.Epsilon))
		{
			ruptureArea = Mathf.Max(0.2f, num * num);
			if (!isRuptured)
			{
				Rupture();
			}
		}
	}

	private void Rupture()
	{
		isRuptured = true;
		this._ruptured?.Invoke();
		cargoEffects.ActivateEffectsExternally(playRuptureSound: true);
		cargoEffects.ToggleRuptureVisibility(on: true);
	}

	protected virtual void Update()
	{
		UpdateLeak();
		ManageColliders();
	}

	private void UpdateLeak()
	{
		if (isRuptured && (!cargoContent.IsEmpty() || isLeaking))
		{
			isLeaking = true;
			float num = Mathf.Clamp(massToLeakCurve.Evaluate(CargoLostMassPercentage), 0.1f, 1f);
			leakFlow = Mathf.Max(ruptureArea * maxLeakFlow * num, minLeakFlow);
			cargoContent.ReduceCargo(leakFlow * Time.deltaTime);
			if (cargoContent.IsEmpty())
			{
				isLeaking = false;
				leakFlow = 0f;
				cargoEffects.UpdateEffectsFlowOut(0f);
			}
			else
			{
				cargoEffects.UpdateEffectsFlowOut(leakFlow / maxLeakFlow);
			}
			CalculateLeakedMass();
		}
	}

	private float GetCargoLostMassPercentage()
	{
		return 1f - cargoContent.GetCurrentCargo() * inverseCargoMassFull;
	}

	public virtual void ResetAndDisable()
	{
		base.enabled = false;
		isLeaking = false;
		isRuptured = false;
		cargoMassLeaked = 0f;
		previousMassLeaked = 0f;
		cargoVolumeLeaked = 0f;
		ruptureArea = 0f;
		vaporRadius = 0f;
		leakFlow = 0f;
		cargoEffects.UpdateEffectsFlowOut(0f);
		SetupListeners(on: false);
		cargoContent = null;
	}

	CargoType ICargoLeak.GetCargoType()
	{
		return cargoType;
	}

	float ICargoLeak.LeakDelta()
	{
		float a = cargoMassLeaked - previousMassLeaked;
		previousMassLeaked = cargoMassLeaked;
		return Mathf.Max(a, 0f);
	}

	float ICargoLeak.VaporRadius()
	{
		return vaporRadius;
	}

	float ICargoLeak.CargoVolumeLeaked()
	{
		return cargoVolumeLeaked;
	}

	float ICargoLeak.RuptureArea()
	{
		return ruptureArea;
	}

	bool ICargoLeak.IsLeaking()
	{
		return isLeaking;
	}

	bool ICargoLeak.HasLeakedCargo()
	{
		return cargoMassLeaked > 0f;
	}

	Vector3 ICargoLeak.Position()
	{
		return base.transform.position;
	}

	void ICargoLeak.OnCargoExploded()
	{
		ResetAndDisable();
	}

	void ICargoLeak.ReduceLeakedMass(float amount)
	{
		cargoMassLeaked -= amount;
		if (cargoMassLeaked < 0f)
		{
			cargoMassLeaked = 0f;
		}
	}

	float ICargoLeak.CargoMassLeaked()
	{
		return cargoMassLeaked;
	}

	float ICargoLeak.LeakFlow()
	{
		return leakFlow;
	}

	void ICargoLeak.SetupForContent(ICargoContent cargoContent)
	{
		this.cargoContent = cargoContent;
		trainCar = cargoContent.Car();
		cargoType = cargoContent.GetCargoType();
		cargoDamage = trainCar.CargoDamage;
		InitializeCargoSpecificValues(cargoType);
		SetupListeners(on: true);
		base.enabled = true;
	}
}
