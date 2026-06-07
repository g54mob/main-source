using System;
using UnityEngine;

namespace DV.Damage
{
	public class CarDamageModel : MonoBehaviour
	{
		public TrainCar trainCar;

		public DamageState damageState;

		private CarDamageProperties carDamageProperties;

		private bool ignoreDamage;

		public float currentHealth;

		public float maxHealth;

		private float effectiveMaxHealth;

		private GameParams gameParams;

		public float EffectiveHealthPercentage100Notation => EffectiveHealthPercentage * 100f;

		public float HealthPercentage => Mathf.Clamp01(currentHealth / maxHealth);

		public float EffectiveHealthPercentage => Mathf.Clamp01(currentHealth / effectiveMaxHealth);

		public float DamagePercentage => 1f - EffectiveHealthPercentage;

		public event Action<float> CarEffectiveHealthStateUpdate;

		public void OnCreated(TrainCar car)
		{
			trainCar = car;
			if (!TrainCarAndCargoDamageProperties.carDamageProperties.TryGetValue(trainCar.carType, out carDamageProperties))
			{
				carDamageProperties = TrainCarAndCargoDamageProperties.StandardCarDamageProperties;
			}
			maxHealth = (currentHealth = carDamageProperties.maxHealth);
			effectiveMaxHealth = maxHealth * (1f - carDamageProperties.damageTolerance);
			damageState = DamageState.WithinSafeLimits;
			if (carDamageProperties.ignoreDamage)
			{
				IgnoreDamage(set: true);
			}
			if (trainCar.TrainCarCollisions == null || trainCar.TileInteraction == null || trainCar.stress == null)
			{
				Debug.LogError("Not all required scripts are present on car " + trainCar.name + ". Disabling CarDamageModel.", this);
				base.enabled = false;
			}
			else
			{
				gameParams = Globals.G.GameParams;
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (!(trainCar == null))
			{
				if (on)
				{
					TrainCarCollisions trainCarCollisions = trainCar.TrainCarCollisions;
					trainCarCollisions.CarDamaged = (Action<float, Vector3>)Delegate.Combine(trainCarCollisions.CarDamaged, new Action<float, Vector3>(OnCarDamaged));
					trainCar.stress.StressDamage += OnCarDamaged;
					trainCar.TileInteraction.CarBurning += OnCarBurning;
				}
				else
				{
					TrainCarCollisions trainCarCollisions2 = trainCar.TrainCarCollisions;
					trainCarCollisions2.CarDamaged = (Action<float, Vector3>)Delegate.Remove(trainCarCollisions2.CarDamaged, new Action<float, Vector3>(OnCarDamaged));
					trainCar.stress.StressDamage -= OnCarDamaged;
					trainCar.TileInteraction.CarBurning -= OnCarBurning;
				}
			}
		}

		private void OnCarBurning(float timeInFire)
		{
			DamageCar(GetModifiedFireDamage(timeInFire));
		}

		private void OnCarDamaged(float damage, Vector3 _)
		{
			DamageCar(GetModifiedCollisionDamage(damage));
		}

		public void DamageCar(float damage, bool useSensitivityModifier = true)
		{
			if (useSensitivityModifier)
			{
				damage *= gameParams.DamageSensitivityModifier;
			}
			if (!ignoreDamage && !(damage <= 0f) && currentHealth > float.Epsilon)
			{
				SetHealth(currentHealth - damage);
			}
		}

		private void UpdateDamageState()
		{
			if (damageState != DamageState.Destroyed && currentHealth <= float.Epsilon)
			{
				damageState = DamageState.Destroyed;
			}
			else if (damageState != DamageState.Damaged && currentHealth < effectiveMaxHealth)
			{
				damageState = DamageState.Damaged;
			}
			else if (damageState != DamageState.WithinSafeLimits && currentHealth >= effectiveMaxHealth)
			{
				damageState = DamageState.WithinSafeLimits;
			}
			trainCar.TileInteraction.canDamageCar = damageState != DamageState.Destroyed;
		}

		public void RepairCar(float repairAmount)
		{
			if (repairAmount > 0f)
			{
				SetHealth(currentHealth + repairAmount);
			}
		}

		public void SetHealth(float health)
		{
			currentHealth = Mathf.Clamp(health, 0f, maxHealth);
			UpdateDamageState();
			this.CarEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
		}

		public void RepairCarEffectivePercentage(float repairPercentage)
		{
			if (repairPercentage > 0f)
			{
				float num = repairPercentage * effectiveMaxHealth;
				float num2 = currentHealth + num;
				if (num2 >= effectiveMaxHealth && num2 < maxHealth)
				{
					num = maxHealth - currentHealth;
				}
				RepairCar(num);
			}
		}

		public void IgnoreDamage(bool set)
		{
			ignoreDamage = set;
		}

		public float GetModifiedCollisionDamage(float inflictedDamage)
		{
			float num = inflictedDamage * carDamageProperties.damageMultiplier - carDamageProperties.damageResistance;
			if (!(num > 0f))
			{
				return 0f;
			}
			return num;
		}

		public float GetModifiedFireDamage(float timeInFire)
		{
			float num = 82.5f * timeInFire * carDamageProperties.fireDamageMultiplier - carDamageProperties.fireResistance * timeInFire;
			if (!(num > 0f))
			{
				return 0f;
			}
			return num;
		}

		public void LoadCarDamageState(float healthPercentage)
		{
			if (healthPercentage < 0f || healthPercentage > 1f)
			{
				Debug.LogError("Loaded healthPercentage is out of bounds, clamping to 0-1");
				healthPercentage = Mathf.Clamp01(healthPercentage);
			}
			currentHealth = healthPercentage * maxHealth;
			UpdateDamageState();
			this.CarEffectiveHealthStateUpdate?.Invoke(EffectiveHealthPercentage100Notation);
		}
	}
}
