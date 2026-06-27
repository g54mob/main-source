using System;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public class GUI_HomeDepotShopItemCartInteractionAddRemoveView : UIBehaviour
	{
		[Space]
		[Header("Buttons")]
		[SerializeField]
		private GUI_AnimatedButtonView addToCartButton;

		[SerializeField]
		private GUI_AnimatedButtonView removeFromCartButton;

		[SerializeField]
		private GameObject insufficientFunds;

		[SerializeField]
		private GUI_PresetSwitcher[] insufficientFundsPresetSwitchers = Array.Empty<GUI_PresetSwitcher>();

		public event Action OnAddToCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			addToCartButton.OnAnimationStart += ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete += ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart += ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete += ResolveRemoveFromCartButtonAnimationComplete;
		}

		protected override void OnDisable()
		{
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart -= ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete -= ResolveRemoveFromCartButtonAnimationComplete;
			base.OnDisable();
		}

		public void SetNormalState()
		{
			addToCartButton.gameObject.SetActive(value: true);
			removeFromCartButton.gameObject.SetActive(value: false);
			insufficientFunds.SetActive(value: false);
			insufficientFundsPresetSwitchers.ForEach(delegate(GUI_PresetSwitcher s)
			{
				s.ActivatePreset(PresetName.Normal);
			});
		}

		public void SetSelectedState()
		{
			addToCartButton.gameObject.SetActive(value: false);
			removeFromCartButton.gameObject.SetActive(value: true);
			insufficientFunds.SetActive(value: false);
			insufficientFundsPresetSwitchers.ForEach(delegate(GUI_PresetSwitcher s)
			{
				s.ActivatePreset(PresetName.Normal);
			});
		}

		public void SetInsufficientFundsState()
		{
			addToCartButton.gameObject.SetActive(value: false);
			removeFromCartButton.gameObject.SetActive(value: false);
			insufficientFunds.SetActive(value: true);
			insufficientFundsPresetSwitchers.ForEach(delegate(GUI_PresetSwitcher s)
			{
				s.ActivatePreset(PresetName.Disabled);
			});
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke();
		}

		private void ResolveAddToCartButtonAnimationComplete()
		{
			SetSelectedState();
		}

		private void ResolveRemoveFromCartButtonAnimationComplete()
		{
			SetNormalState();
		}
	}
}
