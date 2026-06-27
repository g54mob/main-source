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
	public sealed class GUI_ElementsShopCartPanelElement : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_ElementsShopCartPanelElementView view;

		[SerializeField]
		private GUI_NumberInputField countInCartInputField;

		private LocalizationSystem localizationSystem;

		private ElementsShopItemData shopItemData;

		public ElementsShopItemData ShopItemData => shopItemData;

		public event Action<GUI_ElementsShopCartPanelElement> OnIsInStockChanged;

		public event Action<GUI_ElementsShopCartPanelElement> OnIncreaseCountInCartButtonClicked;

		public event Action<GUI_ElementsShopCartPanelElement> OnDecreaseCountInCartButtonClicked;

		public event Action<GUI_ElementsShopCartPanelElement> OnRemoveFromCartButtonClicked;

		public event Action<GUI_ElementsShopCartPanelElement, int> OnInputValueChanged;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		private void OnDisable()
		{
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
		}

		public void Clean()
		{
			shopItemData.OnIsInStockChanged -= ResolveOnIsInStockChanged;
			view.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
		}

		public void Init(ElementsShopItemData shopItem, int countInCart)
		{
			shopItemData = shopItem;
			shopItemData.OnIsInStockChanged += ResolveOnIsInStockChanged;
			ElementInfo element = shopItemData.Element;
			if ((object)element == null)
			{
				Debug.LogError("[Init] received a [ElementsShopItemData] argument with an 'Element', which was not an [ElementInfo]. That is not supported!");
				return;
			}
			view.Init(element.Icon, localizationSystem.GetTranslation(element.NameLocalizationKey), localizationSystem.GetTranslation((element.SourceDevice is DeviceInfo deviceInfo) ? deviceInfo.NameLocalizationKey : string.Empty), shopItemData.Price, shopItemData.MinCount, shopItemData.IsInStock);
			UpdateCartInfo(countInCart);
			view.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			view.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			countInCartInputField.OnValueChanged += ResolveInputValueChanged;
		}

		public int UpdateCartInfo(int countInCart)
		{
			countInCart = countInCartInputField.ValidateAddApplyCountValue(countInCart);
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

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}

		private void ResolveInputValueChanged(int value)
		{
			this.OnInputValueChanged?.Invoke(this, value);
		}

		private void ResolveOnIsInStockChanged(ElementsShopItemData _)
		{
			this.OnIsInStockChanged?.Invoke(this);
		}
	}
}
