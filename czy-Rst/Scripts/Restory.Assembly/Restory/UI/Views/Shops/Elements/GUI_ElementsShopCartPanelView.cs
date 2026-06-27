using System;
using System.Collections.Generic;
using Helpers.Extensions;
using Restory.TimeSystems;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_ElementsShopCartPanelView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TextMeshProUGUI totalCostText;

		[SerializeField]
		private TextMeshProUGUI itemsInCartCountText;

		[SerializeField]
		private Button exitPanelButton;

		[SerializeField]
		private Transform cartItemsListParent;

		[Space]
		[Header("Buy Button Settings")]
		[SerializeField]
		private Button buyButton;

		[SerializeField]
		private GUI_PresetSwitcher buyButtonPresetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		[SerializeField]
		private PresetName emptyPreset = PresetName.Empty;

		[SerializeField]
		private PresetName warningPreset = PresetName.Warning;

		public event Action OnBuyButtonClicked = delegate
		{
		};

		public event Action OnExitCartPanelButtonClicked = delegate
		{
		};

		protected override void OnDisable()
		{
			buyButton.onClick.RemoveListener(ResolveBuyButtonClicked);
			exitPanelButton.onClick.RemoveListener(ResolveExitCartPanelButtonClicked);
			base.OnDisable();
		}

		public void Show()
		{
			SetVisibility(shouldBeVisible: true);
			buyButton.onClick.AddListener(ResolveBuyButtonClicked);
			exitPanelButton.onClick.AddListener(ResolveExitCartPanelButtonClicked);
		}

		public void Hide()
		{
			buyButton.onClick.RemoveListener(ResolveBuyButtonClicked);
			exitPanelButton.onClick.RemoveListener(ResolveExitCartPanelButtonClicked);
			SetVisibility(shouldBeVisible: false);
		}

		public void SetCartInfo(int itemsInCartCount, int totalCost, int moneyAvailable, MainDayTimes mainDayTimes)
		{
			totalCostText.text = totalCost.ToReadableString();
			itemsInCartCountText.text = $"({itemsInCartCount})";
			if (itemsInCartCount == 0)
			{
				buyButtonPresetSwitcher.ActivatePreset(emptyPreset);
			}
			else if (totalCost > moneyAvailable)
			{
				buyButtonPresetSwitcher.ActivatePreset(disabledPreset);
			}
			else if (mainDayTimes == MainDayTimes.AfterWork)
			{
				buyButtonPresetSwitcher.ActivatePreset(warningPreset);
			}
			else
			{
				buyButtonPresetSwitcher.ActivatePreset(normalPreset);
			}
		}

		public void SetProductsUiObjects(IEnumerable<Transform> products)
		{
			DetachProductsUiObjects();
			AttachProductsUiObjects(products);
		}

		public void DetachProductsUiObjects()
		{
			cartItemsListParent.DetachChildren();
		}

		private void AttachProductsUiObjects(IEnumerable<Transform> products)
		{
			foreach (Transform product in products)
			{
				product.SetParent(cartItemsListParent, worldPositionStays: false);
			}
		}

		private void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.interactable = shouldBeVisible;
			canvasGroup.blocksRaycasts = shouldBeVisible;
		}

		private void ResolveBuyButtonClicked()
		{
			this.OnBuyButtonClicked?.Invoke();
		}

		private void ResolveExitCartPanelButtonClicked()
		{
			this.OnExitCartPanelButtonClicked?.Invoke();
		}
	}
}
