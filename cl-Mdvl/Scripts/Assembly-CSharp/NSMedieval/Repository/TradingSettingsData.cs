using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class TradingSettingsData : DynamicSettingsData<TradingSettingsData, TradingSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/TradingSettings.json";
		}
	}
}
