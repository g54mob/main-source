using System;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.CoinService
{
	public class CoinService : ICoinService, IService
	{
		private IPersistentProgressService _progressService;

		public event Action OnCoinChanged;

		public CoinService(IPersistentProgressService progressService)
		{
			_progressService = progressService;
		}

		public void AddCoin(int value)
		{
			_progressService.Progress.Coins += value;
			this.OnCoinChanged?.Invoke();
		}

		public void SubtractCoin(int value)
		{
			_progressService.Progress.Coins -= value;
			this.OnCoinChanged?.Invoke();
			_progressService.Progress.ACH_ExtractCoins += value;
			if (_progressService.Progress.ACH_ExtractCoins >= 100)
			{
				SteamIntegration.Instance.UnlockAchievement("COINS_15", 15);
			}
		}

		public int GetCoin()
		{
			return _progressService.Progress.Coins;
		}
	}
}
