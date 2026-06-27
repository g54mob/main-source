using System;
using System.Collections.Generic;

namespace Restory.Data.Devices
{
	[Serializable]
	public class DeviceShopLotsDeviceUniqueTexts
	{
		public DeviceInfo Device;

		public List<string> LocalizationKeys = new List<string>();
	}
}
