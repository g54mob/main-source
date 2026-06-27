using System;

namespace Restory.Data.Devices
{
	[Serializable]
	public class AvailableDevicesListEntry
	{
		public DeviceInfo Device;

		public int RandomnessWeight;

		public bool IsAvailable;
	}
}
