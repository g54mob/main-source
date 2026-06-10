using NSEipix.Repository;

namespace NSMedieval.Repository
{
	public class TemperatureSettingsData : DynamicSettingsData<TemperatureSettingsData, TemperatureSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/TemperatureSettings.json";
		}
	}
}
