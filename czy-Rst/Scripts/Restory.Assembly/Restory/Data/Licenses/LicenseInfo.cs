using Mandragora.Utils;
using Restory.Data.Devices;
using Restory.Data.InteractiveObjects;
using Restory.UI.Presenters.Shops.Elements;
using UnityEngine;

namespace Restory.Data.Licenses
{
	[CreateAssetMenu(menuName = "Restory/Licenses/LicenseInfo", fileName = "Name - LicenseInfo")]
	public class LicenseInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		[SerializeField]
		private LicenseCategory category;

		[SerializeField]
		private DeviceInfo deviceInfo;

		[SerializeField]
		private GUI_LicenseShopItem shopItemPrefab;

		[SerializeField]
		[BoolButton(20, 0)]
		private bool availableForSale = true;

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;

		public LicenseCategory Category => category;

		public DeviceInfo DeviceInfo => deviceInfo;

		public GUI_LicenseShopItem ShopItemPrefab => shopItemPrefab;

		public bool AvailableForSale => availableForSale;

		protected override void OnValidate()
		{
			if ((bool)deviceInfo && (bool)deviceInfo.License && deviceInfo.License != this)
			{
				Debug.LogError("Wrong LicenseInfo data reference in deviceInfo");
			}
			base.OnValidate();
		}
	}
}
