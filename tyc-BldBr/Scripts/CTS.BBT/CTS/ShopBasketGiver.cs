using CTS.Core;

namespace CTS
{
	public abstract class ShopBasketGiver : CTSBehaviour, IGive<ShopBasket>
	{
		ShopBasket IGive<ShopBasket>.Get()
		{
			return GetBasket();
		}

		protected abstract ShopBasket GetBasket();
	}
}
