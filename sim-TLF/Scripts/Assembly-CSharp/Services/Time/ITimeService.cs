using System;

namespace Services.Time
{
	public interface ITimeService
	{
		float CurrentTime { get; }

		float TimeIncrement { get; }

		bool AutoTimeIncrement { get; }

		event Action<float> OnTimeChanged;

		void SetTime(float time);

		void SetTimeIncrement(float increment);

		void SetAutoTimeIncrement(bool auto);
	}
}
