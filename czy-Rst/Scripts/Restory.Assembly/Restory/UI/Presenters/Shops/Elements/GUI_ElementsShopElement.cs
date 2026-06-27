using System;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Localization;
using Restory.Data.Shops.Elements;
using Restory.ObjectPools;
using Restory.UI.Views.Shops.Elements;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public sealed class GUI_ElementsShopElement : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_ElementsShopElementView view;

		[SerializeField]
		private GUI_NumberInputField countInCartInputField;

		private LocalizationSystem localizationSystem;

		private ElementsShopItemData shopItemData;

		public ElementsShopItemData ShopItemData => shopItemData;

		public event Action<GUI_ElementsShopElement> OnIncreaseCountInCartButtonClicked;

		public event Action<GUI_ElementsShopElement> OnDecreaseCountInCartButtonClicked;

		public event Action<GUI_ElementsShopElement, int> OnInputValueChanged;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		public void Init(ElementsShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			this.shopItemData = shopItemData;
			this.shopItemData.OnIsInStockChanged += ResolveOnIsInStockChanged;
			ElementInfo element = this.shopItemData.Element;
			view.Init(element.Icon, localizationSystem.GetTranslation(element.NameLocalizationKey), localizationSystem.GetTranslation((element.SourceDevice is DeviceInfo deviceInfo) ? deviceInfo.NameLocalizationKey : string.Empty), shopItemData.Price, shopItemData.MinCount);
			UpdateCountInCart(countInCart, insufficientFunds);
			view.OnAddToCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			view.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
			countInCartInputField.OnValueChanged += ResolveInputValueChanged;
		}

		private void OnDisable()
		{
			if (shopItemData != null)
			{
				shopItemData.OnIsInStockChanged -= ResolveOnIsInStockChanged;
			}
			view.OnAddToCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
		}

		public void Clean()
		{
			if (shopItemData != null)
			{
				shopItemData.OnIsInStockChanged -= ResolveOnIsInStockChanged;
				shopItemData = null;
			}
			view.OnAddToCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
		}

		public int UpdateCountInCart(int countInCart, bool insufficientFunds)
		{
			countInCart = countInCartInputField.ValidateAddApplyCountValue(countInCart);
			view.UpdateInfo(countInCart, shopItemData.IsInStock, insufficientFunds);
			return countInCart;
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

		private void ResolveOnIsInStockChanged(ElementsShopItemData _)
		{
		}
	}
}
