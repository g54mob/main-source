using System;

namespace Restory.UI.Presenters.Shops
{
	public interface IShopItemGuiSingleUnit : IShopItemGui
	{
		event Action<IShopItemGuiSingleUnit> OnAddToCartButtonClicked;

		event Action<IShopItemGuiSingleUnit> OnRemoveFromCartButtonClicked;
	}
}
