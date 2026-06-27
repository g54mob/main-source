using System;
using Helpers.Extensions;
using Restory.ObjectPools;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_ElementsShopElementView : UIBehaviour, ICleanableComponent
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
		private GUI_AnimatedButtonView addToCartButton;

		[SerializeField]
		private Button increaseCountInCartButton;

		[SerializeField]
		private Button decreaseCountInCartButton;

		[SerializeField]
		private GameObject wholesaleMarking;

		[SerializeField]
		private GameObject fromMinCountInfo;

		[SerializeField]
		private TextMeshProUGUI minCountText;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher[] insufficientFundsPresetSwitchers = Array.Empty<GUI_PresetSwitcher>();

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName availablePreset = PresetName.Ready;

		[SerializeField]
		private PresetName addedPreset = PresetName.Chosen;

		[SerializeField]
		private PresetName insufficientFundsPreset = PresetName.Expensive;

		[SerializeField]
		private PresetName outOfStockPreset = PresetName.Empty;

		[Space]
		[Header("Count Button")]
		[SerializeField]
		private TweenSequenceConstructor countButtonTweenSequence;

		[SerializeField]
		private GUI_PresetSwitcher countButtonPresetSwitcher;

		public event Action OnAddToCartButtonClicked;

		public event Action OnIncreaseCountInCartButtonClicked;

		public event Action OnDecreaseCountInCartButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			addToCartButton.OnAnimationStart += ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete += ResolveAddToCartButtonAnimationComplete;
			increaseCountInCartButton.onClick.AddListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.AddListener(ResolveDecreaseCountInCartButtonClicked);
		}

		protected override void OnDisable()
		{
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			base.OnDisable();
		}

		public void Clean()
		{
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			productImage.overrideSprite = null;
			productNameText.text = string.Empty;
			productTypeText.text = string.Empty;
			priceText.text = string.Empty;
		}

		public void Init(Sprite productIcon, string productName, string productType, int price, int minCount)
		{
			productImage.sprite = productIcon;
			productNameText.text = productName;
			productTypeText.text = productType;
			priceText.text = price.ToReadableString();
			countButtonPresetSwitcher.ActivatePreset(PresetName.Normal);
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
		}

		public void UpdateInfo(int countInCart, bool isInStock, bool insufficientFunds)
		{
			PresetName presetName = ((!insufficientFunds) ? PresetName.Normal : PresetName.Disabled);
			insufficientFundsPresetSwitchers.ForEach(delegate(GUI_PresetSwitcher s)
			{
				s.ActivatePreset(presetName);
			});
			if (!isInStock)
			{
				presetSwitcher.ActivatePreset(outOfStockPreset);
			}
			else if (insufficientFunds)
			{
				presetSwitcher.ActivatePreset(insufficientFundsPreset);
			}
			else
			{
				presetSwitcher.ActivatePreset((countInCart > 0) ? addedPreset : availablePreset);
			}
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke();
		}

		private void ResolveAddToCartButtonAnimationComplete()
		{
			countButtonPresetSwitcher.ActivatePreset(PresetName.Extended);
			countButtonTweenSequence.StartSequence();
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke();
		}
	}
}
