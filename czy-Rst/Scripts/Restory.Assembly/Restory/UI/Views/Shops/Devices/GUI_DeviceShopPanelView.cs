using System;
using System.Collections.Generic;
using Restory.UI.Presenters.Shops.Banners;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Shops.Devices
{
	public sealed class GUI_DeviceShopPanelView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TextMeshProUGUI goodsInCartCountText;

		[SerializeField]
		private GUI_AnimatedButtonView openCartButton;

		[SerializeField]
		private RectTransform itemsParent;

		[SerializeField]
		private GUI_Banner licenseBanner;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		[SerializeField]
		private PresetName hiddenPreset = PresetName.Hidden;

		public event Action OnLicenseBannerClicked;

		public event Action OnOpenCartButtonClicked;

		protected override void OnEnable()
		{
			licenseBanner.OnBannerClicked += ResolveLicenseBannerClicked;
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			if (licenseBanner.MonoShellExists())
			{
				licenseBanner.OnBannerClicked -= ResolveLicenseBannerClicked;
			}
			if (openCartButton.MonoShellExists())
			{
				openCartButton.OnAnimationStart -= ResolveOpenCartButtonClicked;
			}
			ClearProductsUiObjects();
			base.OnDisable();
		}

		public void Show()
		{
			SetVisibility(shouldBeVisible: true);
			openCartButton.OnAnimationStart += ResolveOpenCartButtonClicked;
		}

		public void Hide()
		{
			openCartButton.OnAnimationStart -= ResolveOpenCartButtonClicked;
			SetVisibility(shouldBeVisible: false);
			goodsInCartCountText.text = string.Empty;
		}

		public void SetLotsInCartCount(int countInShoppingCart, int countInShop)
		{
			if (countInShoppingCart > 0)
			{
				goodsInCartCountText.text = countInShoppingCart.ToString();
				presetSwitcher.ActivatePreset(normalPreset);
			}
			else
			{
				goodsInCartCountText.text = string.Empty;
				presetSwitcher.ActivatePreset((countInShop > 0) ? disabledPreset : hiddenPreset);
			}
		}

		public void AttachItemsUiObjects(IEnumerable<Transform> itemTransforms)
		{
			ClearProductsUiObjects();
			AddProductsUiObjects(itemTransforms);
		}

		public void ToggleLicenseBanner(bool isActive)
		{
			licenseBanner.gameObject.SetActive(isActive);
		}

		private void ClearProductsUiObjects()
		{
			if ((bool)itemsParent)
			{
				itemsParent.DetachChildren();
			}
			if (licenseBanner.MonoShellExists() && licenseBanner.gameObject.activeSelf)
			{
				licenseBanner.transform.SetParent(itemsParent);
			}
		}

		private void AddProductsUiObjects(IEnumerable<Transform> itemTransforms)
		{
			foreach (Transform itemTransform in itemTransforms)
			{
				itemTransform.SetParent(itemsParent, worldPositionStays: false);
			}
		}

		private void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.interactable = shouldBeVisible;
			canvasGroup.blocksRaycasts = shouldBeVisible;
		}

		private void ResolveLicenseBannerClicked()
		{
			this.OnLicenseBannerClicked?.Invoke();
		}

		private void ResolveOpenCartButtonClicked()
		{
			this.OnOpenCartButtonClicked?.Invoke();
		}
	}
}
