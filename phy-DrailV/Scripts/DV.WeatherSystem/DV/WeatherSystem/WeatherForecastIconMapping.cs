using UnityEngine;

namespace DV.WeatherSystem
{
	[CreateAssetMenu(fileName = "DV_weather_forecast_icon_mapping", menuName = "DV/Weather Forecast icon mapping")]
	public class WeatherForecastIconMapping : ScriptableObject
	{
		public Sprite Thunder;

		public Sprite Overcast;

		public Sprite PartlyCloudy_Day;

		public Sprite PartlyCloudy_Night;

		public Sprite Clear_Day;

		public Sprite Clear_Night;

		public Sprite LightRain_Day;

		public Sprite LightRain_Night;

		public Sprite HeavyRain;

		public Sprite LightFog_Day;

		public Sprite LightFog_Night;

		public Sprite HeavyFog;

		public Sprite GetIconFor(WeatherForecastIconType enumVal)
		{
			switch (enumVal)
			{
			case WeatherForecastIconType.Thunder:
				return Thunder;
			case WeatherForecastIconType.Overcast:
				return Overcast;
			case WeatherForecastIconType.PartlyCloudy_Day:
				return PartlyCloudy_Day;
			case WeatherForecastIconType.PartlyCloudy_Night:
				return PartlyCloudy_Night;
			case WeatherForecastIconType.Clear_Day:
				return Clear_Day;
			case WeatherForecastIconType.Clear_Night:
				return Clear_Night;
			case WeatherForecastIconType.LightRain_Day:
				return LightRain_Day;
			case WeatherForecastIconType.LightRain_Night:
				return LightRain_Night;
			case WeatherForecastIconType.HeavyRain:
				return HeavyRain;
			case WeatherForecastIconType.LightFog_Day:
				return LightFog_Day;
			case WeatherForecastIconType.LightFog_Night:
				return LightFog_Night;
			case WeatherForecastIconType.HeavyFog:
				return HeavyFog;
			default:
				Debug.LogError(string.Format("Unexpected {0} value '{1}'", "WeatherForecastIconType", enumVal));
				return null;
			}
		}
	}
}
