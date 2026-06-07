using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	[Serializable]
	public class ScheduleTimeSlot : IPersistable
	{
		public int hour;

		public List<string> options;

		public ScheduleTimeSlot()
		{
		}

		public ScheduleTimeSlot(int hour)
		{
		}

		public ScheduleTimeSlot Clone()
		{
			return null;
		}
	}
}
