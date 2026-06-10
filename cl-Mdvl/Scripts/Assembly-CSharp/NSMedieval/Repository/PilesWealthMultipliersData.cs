using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class PilesWealthMultipliersData : DynamicSettingsData<PilesWealthMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/PilesWealthMultipliers.json";
		}
	}
}
