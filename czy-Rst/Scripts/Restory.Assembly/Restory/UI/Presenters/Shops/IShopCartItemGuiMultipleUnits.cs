using System;

namespace Restory.UI.Presenters.Shops
{
	public interface IShopCartItemGuiMultipleUnits : IShopCartItemGui
	{
		event Action<IShopCartItemGuiMultipleUnits> OnIncreaseCountInCartButtonClicked;

		event Action<IShopCartItemGuiMultipleUnits> OnDecreaseCountInCartButtonClicked;

		event Action<IShopCartItemGuiMultipleUnits, int> OnInputValueChanged;

		int UpdateCountInCart(int countInCart);
	}
}
