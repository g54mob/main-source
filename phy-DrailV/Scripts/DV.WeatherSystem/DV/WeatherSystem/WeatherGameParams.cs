using System;

namespace DV.WeatherSystem
{
	public class WeatherGameParams
	{
		public bool RainAllowed { get; private set; }

		public bool ThunderAllowed { get; private set; }

		public float SpeedModifier { get; private set; }

		public float DayLengthInMinutes { get; private set; }

		public event Action DayLengthChanged;

		public WeatherGameParams(bool rainAllowed, bool thunderAllowed, float speedModifier, float dayLengthInMinutes)
		{
			OverrideGameParams(rainAllowed, thunderAllowed, speedModifier, dayLengthInMinutes);
		}

		public void OverrideGameParams(bool rainAllowed, bool thunderAllowed, float speedModifier, float dayLengthInMinutes)
		{
			RainAllowed = rainAllowed;
			ThunderAllowed = thunderAllowed;
			SpeedModifier = speedModifier;
			if (DayLengthInMinutes != dayLengthInMinutes)
			{
				DayLengthInMinutes = dayLengthInMinutes;
				this.DayLengthChanged?.Invoke();
			}
		}
	}
}
