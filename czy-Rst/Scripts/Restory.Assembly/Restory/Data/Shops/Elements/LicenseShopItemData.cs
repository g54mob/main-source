using System;
using Restory.Data.Licenses;
using Restory.Data.Restrictions;

namespace Restory.Data.Shops.Elements
{
	[Serializable]
	public class LicenseShopItemData
	{
		public LicenseInfo License;

		public int Price;

		[NonSerialized]
		public ContentRestrictionBase ContentRestriction;

		public LicenseShopItemData Clone()
		{
			return MemberwiseClone() as LicenseShopItemData;
		}
	}
}
