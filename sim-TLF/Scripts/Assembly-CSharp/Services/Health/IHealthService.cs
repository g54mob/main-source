using System;

namespace Services.Health
{
	public interface IHealthService
	{
		float MaxHealth { get; }

		float CurrentHealth { get; }

		event Action<float> HealthChanged;

		void SetHealth(float newValue);

		void Heal(float value);

		void Damage(float value);

		float GetHealthPercentage();
	}
}
