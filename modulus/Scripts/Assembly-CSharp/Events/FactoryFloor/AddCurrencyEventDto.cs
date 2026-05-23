using Data.FactoryFloor.Resources;

namespace Events.FactoryFloor
{
	public class AddCurrencyEventDto
	{
		public ResourceDataSO CurrencyType;

		public int Amount;

		public AddCurrencyEventDto(ResourceDataSO currencyType, int amount)
		{
			CurrencyType = currencyType;
			Amount = amount;
		}
	}
}
