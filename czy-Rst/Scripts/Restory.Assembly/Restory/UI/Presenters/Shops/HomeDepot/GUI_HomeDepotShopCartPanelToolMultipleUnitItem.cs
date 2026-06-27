using System;
using Restory.Data.Shops.HomeDepot;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanelToolMultipleUnitItem : GUI_HomeDepotShopCartPanelItem, IShopCartItemGuiMultipleUnits, IShopCartItemGui
	{
		[SerializeField]
		private GUI_HomeDepotShopCartPanelToolMultipleUnitItemView view;

		public event Action<IShopCartItemGuiMultipleUnits> OnIncreaseCountInCartButtonClicked;

		public event Action<IShopCartItemGuiMultipleUnits> OnDecreaseCountInCartButtonClicked;

		public event Action<IShopCartItemGuiMultipleUnits> OnRemoveFromCartButtonClicked;

		public event Action<IShopCartItemGuiMultipleUnits, int> OnInputValueChanged;

		protected override void SetUpView(HomeDepotShopItemData shopItem)
		{
			if (!(shopItem is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
			{
				Debug.LogError("[HomeDepotShopItemData] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItem, "HomeDepotShopCleaningToolItemData"));
			}
			else
			{
				view.SetUpGeneralInfo(homeDepotShopCleaningToolItemData.ToolInfo.Icon, localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.DescriptionLocalizationKey), homeDepotShopCleaningToolItemData.Price);
			}
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			view.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			view.OnInputValueChanged += ResolveInputValueChanged;
		}

		protected override void Unsubscribe()
		{
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			view.OnInputValueChanged -= ResolveInputValueChanged;
			base.Unsubscribe();
		}

		public int UpdateCountInCart(int countInCart)
		{
			return view.UpdateCartInfo(countInCart);
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke(this);
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke(this);
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}

		private void ResolveInputValueChanged(int value)
		{
			this.OnInputValueChanged?.Invoke(this, value);
		}
	}
}
