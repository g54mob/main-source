using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopLotsDevicesUniqueTextsCollection", fileName = "DeviceShopLotsDevicesUniqueTextsCollection")]
	public class DeviceShopLotsDevicesUniqueTextsCollection : ScriptableObject
	{
		[SerializeField]
		private DeviceShopLotsDeviceUniqueTexts[] devicesUniqueTexts = new DeviceShopLotsDeviceUniqueTexts[0];

		public IReadOnlyList<DeviceShopLotsDeviceUniqueTexts> DevicesUniqueTexts => devicesUniqueTexts;
	}
}
