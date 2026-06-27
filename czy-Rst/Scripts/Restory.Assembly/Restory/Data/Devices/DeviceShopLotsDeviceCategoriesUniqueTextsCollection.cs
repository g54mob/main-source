using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopLotsDeviceCategoriesUniqueTextsCollection", fileName = "DeviceShopLotsDeviceCategoriesUniqueTextsCollection")]
	public class DeviceShopLotsDeviceCategoriesUniqueTextsCollection : ScriptableObject
	{
		[SerializeField]
		private DeviceShopLotsDeviceCategoryUniqueTexts[] deviceCategoriesUniqueTexts = new DeviceShopLotsDeviceCategoryUniqueTexts[0];

		public IReadOnlyList<DeviceShopLotsDeviceCategoryUniqueTexts> DeviceCategoriesUniqueTexts => deviceCategoriesUniqueTexts;
	}
}
