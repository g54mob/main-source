using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Shops
{
	public class ShopRestockerGarageLoadException : AShopRestockerLoadException
	{
		[SerializeField]
		private GarageType_v2 garageType;

		public override void ModifyAmount()
		{
			if (garageType == null)
			{
				Debug.LogError("ShopRestockerGarageLoadException: Missing GarageType_v2 reference. Returning 0.", base.gameObject);
			}
			else if (SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(garageType))
			{
				data.allowedToHaveAmount = 0;
			}
		}
	}
}
