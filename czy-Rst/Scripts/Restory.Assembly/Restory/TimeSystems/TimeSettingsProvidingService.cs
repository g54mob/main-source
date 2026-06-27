using System;
using Restory.Data.TimeSystems;
using Restory.Gameplay.TimeSystems;
using Zenject;

namespace Restory.TimeSystems
{
	public class TimeSettingsProvidingService : IInitializable, IDisposable
	{
		private readonly TimeSettings timeSettings;

		public UDateTime StartingTime { get; private set; }

		public TimeOfDay MorningStartTime { get; private set; }

		public TimeOfDay AfternoonStartTime { get; private set; }

		public TimeOfDay EveningStartTime { get; private set; }

		public TimeOfDay WorkDayEndTime { get; private set; }

		public TimeOfDay TimeStep => timeSettings.TimeStep;

		public DaysOfWeekList DaysOfWeek => timeSettings.DaysOfWeek;

		public TimeSettingsProvidingService(TimeSettings timeSettings)
		{
			this.timeSettings = timeSettings;
			PerformSetUp();
		}

		private void PerformSetUp()
		{
			StartingTime = new DateTime(timeSettings.StartingYear, timeSettings.StartingMonth, timeSettings.StartingDay, timeSettings.StartingHour, timeSettings.StartingMinute, timeSettings.StartingSecond);
			MorningStartTime = timeSettings.MainDayTimesSettings.GetMorningStartTime();
			AfternoonStartTime = timeSettings.MainDayTimesSettings.GetAfternoonStartTime();
			EveningStartTime = timeSettings.MainDayTimesSettings.GetEveningStartTime();
			WorkDayEndTime = timeSettings.MainDayTimesSettings.GetWorkDayEndTime();
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}
	}
}
