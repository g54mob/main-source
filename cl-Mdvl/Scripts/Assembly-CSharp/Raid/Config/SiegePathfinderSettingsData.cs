using NSEipix.Repository;

namespace Raid.Config
{
	public class SiegePathfinderSettingsData : SettingsData<SiegePathfinderSettingsData, SiegePathfinderSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/SiegePathfinderSettings.json";
		}
	}
}
