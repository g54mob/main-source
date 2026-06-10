using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class BuildingWealthMultipliersData : DynamicSettingsData<BuildingWealthMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/BuildingWealthMultipliers.json";
		}
	}
}
