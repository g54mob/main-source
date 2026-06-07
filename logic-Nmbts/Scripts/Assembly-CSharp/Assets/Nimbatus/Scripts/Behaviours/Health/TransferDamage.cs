using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class TransferDamage : SerializedMonoBehaviour
	{
		public HealthPool HealthPool;

		public void Heal(float healAmount)
		{
			HealthPool.Heal(healAmount);
		}

		public void ChangeTemperatureBy(float amount)
		{
			HealthPool.ChangeTemperatureBy(amount);
		}

		public void SetNeighbourTemperature(float neighbourTemp)
		{
			HealthPool.SetNeighbourTemperature(neighbourTemp);
		}

		public void TakeDamage(DamageInformation damage)
		{
			HealthPool.TakeDamage(damage);
		}
	}
}
