using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnTakeDamage : NimbatusEvent
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		protected override void Subscribe()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			if (HealthPool != null)
			{
				HealthPool.HealthChanged += _healthPool_damageTaken;
			}
		}

		protected override void Unsubscribe()
		{
			if (HealthPool != null)
			{
				HealthPool.HealthChanged -= _healthPool_damageTaken;
			}
		}

		private void _healthPool_damageTaken(float oldHealth, float newHealth)
		{
			if (newHealth < oldHealth)
			{
				RaiseEvent();
			}
		}
	}
}
