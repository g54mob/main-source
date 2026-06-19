using System;
using Services.Save.Player;
using UnityEngine;
using Zenject;

namespace Services.Enemy
{
	public class LoyaltyService : ILoyaltyService, ITickable
	{
		private readonly float _stressIncrementPerSecond;

		private float _stresAmount;

		private readonly PlayerSaveService _playerSaveService;

		float ILoyaltyService.StressAmmount => _stresAmount;

		public event Action<float> StressValueChanged;

		public LoyaltyService(PlayerSaveService playerSaveService, float minutesUntilAirRaid)
		{
			_playerSaveService = playerSaveService;
			float num = Mathf.Max(1f, minutesUntilAirRaid * 60f);
			_stressIncrementPerSecond = 100f / num;
		}

		void ILoyaltyService.AddStressValue(float value)
		{
			_stresAmount += value;
			_playerSaveService.PlayerData.GameData.EnemyLoyalty = _stresAmount;
			this.StressValueChanged?.Invoke(_stresAmount);
		}

		void ILoyaltyService.RemoveStressValue(float value)
		{
			_stresAmount -= value;
			_playerSaveService.PlayerData.GameData.EnemyLoyalty = _stresAmount;
			this.StressValueChanged?.Invoke(_stresAmount);
		}

		void ILoyaltyService.SetStressValue(float value)
		{
			_stresAmount = value;
			_playerSaveService.PlayerData.GameData.EnemyLoyalty = _stresAmount;
			this.StressValueChanged?.Invoke(_stresAmount);
		}

		void ITickable.Tick()
		{
			((ILoyaltyService)this).AddStressValue(_stressIncrementPerSecond * UnityEngine.Time.deltaTime);
		}
	}
}
