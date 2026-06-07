using System;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Damage
{
	public class CargoDamageModel : MonoBehaviour
	{
		private const int SEVERE_DAMAGE_CHANCE = 90;

		private const float SEVERE_DAMAGE_THRESHOLD = 80f;

		public CargoType cargoType;

		public DamageState currentDamageState;

		public float currentHealth;

		private TrainCar trainCar;

		private CargoDamageProperties cargoDamageProperties;

		private bool isFluid;

		private GameParams gameParams;

		public float EffectiveHealthPercentage100Notation => EffectiveHealthPercentage * 100f;

		private float EffectiveHealthPercentage
		{
			get
			{
				if (!IsCargoLoaded)
				{
					return 0f;
				}
				return Mathf.Clamp01(currentHealth / EffectiveMaxHealth);
			}
		}

		private float EffectiveMaxHealth
		{
			get
			{
				if (!IsCargoLoaded)
				{
					return 0f;
				}
				return cargoDamageProperties.maxHealth * (1f - cargoDamageProperties.damageTolerance);
			}
		}

		public float HealthPercentage
		{
			get
			{
				if (!IsCargoLoaded)
				{
					return 0f;
				}
				return Mathf.Clamp01(currentHealth / cargoDamageProperties.maxHealth);
			}
		}

		private float SafeDamagePercentage
		{
			get
			{
				if (!IsCargoLoaded)
				{
					return 1f;
				}
				return 1f - cargoDamageProperties.damageTolerance;
			}
		}

		private bool IsCargoLoaded => cargoType != CargoType.None;

		public event Action<float> CargoDamaged;

		public event Action CargoSeverelyDamaged;

		public event Action<float> CargoEffectiveHealthStateUpdate;

		public event Action CargoDamageLoadedCargo;

		public event Action CargoDamageUnloadedCargo;

		public void OnCreated(TrainCar car)
		{
			trainCar = car;
			if (trainCar.TrainCarCollisions == null || trainCar.TileInteraction == null || trainCar.stress == null)
			{
				Debug.LogError("Not all required scripts are present on car " + trainCar.name + ". Cargo damage model will not respond to events.", this);
				return;
			}
			gameParams = Globals.G.GameParams;
			SetupListeners(on: true);
		}

		private void SetupListeners(bool on)
		{
			if (trainCar == null)
			{
				Debug.LogError("TrainCar not found. CargoDamageModel cannot setup listeners. This should not happen.", this);
				return;
			}
			if (on)
			{
				trainCar.CargoLoaded += OnCargoLoaded;
				trainCar.CargoUnloaded += OnCargoUnloaded;
				return;
			}
			trainCar.CargoLoaded -= OnCargoLoaded;
			trainCar.CargoUnloaded -= OnCargoUnloaded;
			TrainCarCollisions trainCarCollisions = trainCar.TrainCarCollisions;
			trainCarCollisions.CarDamaged = (Action<float, Vector3>)Delegate.Remove(trainCarCollisions.CarDamaged, new Action<float, Vector3>(ApplyNormalDamageToCargo));
			trainCar.TileInteraction.CarBurning -= ApplyFireDamageToCargo;
			trainCar.stress.StressDamage -= ApplyNormalDamageToCargo;
		}

		private void OnCargoUnloaded()
		{
			this.CargoDamageUnloadedCargo?.Invoke();
			TrainCarCollisions trainCarCollisions = trainCar.TrainCarCollisions;
			trainCarCollisions.CarDamaged = (Action<float, Vector3>)Delegate.Remove(trainCarCollisions.CarDamaged, new Action<float, Vector3>(ApplyNormalDamageToCargo));
			trainCar.TileInteraction.CarBurning -= ApplyFireDamageToCargo;
			trainCar.stress.StressDamage -= ApplyNormalDamageToCargo;
			cargoType = CargoType.None;
			currentHealth = 0f;
			this.CargoEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
		}

		private void OnCargoLoaded(CargoType _)
		{
			cargoType = trainCar.LoadedCargo;
			if (IsCargoLoaded)
			{
				if (!TrainCarAndCargoDamageProperties.CargoDamageProperties.TryGetValue(cargoType, out cargoDamageProperties))
				{
					cargoDamageProperties = TrainCarAndCargoDamageProperties.StandardCargoDamageProperties;
				}
				currentHealth = cargoDamageProperties.maxHealth;
				currentDamageState = DamageState.WithinSafeLimits;
				TrainCarCollisions trainCarCollisions = trainCar.TrainCarCollisions;
				trainCarCollisions.CarDamaged = (Action<float, Vector3>)Delegate.Combine(trainCarCollisions.CarDamaged, new Action<float, Vector3>(ApplyNormalDamageToCargo));
				trainCar.stress.StressDamage += ApplyNormalDamageToCargo;
				trainCar.TileInteraction.CarBurning += ApplyFireDamageToCargo;
				this.CargoEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
				trainCar.TileInteraction.canDamageCargo = true;
				isFluid = TrainCarAndCargoDamageProperties.IsCargoLiquid(cargoType) || TrainCarAndCargoDamageProperties.IsCargoGas(cargoType);
				this.CargoDamageLoadedCargo?.Invoke();
			}
		}

		private void ApplyFireDamageToCargo(float timeInFire)
		{
			float damage = 82.5f * timeInFire * cargoDamageProperties.fireDamageMultiplier - cargoDamageProperties.fireResistance * timeInFire;
			ApplyDamageToCargo(damage);
		}

		private void ApplyNormalDamageToCargo(float damageAmount, Vector3 _)
		{
			float damage = damageAmount * cargoDamageProperties.damageMultiplier - cargoDamageProperties.damageResistance;
			ApplyDamageToCargo(damage);
		}

		public void DestroyCargo()
		{
			ApplyDamageToCargo(currentHealth, applySensitivityModifier: false);
		}

		private void ApplyDamageToCargo(float damage, bool applySensitivityModifier = true)
		{
			if (applySensitivityModifier)
			{
				damage *= gameParams.DamageSensitivityModifier;
			}
			if (currentDamageState != DamageState.Destroyed && !(damage <= 0f))
			{
				currentHealth = Mathf.Clamp(currentHealth - damage, 0f, cargoDamageProperties.maxHealth);
				if (isFluid && currentHealth < EffectiveMaxHealth)
				{
					currentHealth = 0f;
				}
				UpdateDamageState();
				this.CargoEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
				if (damage >= 80f && UnityEngine.Random.Range(0, 100) < 90)
				{
					this.CargoSeverelyDamaged?.Invoke();
				}
				float healthPercentage = HealthPercentage;
				float safeDamagePercentage = SafeDamagePercentage;
				float obj = ((healthPercentage < safeDamagePercentage) ? (healthPercentage / safeDamagePercentage) : 1f);
				this.CargoDamaged?.Invoke(obj);
			}
		}

		private void UpdateDamageState()
		{
			if (currentDamageState != DamageState.Destroyed && currentHealth <= float.Epsilon)
			{
				currentDamageState = DamageState.Destroyed;
				trainCar.TileInteraction.canDamageCargo = false;
			}
			else if (currentDamageState != DamageState.Damaged && HealthPercentage < SafeDamagePercentage)
			{
				currentDamageState = DamageState.Damaged;
			}
			else if (currentDamageState != DamageState.WithinSafeLimits && HealthPercentage >= SafeDamagePercentage)
			{
				currentDamageState = DamageState.WithinSafeLimits;
			}
		}

		public void LoadCargoDamageState(float healthPercentage)
		{
			if (healthPercentage < 0f || healthPercentage > 1f)
			{
				Debug.LogError("Loaded healthPercentage is out of bounds, clamping to 0-1");
				healthPercentage = Mathf.Clamp01(healthPercentage);
			}
			if (!IsCargoLoaded && healthPercentage > 0f)
			{
				Debug.LogError("Unexpected state: Cargo is not loaded, but saved healthPercentage is > 0. Something is not right.");
			}
			currentHealth = (IsCargoLoaded ? (healthPercentage * cargoDamageProperties.maxHealth) : 0f);
			UpdateDamageState();
			this.CargoEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
		}
	}
}
