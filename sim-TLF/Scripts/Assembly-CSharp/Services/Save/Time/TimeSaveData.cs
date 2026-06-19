using System;

namespace Services.Save.Time
{
	[Serializable]
	public struct TimeSaveData
	{
		public float CurrentTime;

		public float TimeIncrement;

		public bool AutoTimeIncrement;
	}
}
