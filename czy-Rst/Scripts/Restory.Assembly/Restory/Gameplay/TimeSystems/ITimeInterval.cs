using System;

namespace Restory.Gameplay.TimeSystems
{
	public interface ITimeInterval
	{
		string ID { get; }

		TimeOfDay StartTime { get; }

		TimeOfDay EndTime { get; }

		bool IsInInterval(DateTime dateTime);

		bool IsInInterval(TimeOfDay timeOfDay);

		bool IsInInterval(TimeSpan currentTimeSpan);
	}
}
