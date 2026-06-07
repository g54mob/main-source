using UnityEngine;

namespace DV.Damage
{
	public class TrainDamage
	{
		public delegate void HealthChanged(float healthPercentage100Notation);

		public readonly float fullHitPoints;

		private float _currentHitPoints;

		private bool ignoreDamage;

		public float CurrentHitPoints
		{
			get
			{
				return _currentHitPoints;
			}
			private set
			{
				_currentHitPoints = value;
				this.HealthPercentageChanged?.Invoke(HealthPercentage100Notation);
			}
		}

		public float HealthPercentage100Notation => HealthPercentage * 100f;

		public float HealthPercentage => CurrentHitPoints / fullHitPoints;

		public float DamagePercentage => 1f - HealthPercentage;

		public event HealthChanged HealthPercentageChanged;

		public TrainDamage(float fullHitPoints)
		{
			this.fullHitPoints = fullHitPoints;
			CurrentHitPoints = fullHitPoints;
		}

		public void SetCurrentHealthPercentage(float healthPercentage)
		{
			if (healthPercentage < 0f || healthPercentage > 1f)
			{
				Debug.LogError("Loaded healthPercentage is out of bounds, clamping to 0-1");
				healthPercentage = Mathf.Clamp01(healthPercentage);
			}
			CurrentHitPoints = healthPercentage * fullHitPoints;
		}

		public void ApplyDamage(float damageAmount)
		{
			if (!ignoreDamage && damageAmount > 0f)
			{
				CurrentHitPoints = Mathf.Clamp(CurrentHitPoints - damageAmount, 0f, fullHitPoints);
			}
		}

		public void RepairDamage(float repairAmount)
		{
			if (repairAmount > 0f)
			{
				CurrentHitPoints = Mathf.Clamp(CurrentHitPoints + repairAmount, 0f, fullHitPoints);
			}
		}

		public void RepairDamagePercentage(float repairPercentage)
		{
			if (repairPercentage > 0f)
			{
				float repairAmount = repairPercentage * fullHitPoints;
				RepairDamage(repairAmount);
			}
		}

		public void IgnoreDamage(bool set)
		{
			ignoreDamage = set;
		}
	}
}
