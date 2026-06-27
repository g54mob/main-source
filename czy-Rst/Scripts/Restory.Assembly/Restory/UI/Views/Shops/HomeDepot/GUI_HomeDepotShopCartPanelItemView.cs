using Helpers.Extensions;
using Restory.ObjectPools;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopCartPanelItemView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private Image productImage;

		[SerializeField]
		private TextMeshProUGUI productNameText;

		[SerializeField]
		private TextMeshProUGUI productTypeText;

		[SerializeField]
		private TextMeshProUGUI priceText;

		public void SetUpGeneralInfo(Sprite productIcon, string productName, string productType, int price)
		{
			productImage.overrideSprite = productIcon;
			productNameText.text = productName;
			productTypeText.text = productType;
			priceText.text = price.ToReadableString();
		}

		protected override void OnEnable()
		{
			Subscribe();
		}

		protected override void OnDisable()
		{
			Unsubscribe();
		}

		public void Clean()
		{
			CleanUpOnClean();
			productImage.overrideSprite = null;
			productNameText.text = string.Empty;
			productTypeText.text = string.Empty;
			priceText.text = string.Empty;
		}

		protected virtual void Subscribe()
		{
		}

		protected virtual void Unsubscribe()
		{
		}

		protected virtual void CleanUpOnClean()
		{
		}
	}
}
