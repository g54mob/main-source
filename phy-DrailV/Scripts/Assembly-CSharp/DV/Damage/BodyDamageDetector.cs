using System;

namespace DV.Damage
{
	public class BodyDamageDetector
	{
		private float damagedHealthThreshold;

		private CarDamageModel bodyDamage;

		public bool IsDamaged { get; private set; }

		public event Action<bool> DamagedStateChanged;

		public BodyDamageDetector(float damageThreshold, DamageController damageController)
		{
			damagedHealthThreshold = (1f - damageThreshold) * 100f;
			bodyDamage = damageController.bodyDamage;
			OnBodyHealthUpdate(bodyDamage.EffectiveHealthPercentage100Notation);
			bodyDamage.CarEffectiveHealthStateUpdate += OnBodyHealthUpdate;
		}

		public void OnDestroy()
		{
			if (bodyDamage != null)
			{
				bodyDamage.CarEffectiveHealthStateUpdate -= OnBodyHealthUpdate;
			}
		}

		private void OnBodyHealthUpdate(float healthPercentage100Notation)
		{
			bool flag = healthPercentage100Notation < damagedHealthThreshold;
			if (IsDamaged != flag)
			{
				IsDamaged = flag;
				this.DamagedStateChanged?.Invoke(IsDamaged);
			}
		}
	}
}
