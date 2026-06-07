using System;
using System.Collections.Generic;
using LitJson;

namespace Gh.Tk
{
	public class ScheduleTimetable : IPersistable
	{
		[JsonIgnore]
		public string newOwnerName;

		[JsonIgnore]
		public GameObjectX owner;

		public List<ScheduleTimeSlot> scheduleSlots;

		public string emptyOptionId;

		public List<string> allowedOptionIds;

		public Func<ScheduleTimeSlot[]> getDefaultSlots;

		public void ApplyNewData()
		{
		}

		public string GetCurrentNameKey()
		{
			return null;
		}

		public void ResetToDefault()
		{
		}
	}
}
