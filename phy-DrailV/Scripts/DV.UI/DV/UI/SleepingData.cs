using System;

namespace DV.UI
{
	public struct SleepingData
	{
		public enum SleepPermissionState
		{
			Allowed = 0,
			DeniedTrainIsMoving = 1,
			DeniedTooSoon = 2,
			DeniedSleepDisabled = 3
		}

		public SleepPermissionState sleepPermissionState;

		public DateTime currentTime;

		public DateTime nextSleepMinTime;
	}
}
