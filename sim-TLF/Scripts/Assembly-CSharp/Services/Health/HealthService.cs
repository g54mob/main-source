using System;
using UnityEngine;
using Zenject;

namespace Services.Health
{
	public class HealthService : IHealthService
	{
		public class Factory : PlaceholderFactory<float, HealthService>
		{
		}

		private float _maxHealth;

		private float _currentHealth;

		float IHealthService.MaxHealth => _maxHealth;

		float IHealthService.CurrentHealth => _currentHealth;

		public event Action<float> HealthChanged;

		public HealthService(float maxHealth)
		{
			_maxHealth = maxHealth;
		}

		void IHealthService.Heal(float value)
		{
			_currentHealth = Mathf.Clamp(_currentHealth += value, 0f, _maxHealth);
			this.HealthChanged?.Invoke(_currentHealth);
		}

		void IHealthService.Damage(float value)
		{
			_currentHealth = Mathf.Clamp(_currentHealth -= value, 0f, _maxHealth);
			this.HealthChanged?.Invoke(_currentHealth);
		}

		void IHealthService.SetHealth(float newValue)
		{
			_currentHealth = Mathf.Clamp(newValue, 0f, _maxHealth);
			this.HealthChanged?.Invoke(_currentHealth);
		}

		float IHealthService.GetHealthPercentage()
		{
			return _currentHealth / _maxHealth;
		}
	}
}
