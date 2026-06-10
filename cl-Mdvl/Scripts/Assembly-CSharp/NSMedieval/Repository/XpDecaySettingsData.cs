using NSEipix.Repository;

namespace NSMedieval.Repository
{
	public class XpDecaySettingsData : DynamicSettingsData<XpDecaySettingsData, XpDecaySettings>
	{
		protected override string JsonFile()
		{
			return "Settings/XpDecaySettings.json";
		}
	}
}
