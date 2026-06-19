using UnityEngine;

namespace Services
{
	public class MoneyService : IMoneyService
	{
		private CurrencyData _currencyData;

		CurrencyData IMoneyService.CurrencyBalance => _currencyData;

		public MoneyService()
		{
			_currencyData = new CurrencyData
			{
				FlyCoinsBalance = 6.699999809265137
			};
		}

		void IMoneyService.AddCurrency(double amount)
		{
			_currencyData.FlyCoinsBalance += amount;
		}

		void IMoneyService.RemoveCurrency(double amount)
		{
			_currencyData.FlyCoinsBalance -= amount;
			_currencyData.FlyCoinsBalance = Mathf.Clamp((float)_currencyData.FlyCoinsBalance, 0f, float.PositiveInfinity);
		}

		void IMoneyService.SetCurrency(double amount)
		{
			_currencyData.FlyCoinsBalance = amount;
			_currencyData.FlyCoinsBalance = Mathf.Clamp((float)_currencyData.FlyCoinsBalance, 0f, float.PositiveInfinity);
		}
	}
}
