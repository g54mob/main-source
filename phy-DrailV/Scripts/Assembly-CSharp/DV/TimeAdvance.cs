using DV.Logic.Job;
using DV.Utils;
using DV.WeatherSystem;

namespace DV
{
	public class TimeAdvance
	{
		public static void AdvanceTime(float amountOfTimeToSkipInSeconds, bool force = false)
		{
			if (force || !SingletonBehaviour<WeatherDriver>.Instance || !SingletonBehaviour<WeatherDriver>.Instance.TimeOfDayHours.IsOverridden)
			{
				JobsManager instance = SingletonBehaviour<JobsManager>.Instance;
				if ((bool)instance)
				{
					float num = Globals.G.GameParams.DayLengthInMinutes / 1440f;
					instance.AdvanceTime(amountOfTimeToSkipInSeconds * num);
				}
				WeatherDriver instance2 = SingletonBehaviour<WeatherDriver>.Instance;
				if ((bool)instance2 && (bool)instance2.manager)
				{
					instance2.manager.AdvanceTime(amountOfTimeToSkipInSeconds);
				}
			}
		}
	}
}
