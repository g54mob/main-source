using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	[UsedImplicitly]
	public class PlayerStats : IInitializable, IDisposable
	{
		[Inject]
		private DataManager _dataManager;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private SignalBus _signalBus;

		private int _totalPowerUpCount;

		private readonly Dictionary<PowerUpType, PlayerStat> _stats;

		public double PowerUpMarkUp => 0.0;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void InitStats()
		{
		}

		public float GetRefundAmount()
		{
			return 0f;
		}

		public float GetPrice(PowerUpType t)
		{
			return 0f;
		}

		public void Reset()
		{
		}

		public Dictionary<PowerUpType, PlayerStat> GetOwnedPowerUps()
		{
			return null;
		}

		public Dictionary<PowerUpType, PlayerStat> GetAllPowerUps()
		{
			return null;
		}

		private double ApplyMarkup(float value)
		{
			return 0.0;
		}

		private float GetTotalMarkup()
		{
			return 0f;
		}

		private float GetTotalPrice()
		{
			return 0f;
		}

		private void AddStat(PowerUpType type, int level, List<PowerUpData> data)
		{
		}

		private void Refresh()
		{
		}

		private void ResetPowerUps()
		{
		}
	}
}
