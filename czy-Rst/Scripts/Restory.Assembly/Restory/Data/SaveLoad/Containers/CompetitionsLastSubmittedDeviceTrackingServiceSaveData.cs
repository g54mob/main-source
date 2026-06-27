using System;
using System.Collections.Generic;
using Restory.Data.Devices;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CompetitionsLastSubmittedDeviceTrackingServiceSaveData
	{
		public List<SubmittedDeviceBestTimeSaveData> LastSubmittedDevicesBestTime;

		public DeviceInfo LastSubmittedDeviceInfo;

		public bool WasLastSubmittedDeviceBestTime;
	}
}
