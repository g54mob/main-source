using System;

namespace Restory.UI.Presenters.Shops
{
	public interface IShopCartItemGuiSingleUnit : IShopCartItemGui
	{
		event Action<IShopCartItemGuiSingleUnit> OnRemoveFromCartButtonClicked;
	}
}
