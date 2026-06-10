using NSEipix.Repository;

namespace Raid.Config
{
	public class RaidSpawnSettingsData : SettingsData<RaidSpawnSettingsData, RaidSpawnSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/RaidSpawnSettings.json";
		}
	}
}
