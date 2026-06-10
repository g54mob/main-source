using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class ConstructableQualitySettingsRepository : DynamicJsonRepository<ConstructableQualitySettingsRepository, ConstructableQuality>
	{
		protected override string JsonFile()
		{
			return "Constructables/ConstructableQualitySettings.json";
		}
	}
}
