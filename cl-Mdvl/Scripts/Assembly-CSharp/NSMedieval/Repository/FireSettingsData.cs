using NSEipix.Repository;
using NSMedieval.Fire;

namespace NSMedieval.Repository
{
	public class FireSettingsData : DynamicSettingsData<FireSettingsData, FireSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/FireSettings.json";
		}
	}
}
