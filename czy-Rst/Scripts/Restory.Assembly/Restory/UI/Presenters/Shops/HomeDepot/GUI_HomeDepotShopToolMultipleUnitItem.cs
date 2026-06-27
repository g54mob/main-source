using System;
using Restory.Data.Shops.HomeDepot;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopToolMultipleUnitItem : GUI_HomeDepotShopItem, IShopItemGuiMultipleUnits, IShopItemGui
	{
		[SerializeField]
		private GUI_HomeDepotShopToolMultipleUnitItemView view;

		public event Action<IShopItemGuiMultipleUnits> OnAddToCartButtonClicked;

		public event Action<IShopItemGuiMultipleUnits> OnIncreaseCountInCartButtonClicked;

		public event Action<IShopItemGuiMultipleUnits> OnDecreaseCountInCartButtonClicked;

		public event Action<IShopItemGuiMultipleUnits, int> OnInputValueChanged;

		protected override void SetUpView(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			if (!(shopItemData is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
			{
				Debug.LogError("[GUI_HomeDepotShopToolMultipleUnitItem] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItemData, "HomeDepotShopCleaningToolItemData"));
			}
			else
			{
				view.SetUpInitialInfo(homeDepotShopCleaningToolItemData.ToolInfo.Icon, localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.DescriptionLocalizationKey), homeDepotShopCleaningToolItemData.Price, countInCart, insufficientFunds, shopItemData.ContentRestriction);
			}
		}

		public int UpdateCountInCart(int countInCart, bool insufficientFunds)
		{
			return view.UpdateCartInfo(countInCart, insufficientFunds);
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			view.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			view.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
			view.OnInputValueChanged += ResolveInputValueChanged;
		}

		protected override void Unsubscribe()
		{
			view.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			view.OnInputValueChanged -= ResolveInputValueChanged;
			base.Unsubscribe();
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke(this);
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke(this);
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke(this);
		}

		private void ResolveInputValueChanged(int value)
		{
			this.OnInputValueChanged?.Invoke(this, value);
		}
	}
}
