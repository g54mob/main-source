using DV.ThingTypes;
using DV.Utils;

namespace DV.Shops
{
	public class ShopRestockerWirelessMULoadException : AShopRestockerLoadException
	{
		public GeneralLicenseType_v2 license;

		public override void Initialize(ShopItemData data)
		{
			base.Initialize(data);
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += delegate(GeneralLicenseType_v2 l)
			{
				if (l.Equals(license))
				{
					data.allowedToHaveAmount = data.initialAmount;
					SingletonBehaviour<GlobalShopController>.Instance.Fire_GlobalShopDataChanged();
				}
			};
		}

		public override void ModifyAmount()
		{
			if (!SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(license))
			{
				data.allowedToHaveAmount = 0;
			}
		}
	}
}
