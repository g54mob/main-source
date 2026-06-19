namespace Services
{
	public interface IMoneyService
	{
		CurrencyData CurrencyBalance { get; }

		void AddCurrency(double amount);

		void SetCurrency(double amount);

		void RemoveCurrency(double amount);
	}
}
