using System;
using Restory.Data.Devices.DeviceWorkTypes;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DeviceInWorkOrderSaveData
	{
		public string DeviceContainerId;

		public DeviceWorkType[] WorkTypes;
	}
}
