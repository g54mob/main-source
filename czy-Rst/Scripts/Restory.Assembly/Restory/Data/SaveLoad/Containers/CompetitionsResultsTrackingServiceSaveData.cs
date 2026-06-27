using System;
using System.Collections.Generic;
using Restory.Data.Devices;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CompetitionsResultsTrackingServiceSaveData
	{
		public Dictionary<DeviceInfo, float> DevicesTimes;
	}
}
