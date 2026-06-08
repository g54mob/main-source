using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct SWeatherPrecipitation : IComponentData
	{
		public bool IsActive;

		public WeatherMode Mode;
	}
}
