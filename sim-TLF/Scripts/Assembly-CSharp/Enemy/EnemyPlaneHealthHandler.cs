using Entities;
using Services.Health;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyPlaneHealthHandler : MonoBehaviour, IHealthHandler
	{
		[SerializeField]
		private float _maxHealth;

		[SerializeField]
		private AirplaneController _planeController;

		[SerializeField]
		private AirplaneAI _airplaneAI;

		[SerializeField]
		private ParticleSystem _destroyParticle;

		[SerializeField]
		private GameObject _destroyAudioObject;

		private IHealthService _healthService;

		private bool _isDead;

		[Inject]
		private HealthService.Factory _healthFactory;

		public IHealthService HealthService => _healthService;

		private void Awake()
		{
			_healthService = _healthFactory.Create(_maxHealth);
		}

		private void OnEnable()
		{
			_healthService.HealthChanged += CheckOnHealthChanged;
		}

		private void OnDisable()
		{
			_healthService.HealthChanged -= CheckOnHealthChanged;
		}

		private void CheckOnHealthChanged(float currentHealth)
		{
			if (currentHealth == 0f)
			{
				HandleDeath();
			}
		}

		private void HandleDeath()
		{
			if (!_isDead)
			{
				_isDead = true;
				_planeController.enabled = false;
				_airplaneAI.enabled = false;
				_destroyParticle?.Play();
				_destroyAudioObject.SetActive(value: true);
			}
		}
	}
}
