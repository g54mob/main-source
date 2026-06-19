using Items.Interactions;
using JSAM;
using MyBox;
using Services.Health;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerFallDamageComponent : MonoBehaviour
	{
		[SerializeField]
		[MustBeAssigned]
		private ImpactHandler _impactHandler;

		[Inject(Id = "Player")]
		private IHealthService _playerHealth;

		private void OnEnable()
		{
			_impactHandler.onFallDamage.AddListener(HandleFallDamage);
		}

		private void OnDisable()
		{
			_impactHandler.onFallDamage.RemoveListener(HandleFallDamage);
		}

		private void HandleFallDamage(float fallValue)
		{
			if (fallValue >= _impactHandler.minFallVelocity)
			{
				_playerHealth.Damage(fallValue * _impactHandler.damageMultiplier);
				AudioManager.PlaySound(PlayerLibrarySounds.FallDamage);
			}
		}
	}
}
