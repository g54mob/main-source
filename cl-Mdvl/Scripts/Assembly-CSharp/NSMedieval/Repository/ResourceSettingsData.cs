using NSEipix.Repository;

namespace NSMedieval.Repository
{
	public class ResourceSettingsData : DynamicSettingsData<ResourceSettingsData, ResourceSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/ResourceSettings.json";
		}
	}
}
