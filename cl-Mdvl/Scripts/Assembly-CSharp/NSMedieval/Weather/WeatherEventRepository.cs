using NSEipix.Repository;

namespace NSMedieval.Weather
{
	public class WeatherEventRepository : DynamicJsonRepository<WeatherEventRepository, WeatherEvent>
	{
		protected override string JsonFile()
		{
			return "Data/WeatherEvents.json";
		}
	}
}
