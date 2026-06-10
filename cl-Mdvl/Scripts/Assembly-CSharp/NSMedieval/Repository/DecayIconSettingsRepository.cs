using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class DecayIconSettingsRepository : DynamicJsonRepository<DecayIconSettingsRepository, DecayIconSettings>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/DecayIconSettings.json";
		}
	}
}
