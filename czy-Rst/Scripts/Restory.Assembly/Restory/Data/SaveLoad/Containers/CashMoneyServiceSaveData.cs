using System;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CashMoneyServiceSaveData
	{
		public MoneyItemSaveData MoneyOnDesk;

		public MoneyItemSaveData[] OtherMoneyItems;
	}
}
