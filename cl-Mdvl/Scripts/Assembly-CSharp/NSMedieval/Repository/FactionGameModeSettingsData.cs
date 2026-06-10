using NSEipix.Repository;
using NSMedieval.Factions;

namespace NSMedieval.Repository
{
	public class FactionGameModeSettingsData : DynamicSettingsData<FactionGameModeSettingsData, FactionGameModeSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/FactionGameModeSettings.json";
		}
	}
}
