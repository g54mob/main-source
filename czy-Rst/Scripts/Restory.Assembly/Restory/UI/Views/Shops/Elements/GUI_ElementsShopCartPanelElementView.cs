using System;
using Helpers.Extensions;
using Restory.ObjectPools;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_ElementsShopCartPanelElementView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private Image productImage;

		[SerializeField]
		private TextMeshProUGUI productNameText;

		[SerializeField]
		private TextMeshProUGUI productTypeText;

		[SerializeField]
		private TextMeshProUGUI priceText;

		[SerializeField]
		private Button increaseCountInCartButton;

		[SerializeField]
		private Button decreaseCountInCartButton;

		[SerializeField]
		private Button removeFromCartButton;

		[SerializeField]
		private GameObject wholesaleMarking;

		[SerializeField]
		private GameObject fromMinCountInfo;

		[SerializeField]
		private TextMeshProUGUI minCountText;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName outOfStockPreset = PresetName.Empty;

		public event Action OnIncreaseCountInCartButtonClicked;

		public event Action OnDecreaseCountInCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			increaseCountInCartButton.onClick.AddListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.AddListener(ResolveDecreaseCountInCartButtonClicked);
			removeFromCartButton.onClick.AddListener(ResolveRemoveFromCartButtonClicked);
		}

		protected override void OnDisable()
		{
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			removeFromCartButton.onClick.RemoveListener(ResolveRemoveFromCartButtonClicked);
			base.OnDisable();
		}

		public void Clean()
		{
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			removeFromCartButton.onClick.RemoveListener(ResolveRemoveFromCartButtonClicked);
			productImage.overrideSprite = null;
			productNameText.text = string.Empty;
			productTypeText.text = string.Empty;
			priceText.text = string.Empty;
		}

		public void Init(Sprite productIcon, string productName, string productType, int price, int minCount, bool isInStock)
		{
			productImage.sprite = productIcon;
			productNameText.text = productName;
			productTypeText.text = productType;
			priceText.text = price.ToReadableString();
			if (minCount > 1)
			{
				minCountText.text = minCount.ToString();
				wholesaleMarking.SetActive(value: true);
				fromMinCountInfo.SetActive(value: true);
			}
			else
			{
				wholesaleMarking.SetActive(value: false);
				fromMinCountInfo.SetActive(value: false);
			}
			presetSwitcher.ActivatePreset(isInStock ? normalPreset : outOfStockPreset);
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke();
		}
	}
}
