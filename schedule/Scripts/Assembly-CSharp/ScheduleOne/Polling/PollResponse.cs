using System;

namespace ScheduleOne.Polling
{
	[Serializable]
	public class PollResponse
	{
		public PollData[] polls;

		public int active;

		public int confirmed;

		public PollData GetActive()
		{
			return null;
		}

		public PollData GetConfirmed()
		{
			return null;
		}
	}
}
