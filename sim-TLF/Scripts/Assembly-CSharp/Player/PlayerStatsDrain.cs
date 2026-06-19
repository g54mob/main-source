using Player.Stats;
using Services.Health;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerStatsDrain : MonoBehaviour
	{
		[SerializeField]
		private float _statsDrainage;

		[SerializeField]
		private FirstPersonController _fpsController;

		[SerializeField]
		private PlayerViewZoomer _playerViewZoomer;

		[SerializeField]
		private float _damageInterval;

		[SerializeField]
		private float _damageValue;

		private float _damageTimer;

		[Inject(Id = "Player")]
		private IHealthService _playerHealthService;

		[Inject]
		private IPlayerStatsService _playerStatsService;

		[Inject]
		private PlayerSmokeVolume _playerSmokeVolume;

		[Inject]
		private PlayerDrinkVolume _playerDrinkVolume;

		public float StatsDrainage
		{
			get
			{
				return _statsDrainage;
			}
			set
			{
				_statsDrainage = value;
			}
		}

		private void Update()
		{
			DrainAlcoholStat();
			DrainNicotineStat();
		}

		private void DrainNicotineStat()
		{
			if (_playerStatsService.NicotineStat <= 0f)
			{
				DamageInterval();
			}
			_playerStatsService.AddModToNicotine(_statsDrainage * Time.deltaTime);
			if (_playerStatsService.NicotineStat <= 20f)
			{
				EnableSprint(sprintEnabled: false);
				_playerSmokeVolume.SetWeight(1f - _playerStatsService.NicotineStat / 20f);
			}
			else if (_playerStatsService.NicotineStat >= 60f)
			{
				EnableSprint(sprintEnabled: true);
				_playerSmokeVolume.SetWeight(0f);
			}
			else
			{
				EnableSprint(sprintEnabled: true);
				_playerSmokeVolume.SetWeight(0f);
			}
		}

		private void DamageInterval()
		{
			_damageTimer += Time.deltaTime;
			if (_damageTimer >= _damageInterval)
			{
				_damageTimer = 0f;
				_playerHealthService.Damage(_damageValue);
			}
		}

		private void DrainAlcoholStat()
		{
			if (_playerStatsService.AlcoholStat <= 0f)
			{
				DamageInterval();
			}
			_playerStatsService.AddModToAlcohol(_statsDrainage * Time.deltaTime);
			if (_playerStatsService.AlcoholStat <= 20f)
			{
				EnableZoom(zoomEnabled: false);
				_playerDrinkVolume.SetWeight(1f - _playerStatsService.AlcoholStat / 20f);
			}
			else if (_playerStatsService.AlcoholStat >= 60f)
			{
				EnableZoom(zoomEnabled: true);
				_playerDrinkVolume.SetWeight(0f);
			}
			else
			{
				EnableZoom(zoomEnabled: true);
				_playerDrinkVolume.SetWeight(0f);
			}
		}

		private void EnableSprint(bool sprintEnabled)
		{
			_fpsController.CanSprint = sprintEnabled;
		}

		private void EnableZoom(bool zoomEnabled)
		{
			_playerViewZoomer.CanZoom = zoomEnabled;
		}
	}
}
