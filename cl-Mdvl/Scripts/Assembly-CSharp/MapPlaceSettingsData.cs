using NSEipix.Repository;

public class MapPlaceSettingsData : SettingsData<MapPlaceSettingsData, MapPlaceSettings>
{
	protected override string JsonFile()
	{
		return "Settings/MapPlaceSettings.json";
	}
}
