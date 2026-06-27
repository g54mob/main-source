using System;
using Restory.Data.Devices;
using Restory.Data.Devices.Quality;

namespace Restory.Gameplay.Statistics
{
	[Serializable]
	public class GameStatisticsSentDeviceRecord
	{
		public DeviceInfo DeviceInfo;

		public int MoneyReceived;

		public int DayIndex;

		public DeviceQualityBase DeviceQuality;
	}
}
