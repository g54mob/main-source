using System;
using Restory.Data.Devices;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class SubmittedDeviceBestTimeSaveData
	{
		public DeviceInfo DeviceInfo;

		public bool WasBestTime;
	}
}
