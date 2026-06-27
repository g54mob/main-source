using System;
using System.Collections.Generic;

namespace Restory.Data.Devices
{
	[Serializable]
	public class DeviceShopLotsDeviceCategoryUniqueTexts
	{
		public DeviceCategory DeviceCategory;

		public List<string> LocalizationKeys = new List<string>();
	}
}
