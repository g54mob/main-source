using System;
using Helpers.Extensions;
using Restory.ObjectPools;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_LicenseShopItemView : UIBehaviour, ICleanableComponent
	{
		[Header("Device")]
		[SerializeField]
		private Image icon;

		[SerializeField]
		private TextMeshProUGUI title;

		[Space]
		[Header("Lot")]
		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private TextMeshProUGUI price;

		[Space]
		[Header("Buttons")]
		[SerializeField]
		private Button itemButton;

		[SerializeField]
		private GUI_AnimatedButtonView addToCartButton;

		[SerializeField]
		private GUI_AnimatedButtonView removeFromCartButton;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName selectedPreset = PresetName.Selected;

		[SerializeField]
		private PresetName unavailablePreset = PresetName.Blocked;

		[SerializeField]
		private PresetName insufficientFundsPreset = PresetName.Disabled;

		[SerializeField]
		private PresetName comingSoonPreset = PresetName.ComingSoon;

		public event Action OnItemButtonClicked;

		public event Action OnAddToCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			itemButton.onClick.AddListener(ResolveItemButtonClicked);
			addToCartButton.OnAnimationStart += ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete += ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart += ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete += ResolveRemoveFromCartButtonAnimationComplete;
		}

		protected override void OnDisable()
		{
			itemButton.onClick.RemoveListener(ResolveItemButtonClicked);
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart -= ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete -= ResolveRemoveFromCartButtonAnimationComplete;
			base.OnDisable();
		}

		public void Clean()
		{
		}

		public void Init(Sprite icon, string title, string description, int price)
		{
			this.icon.sprite = icon;
			this.title.text = title;
			this.description.text = description;
			this.price.text = price.ToReadableString();
		}

		public void SetNormalState()
		{
			presetSwitcher.ActivatePreset(normalPreset);
		}

		public void SetSelectedState()
		{
			presetSwitcher.ActivatePreset(selectedPreset);
		}

		public void SetUnavailableState()
		{
			presetSwitcher.ActivatePreset(unavailablePreset);
		}

		public void SetInsufficientFundsState()
		{
			presetSwitcher.ActivatePreset(insufficientFundsPreset);
		}

		public void SetComingSoonState()
		{
			presetSwitcher.ActivatePreset(comingSoonPreset);
		}

		private void ResolveItemButtonClicked()
		{
			this.OnItemButtonClicked?.Invoke();
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
