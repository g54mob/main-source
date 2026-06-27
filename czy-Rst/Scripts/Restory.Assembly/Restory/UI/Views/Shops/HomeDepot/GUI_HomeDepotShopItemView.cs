using Helpers.Extensions;
using Restory.Data.Restrictions;
using Restory.ObjectPools;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopItemView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private Image productImage;

		[SerializeField]
		private TextMeshProUGUI productNameText;

		[SerializeField]
		private TextMeshProUGUI productTypeText;

		[SerializeField]
		private TextMeshProUGUI priceText;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName comingSoonPreset = PresetName.ComingSoon;

		public void Clean()
		{
			productImage.overrideSprite = null;
			productNameText.text = string.Empty;
			productTypeText.text = string.Empty;
			priceText.text = string.Empty;
			CleanUpOnClean();
		}

		public void SetUpInitialInfo(Sprite productIcon, string productName, string productType, int price, int countInCart, bool insufficientFunds, ContentRestrictionBase contentRestriction)
		{
			productImage.sprite = productIcon;
			productNameText.text = productName;
			productTypeText.text = productType;
			priceText.text = price.ToReadableString();
			SetUpSpecificItemInfo();
			if ((bool)contentRestriction)
			{
				ApplyPreset(comingSoonPreset);
			}
			else
			{
				ApplyPreset(normalPreset);
				SetUpViewButtons(countInCart, insufficientFunds);
			}
			if (contentRestriction is HiddenInDemo)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected void ApplyPreset(PresetName preset)
		{
			presetSwitcher.ActivatePreset(preset);
		}

		protected virtual void SetUpSpecificItemInfo()
		{
		}

		protected virtual void SetUpViewButtons(int countInCart, bool insufficientFunds)
		{
		}

		protected virtual void CleanUpOnClean()
		{
		}
	}
}
