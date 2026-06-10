using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class BaseWealthEffectorsData : DynamicSettingsData<BaseWealthEffectorsData, BaseWealthEffectors>
	{
		protected override string JsonFile()
		{
			return "Settings/BaseWealthEffectors.json";
		}
	}
}
