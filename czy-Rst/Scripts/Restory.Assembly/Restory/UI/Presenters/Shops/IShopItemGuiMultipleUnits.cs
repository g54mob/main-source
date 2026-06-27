using System;

namespace Restory.UI.Presenters.Shops
{
	public interface IShopItemGuiMultipleUnits : IShopItemGui
	{
		event Action<IShopItemGuiMultipleUnits> OnAddToCartButtonClicked;

		event Action<IShopItemGuiMultipleUnits> OnIncreaseCountInCartButtonClicked;

		event Action<IShopItemGuiMultipleUnits> OnDecreaseCountInCartButtonClicked;

		event Action<IShopItemGuiMultipleUnits, int> OnInputValueChanged;

		int UpdateCountInCart(int countInCart, bool insufficientFunds);
	}
}
