using System;
using System.Collections.Generic;
using Restory.UI.Presenters.Shops.Banners;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_ElementsShopProductsPanelView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TextMeshProUGUI goodsInCartCountText;

		[SerializeField]
		private GUI_AnimatedButtonView goToCartButton;

		[SerializeField]
		private RectTransform productsListParent;

		[SerializeField]
		private GUI_Banner banner;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		public event Action OnBannerClicked;

		public event Action OnGoToCartButtonClicked = delegate
		{
		};

		protected override void OnEnable()
		{
			banner.OnBannerClicked += ResolveBannerClicked;
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			banner.OnBannerClicked -= ResolveBannerClicked;
			goToCartButton.OnAnimationStart -= ResolveGoToCartButtonClicked;
			ClearProductsUiObjects();
			base.OnDisable();
		}

		public void Show()
		{
			SetVisibility(shouldBeVisible: true);
			goToCartButton.OnAnimationStart += ResolveGoToCartButtonClicked;
		}

		public void Hide()
		{
			goToCartButton.OnAnimationStart -= ResolveGoToCartButtonClicked;
			SetVisibility(shouldBeVisible: false);
			goodsInCartCountText.text = string.Empty;
		}

		public void SetProductsInCartCount(int count)
		{
			if (count > 0)
			{
				goodsInCartCountText.text = count.ToString();
				presetSwitcher.ActivatePreset(normalPreset);
			}
			else
			{
				goodsInCartCountText.text = string.Empty;
				presetSwitcher.ActivatePreset(disabledPreset);
			}
		}

		public void AttachProductsUiObjects(IEnumerable<Transform> products)
		{
			AddProductsUiObjects(products);
		}

		public void ToggleBanner(bool isActive)
		{
			banner.gameObject.SetActive(isActive);
		}

		public void ClearProductsUiObjects()
		{
			productsListParent.DetachChildren();
			banner.transform.SetParent(productsListParent);
		}

		private void AddProductsUiObjects(IEnumerable<Transform> productTransforms)
		{
			foreach (Transform productTransform in productTransforms)
			{
				productTransform.SetParent(productsListParent, worldPositionStays: false);
			}
		}

		private void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.interactable = shouldBeVisible;
			canvasGroup.blocksRaycasts = shouldBeVisible;
		}

		private void ResolveBannerClicked()
		{
			this.OnBannerClicked?.Invoke();
		}

		private void ResolveGoToCartButtonClicked()
		{
			this.OnGoToCartButtonClicked();
		}
	}
}
