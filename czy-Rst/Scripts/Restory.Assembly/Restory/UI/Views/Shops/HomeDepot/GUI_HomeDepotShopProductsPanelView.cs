using System;
using System.Collections.Generic;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopProductsPanelView : UIBehaviour
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
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		public event Action OnGoToCartButtonClicked = delegate
		{
		};

		protected override void OnDisable()
		{
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
			ClearProductsUiObjects();
			AddProductsUiObjects(products);
		}

		private void ClearProductsUiObjects()
		{
			productsListParent.DetachChildren();
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

		private void ResolveGoToCartButtonClicked()
		{
			this.OnGoToCartButtonClicked();
		}
	}
}
