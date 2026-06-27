using System;
using DistantLands.Cozy;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class CozyWeatherTimeAdapter : IInitializable, IDisposable, ITimeChangeReceiver
	{
		private readonly GameCalendar gameCalendar;

		private MeridiemTime cachedMeridiemTime = new MeridiemTime();

		public CozyWeatherTimeAdapter(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
		}

		public void Initialize()
		{
			ProcessTimeChanged();
			gameCalendar.AddSubscriber(this);
		}

		public void Dispose()
		{
			if (gameCalendar != null)
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void ProcessTimeChanged()
		{
			cachedMeridiemTime = CozyWeather.instance.timeModule.currentTime;
			cachedMeridiemTime.hours = gameCalendar.CurrentDateTime.Hour;
			cachedMeridiemTime.minutes = gameCalendar.CurrentDateTime.Minute;
			cachedMeridiemTime.seconds = gameCalendar.CurrentDateTime.Second;
			cachedMeridiemTime.milliseconds = gameCalendar.CurrentDateTime.Millisecond;
		}
	}
}
