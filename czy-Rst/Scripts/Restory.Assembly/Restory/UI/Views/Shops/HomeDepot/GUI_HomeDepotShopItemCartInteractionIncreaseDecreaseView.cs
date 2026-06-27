using System;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public class GUI_HomeDepotShopItemCartInteractionIncreaseDecreaseView : UIBehaviour
	{
		[SerializeField]
		private GUI_NumberInputField countInCartInputField;

		[SerializeField]
		private GUI_AnimatedButtonView addToCartButton;

		[SerializeField]
		private Button increaseCountInCartButton;

		[SerializeField]
		private Button decreaseCountInCartButton;

		[SerializeField]
		private GameObject insufficientFunds;

		[SerializeField]
		private GUI_PresetSwitcher[] insufficientFundsPresetSwitchers = Array.Empty<GUI_PresetSwitcher>();

		[Space]
		[Header("Count Button Settings")]
		[SerializeField]
		private GameObject countInCartParent;

		[SerializeField]
		private TweenSequenceConstructor countButtonTweenSequence;

		[SerializeField]
		private GUI_PresetSwitcher countButtonPresetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName extendedPreset = PresetName.Extended;

		private bool insufficientFundsFlag;

		public event Action OnAddToCartButtonClicked;

		public event Action OnIncreaseCountInCartButtonClicked;

		public event Action OnDecreaseCountInCartButtonClicked;

		public event Action<int> OnInputValueChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			addToCartButton.OnAnimationStart += ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete += ResolveAddToCartButtonAnimationComplete;
			increaseCountInCartButton.onClick.AddListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.AddListener(ResolveDecreaseCountInCartButtonClicked);
			countInCartInputField.OnValueChanged += ResolveInputValueChanged;
		}

		protected override void OnDisable()
		{
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
			base.OnDisable();
		}

		public void Initialize(int countInCart, bool insufficientFunds)
		{
			countButtonPresetSwitcher.ActivatePreset(normalPreset);
			insufficientFundsFlag = insufficientFunds;
			countInCart = countInCartInputField.ValidateAddApplyCountValue(countInCart);
			SwitchCartGroupView(countInCart == 0);
		}

		public int UpdateCartInfo(int countInCart, bool insufficientFunds)
		{
			insufficientFundsFlag = insufficientFunds;
			countInCart = countInCartInputField.ValidateAddApplyCountValue(countInCart);
			if (countInCart == 0)
			{
				SwitchCartGroupView(shouldShowOnlyAddToCartButton: true);
			}
			return countInCart;
		}

		private void SwitchCartGroupView(bool shouldShowOnlyAddToCartButton)
		{
			addToCartButton.gameObject.SetActive(shouldShowOnlyAddToCartButton && !insufficientFundsFlag);
			countInCartParent.SetActive(!shouldShowOnlyAddToCartButton);
			insufficientFunds.SetActive(shouldShowOnlyAddToCartButton && insufficientFundsFlag);
			PresetName presetName = ((!insufficientFunds.activeSelf) ? PresetName.Normal : PresetName.Disabled);
			insufficientFundsPresetSwitchers.ForEach(delegate(GUI_PresetSwitcher s)
			{
				s.ActivatePreset(presetName);
			});
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke();
		}

		private void ResolveAddToCartButtonAnimationComplete()
		{
			countButtonPresetSwitcher.ActivatePreset(extendedPreset);
			SwitchCartGroupView(shouldShowOnlyAddToCartButton: false);
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

		private void ResolveInputValueChanged(int value)
		{
			if (value == 0)
			{
				SwitchCartGroupView(shouldShowOnlyAddToCartButton: true);
			}
			this.OnInputValueChanged?.Invoke(value);
		}
	}
}
