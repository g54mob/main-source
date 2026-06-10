using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class CaravanAmbushSettingsData : DynamicSettingsData<CaravanAmbushSettingsData, CaravanAmbushSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/CaravanAmbushSettings.json";
		}
	}
}
