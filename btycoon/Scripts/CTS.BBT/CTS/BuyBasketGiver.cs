using CTS.Core;

namespace CTS
{
	public class BuyBasketGiver : ShopBasketGiver
	{
		protected override ShopBasket GetBasket()
		{
			if (!CTSSingleton<StoreBaskets>.InstanceExists())
			{
				return null;
			}
			return CTSSingleton<StoreBaskets>.Instance.BuyBasket;
		}
	}
}
