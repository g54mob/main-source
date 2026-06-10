using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class DaysFromVillagerKilledMultipliersData : DynamicSettingsData<DaysFromVillagerKilledMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/DaysFromVillagerKilledMultipliers.json";
		}
	}
}
