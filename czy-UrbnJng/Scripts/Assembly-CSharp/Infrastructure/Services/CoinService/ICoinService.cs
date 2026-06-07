using System;

namespace Infrastructure.Services.CoinService
{
	public interface ICoinService : IService
	{
		event Action OnCoinChanged;

		void AddCoin(int value);

		void SubtractCoin(int value);

		int GetCoin();
	}
}
