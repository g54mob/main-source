using System;
using Restory.Data.Devices;
using Restory.Data.Devices.Quality;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public abstract class GameStatisticsSentDeviceSaveData
	{
		public DeviceInfo Device;

		public int MoneyReceived;

		public int DayIndex;

		public DeviceQualityBase DeviceQuality;
	}
}
