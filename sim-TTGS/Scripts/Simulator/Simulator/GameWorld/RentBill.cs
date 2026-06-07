using System;

namespace Simulator.GameWorld
{
	[Serializable]
	public class RentBill : Bill
	{
		public override float GetDailyPrice()
		{
			if (unpaidDays <= 0)
			{
				return 0f;
			}
			float num = defaultPrice;
			for (int i = 0; i < ShopExtensionSystem.ShopExtensionLevel; i++)
			{
				num *= priceMultiplier;
			}
			return num;
		}
	}
}
