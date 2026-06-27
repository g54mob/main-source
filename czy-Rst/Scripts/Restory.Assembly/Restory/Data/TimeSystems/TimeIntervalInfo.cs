using System;
using Restory.Data.Base;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.TimeSystems
{
	[CreateAssetMenu(fileName = "TimeInterval", menuName = "Restory/TimeSystemsData/TimeInterval")]
	public class TimeIntervalInfo : RestoryEntityInfoBase, ITimeInterval
	{
		[SerializeField]
		private TimeOfDay startTime;

		[SerializeField]
		private TimeOfDay endTime;

		public TimeOfDay StartTime => startTime;

		public TimeOfDay EndTime => endTime;

		public bool IsInInterval(DateTime dateTime)
		{
			TimeSpan currentTimeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
			return IsInInterval(currentTimeSpan);
		}

		public bool IsInInterval(TimeOfDay timeOfDay)
		{
			return IsInInterval(timeOfDay.InTimeSpan());
		}

		public bool IsInInterval(TimeSpan currentTimeSpan)
		{
			TimeSpan timeSpan = startTime.InTimeSpan();
			TimeSpan timeSpan2 = endTime.InTimeSpan();
			if (timeSpan <= timeSpan2)
			{
				if (currentTimeSpan >= timeSpan && currentTimeSpan <= timeSpan2)
				{
					return true;
				}
			}
			else if (currentTimeSpan >= timeSpan || currentTimeSpan <= timeSpan2)
			{
				return true;
			}
			return false;
		}
	}
}
