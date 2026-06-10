using NSEipix.Repository;
using NSMedieval.WorldMap;

namespace NSMedieval.Repository
{
	public class WorldMapSettingsData : DynamicSettingsData<WorldMapSettingsData, WorldMapSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/WorldMapSettings.json";
		}
	}
}
