using System.Collections;
using DV.Damage;
using DV.Hazmat;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public abstract class CargoReactionBase : MonoBehaviour, ICargoReaction
{
	public const float EXPLOSION_SPILL_AMOUNT = 1000f;

	public const float EXPLOSION_FORCE = 10000000f;

	public const float EXPLOSION_OFFSET_Y = -1f;

	public const float EXPLOSION_DERAIL_THRESHOLD = 100f;

	public const float OTHER_IGNITION_DELAY_MIN = 0.25f;

	public const float OTHER_IGNITION_DELAY_MAX = 2f;

	public const float BASE_CHAIN_EXPLOSION_CHANCE = 0.8f;

	public AudioClip ignitionSound;

	public AudioClip extinguishSound;

	public AudioClip[] explosionAnticipationSounds;

	public AnimationCurveAsset reactionCurveAsset;

	protected AudioSource explosionAnticipationAudioSource;

	protected CargoDamageModel cargoDamageModel;

	protected TrainCar trainCar;

	protected ICargoContent cargoContent;

	protected ICargoEffects cargoEffects;

	protected ICargoLeak cargoLeak;

	protected LayerMask hazmask;

	protected const float EXPLOSION_RADIUS = 25f;

	protected const float EXPLOSION_BASE_DELAY = 1f;

	protected const float EXPLOSION_DELAY_RNG_FACTOR = 0.4f;

	protected const float EXPLOSION_MIN_MASS_THRESHOLD = 100f;

	protected const float EXPLOSTION_RANDOM_MIN_THRESHOLD_BURN_TIME = 2f;

	protected const float EXPLOSTION_RANDOM_MAX_THRESHOLD_BURN_TIME = 8f;

	protected const float TERRAIN_CHECK_TIME = 1f;

	protected const float FLAME_RANGE = 22.4f;

	protected const float CARGO_BURN_SPEED = 500f;

	protected const float EXTINGUISH_CHANCE = 1f;

	public const float TILE_IGNITION_CHANCE = 0.5f;

	private const float ignitionSphereRadius = 25f;

	protected float explosionThresholdTime;

	protected float elapsedBurnTime;

	protected CargoReactionProperties cargoReactionProperties;

	protected bool isFlammable;

	protected bool canExtinguish;

	protected bool isOxidizer;

	protected bool isExplosive;

	protected bool isIgnited;

	protected bool isExploded;

	protected bool aboutToExplode;

	protected bool extinguished;

	protected bool initialized;

	protected float currentReactivity;

	protected float currentEnergy;

	protected float explosionDelay;

	protected float explosionTimer;

	protected float elapsedTerrainCheckTime;

	protected float elapsedTileIgnitionTime;

	private Coroutine delayedExplosionBehaviourCoro;

	[Range(0f, 100f)]
	public int doubleExplosionDelayChance = 20;

	private const int SOLID_IGNITION_THRESHOLD = 100;

	protected float ignitionStrength;

	protected abstract void ManageReaction();

	protected abstract void CheckTerrainForIgnition();

	protected abstract void PostExplosionBehavior();

	private void Awake()
	{
		cargoLeak = GetComponent<ICargoLeak>();
		cargoEffects = GetComponent<ICargoEffects>();
		hazmask = LayerMask.GetMask("Hazmat");
	}

	public virtual void SetupForContent(ICargoContent cargoContent)
	{
		this.cargoContent = cargoContent;
		cargoContent.AboutToReturnToPool += OnAboutToReturnToPool;
		trainCar = cargoContent.Car();
		cargoDamageModel = trainCar.CargoDamage;
		InitializeCargoSpecificValues(cargoContent.GetCargoType());
		cargoDamageModel.CargoSeverelyDamaged += OnCargoSeverelyDamaged;
		explosionThresholdTime = Random.Range(2f, 8f);
		elapsedBurnTime = 0f;
		base.enabled = true;
	}

	protected virtual void InitializeCargoSpecificValues(CargoType cargoType)
	{
		if (!TrainCarAndCargoDamageProperties.CargoReactionProperties.TryGetValue(cargoType, out cargoReactionProperties))
		{
			cargoReactionProperties = TrainCarAndCargoDamageProperties.StandardReactionProperties;
		}
		isFlammable = TrainCarAndCargoDamageProperties.IsCargoFlammable(cargoType);
		canExtinguish = !isFlammable && TrainCarAndCargoDamageProperties.IsCargoExtinguishingGas(cargoType);
		isOxidizer = !isFlammable && !canExtinguish && TrainCarAndCargoDamageProperties.IsCargoOxidizer(cargoType);
		isExplosive = TrainCarAndCargoDamageProperties.IsCargoExplosive(cargoType);
		reactionCurveAsset = HazmatCurvesReferences.HazmatCurveInfos.GetLeakAndReactionCurves(cargoType).reactionCurve;
		explosionDelay = 1f + Random.Range(0.6f * cargoReactionProperties.explosionDelay, 1.4f * cargoReactionProperties.explosionDelay);
		if (Random.Range(0, 100) >= 100 - doubleExplosionDelayChance)
		{
			explosionDelay *= 2f;
		}
		initialized = true;
	}

	protected virtual void OnCargoSeverelyDamaged()
	{
	}

	private void Update()
	{
		if (initialized)
		{
			ManageReaction();
			ManagePotentialExplosion();
		}
	}

	private void ManagePotentialExplosion()
	{
		if (aboutToExplode && isExplosive)
		{
			if (explosionAnticipationAudioSource == null && explosionAnticipationSounds != null && explosionAnticipationSounds.Length != 0)
			{
				explosionAnticipationSounds.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			if (explosionTimer < explosionDelay)
			{
				explosionTimer += Time.deltaTime;
			}
			else
			{
				ExplodeCargo();
			}
		}
	}

	public virtual void ExplodeCargo()
	{
		isExploded = true;
		aboutToExplode = false;
		explosionTimer = 0f;
		elapsedBurnTime = 0f;
		if (explosionAnticipationAudioSource != null)
		{
			explosionAnticipationAudioSource.Stop();
			explosionAnticipationAudioSource = null;
		}
		TrainCarExplosion.CreateExplosion(10000000f, base.transform.position, 25f, -1f, 100f);
		TrainCarExplosion.UpdateModelToExploded(trainCar);
		cargoEffects.OnCargoExploded();
		cargoContent.OnCargoExploded();
		cargoLeak?.OnCargoExploded();
		if ((bool)SingletonBehaviour<HazmatTileManager>.Instance && SingletonBehaviour<HazmatTileManager>.Instance.enabled)
		{
			SingletonBehaviour<HazmatTileManager>.Instance.AddExplosionSource(base.transform);
		}
		float delay = Random.Range(0.25f, 2f);
		if (delayedExplosionBehaviourCoro != null)
		{
			Debug.LogError("delayedExplosionBehaviourCoro is already running!");
		}
		else
		{
			delayedExplosionBehaviourCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedExplosionBehavior(delay));
		}
		ResetReactionValues();
	}

	private IEnumerator DelayedExplosionBehavior(float delay)
	{
		yield return WaitFor.Seconds(delay);
		PostExplosionBehavior();
		TryIgniteOrExplodeSurroundings();
		delayedExplosionBehaviourCoro = null;
	}

	protected void ResetReactionValues()
	{
		explosionTimer = 0f;
		elapsedTerrainCheckTime = 0f;
		elapsedTileIgnitionTime = 0f;
		currentEnergy = 0f;
		currentReactivity = 0f;
		initialized = false;
		aboutToExplode = false;
		isIgnited = false;
		isExploded = false;
		isFlammable = false;
		canExtinguish = false;
		extinguished = false;
		isOxidizer = false;
		isExplosive = false;
	}

	protected virtual void OnAboutToReturnToPool()
	{
		cargoDamageModel.CargoSeverelyDamaged -= OnCargoSeverelyDamaged;
		cargoContent.AboutToReturnToPool -= OnAboutToReturnToPool;
		ResetReactionValues();
		if (delayedExplosionBehaviourCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedExplosionBehaviourCoro);
			delayedExplosionBehaviourCoro = null;
		}
		cargoContent = null;
		base.enabled = false;
	}

	bool ICargoReaction.IsFlammable()
	{
		return isFlammable;
	}

	bool ICargoReaction.CanExtinguish()
	{
		return canExtinguish;
	}

	bool ICargoReaction.IsOxidizer()
	{
		return isOxidizer;
	}

	bool ICargoReaction.IsExplosive()
	{
		return isExplosive;
	}

	bool ICargoReaction.IsIgnited()
	{
		return isIgnited;
	}

	CargoPhase ICargoReaction.GetCargoPhase()
	{
		return cargoContent.GetCargoPhase();
	}

	float ICargoReaction.ReactivityModifier()
	{
		return cargoReactionProperties.reactivityModifierToOthers;
	}

	float ICargoReaction.RequestRuptureArea()
	{
		return cargoLeak.RuptureArea();
	}

	void ICargoReaction.TryExplodeExternally()
	{
		if (isExplosive && !isExploded && !aboutToExplode)
		{
			aboutToExplode = true;
			if (isFlammable && !isIgnited)
			{
				isIgnited = true;
			}
			Debug.Log($"Explosion imminent in car {trainCar.transform.name} with cargo {cargoDamageModel.cargoType}. External call.");
		}
	}

	void ICargoReaction.TryExtinguishExternally()
	{
		if (isFlammable && isIgnited && !aboutToExplode)
		{
			extinguished = 1f > (float)Random.Range(0, 100);
		}
	}

	bool ICargoReaction.TryIgniteExternally(float ignitionStrength)
	{
		if (!isFlammable || isIgnited)
		{
			return false;
		}
		if (cargoContent.GetCargoPhase() == CargoPhase.Solid && ignitionStrength >= 100f)
		{
			isIgnited = true;
			PlayIgnitionSound(base.transform.position);
		}
		else if (cargoLeak.IsLeaking())
		{
			isIgnited = true;
			PlayIgnitionSound(cargoLeak.Position());
		}
		return isIgnited;
	}

	protected void TryIgniteOrExplodeSurroundings()
	{
		Igniter.Ignite(base.transform.position, ignitionStrength, 25f, null, 0f, 0.8f);
		Igniter.IgniteTerrainDiamond(base.transform.position, ignitionStrength, 25f, 25f, 0.5f);
	}

	public void PlayIgnitionSound(Vector3 pos)
	{
		if (ignitionSound != null)
		{
			ignitionSound.Play(pos, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	protected void PlayExtinguishSound()
	{
		if (extinguishSound != null)
		{
			extinguishSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	public void IgniteIgnitable(IIgnitable ignitable, float ignitionStrength)
	{
	}
}
