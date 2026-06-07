using System;

namespace DV.WeatherSystem
{
	[Serializable]
	public struct WeatherForecastItem
	{
		public float firstSampleTimestamp;

		public float sampledDataDuration;

		public int hourStart;

		public int hourEnd;

		public bool isNight;

		public WeatherForecastIconType iconType;

		public float averageThunder;

		public float averageCloudiness;

		public float averageFog;

		public float averageRain;
	}
}
