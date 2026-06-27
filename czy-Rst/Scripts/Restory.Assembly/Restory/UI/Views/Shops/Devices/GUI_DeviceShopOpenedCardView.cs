using System;
using Helpers.Extensions;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.Shops;
using Restory.ObjectPools;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.Devices
{
	public sealed class GUI_DeviceShopOpenedCardView : UIBehaviour, ICleanableComponent
	{
		[Header("Device")]
		[SerializeField]
		private Image deviceIcon;

		[SerializeField]
		private TextMeshProUGUI deviceName;

		[Space]
		[Header("Lot")]
		[SerializeField]
		private TextMeshProUGUI lotDescription;

		[SerializeField]
		private TextMeshProUGUI lotPrice;

		[SerializeField]
		private TextMeshProUGUI marketPrice;

		[Space]
		[Header("Quality")]
		[SerializeField]
		private GameObject qualityContainer;

		[SerializeField]
		private Image qualityIcon;

		[SerializeField]
		private TextMeshProUGUI qualityDescription;

		[Space]
		[Header("Seller")]
		[SerializeField]
		private TextMeshProUGUI sellerName;

		[SerializeField]
		private GUI_SellerRatingView sellerRatingView;

		[Space]
		[Header("Buttons")]
		[SerializeField]
		private GUI_AnimatedButtonView closeButton;

		[SerializeField]
		private GUI_AnimatedButtonView addToCartButton;

		[SerializeField]
		private GUI_AnimatedButtonView removeFromCartButton;

		[Space]
		[SerializeField]
		private Image backgroundIcon;

		[SerializeField]
		private GameObject insufficientFunds;

		[SerializeField]
		private GameObject licenseRequired;

		[Space]
		[Header("State")]
		[SerializeField]
		private GUI_PresetSwitcher statePresetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName selectedPreset = PresetName.Selected;

		[SerializeField]
		private PresetName insufficientFundsPreset = PresetName.Expensive;

		[SerializeField]
		private PresetName licenseRequiredPreset = PresetName.Blocked;

		[Space]
		[Header("Quality")]
		[SerializeField]
		private GUI_PresetSwitcher qualityDescriptionPresetSwitcher;

		[SerializeField]
		private PresetName idealQualityPreset = PresetName.Ideal;

		[SerializeField]
		private PresetName workingQualityPreset = PresetName.Working;

		[SerializeField]
		private PresetName brokenQualityPreset = PresetName.Broken;

		[SerializeField]
		private PresetName unknownQualityPreset = PresetName.Unknown;

		public event Action OnCloseButtonClicked;

		public event Action OnAddToCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			closeButton.OnAnimationStart += ResolveCloseButtonClicked;
			addToCartButton.OnAnimationStart += ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete += ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart += ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete += ResolveRemoveFromCartButtonAnimationComplete;
		}

		protected override void OnDisable()
		{
			closeButton.OnAnimationStart -= ResolveCloseButtonClicked;
			addToCartButton.OnAnimationStart -= ResolveAddToCartButtonClicked;
			addToCartButton.OnAnimationComplete -= ResolveAddToCartButtonAnimationComplete;
			removeFromCartButton.OnAnimationStart -= ResolveRemoveFromCartButtonClicked;
			removeFromCartButton.OnAnimationComplete -= ResolveRemoveFromCartButtonAnimationComplete;
			base.OnDisable();
		}

		public void Clean()
		{
		}

		public void Init(Sprite deviceIcon, string deviceName, string lotDescription, int lotPrice, int marketPrice, string sellerName, SellerRating sellerRating, Sprite backgroundIcon)
		{
			this.deviceIcon.sprite = deviceIcon;
			this.deviceName.text = deviceName;
			this.lotDescription.text = lotDescription;
			this.lotPrice.text = lotPrice.ToReadableString();
			this.marketPrice.text = marketPrice.ToReadableString();
			this.sellerName.text = sellerName;
			sellerRatingView.SetRating(sellerRating.Rating);
			this.backgroundIcon.overrideSprite = backgroundIcon;
		}

		public void ShowQuality(DeviceQualityBase quality, string qualityDescription)
		{
			qualityContainer.SetActive(value: true);
			qualityIcon.sprite = quality.Icon;
			this.qualityDescription.text = qualityDescription;
			if (!(quality is IdealDeviceQuality))
			{
				if (!(quality is WorkingDeviceQuality))
				{
					if (quality is BrokenDeviceQuality)
					{
						qualityDescriptionPresetSwitcher.ActivatePreset(brokenQualityPreset);
					}
					else
					{
						qualityDescriptionPresetSwitcher.ActivatePreset(unknownQualityPreset);
					}
				}
				else
				{
					qualityDescriptionPresetSwitcher.ActivatePreset(workingQualityPreset);
				}
			}
			else
			{
				qualityDescriptionPresetSwitcher.ActivatePreset(idealQualityPreset);
			}
		}

		public void HideQuality()
		{
			qualityContainer.SetActive(value: false);
		}

		public void SetNormalState()
		{
			statePresetSwitcher.ActivatePreset(PresetName.Normal);
		}

		public void SetSelectedState()
		{
			statePresetSwitcher.ActivatePreset(PresetName.Selected);
		}

		public void SetInsufficientFundsState()
		{
			statePresetSwitcher.ActivatePreset(PresetName.Expensive);
		}

		public void SetLicenseRequiredState()
		{
			statePresetSwitcher.ActivatePreset(PresetName.Blocked);
		}

		private void ResolveCloseButtonClicked()
		{
			this.OnCloseButtonClicked?.Invoke();
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
