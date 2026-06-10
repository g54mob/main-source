using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RaidSurrenderChanceByPrisonersCountData : DynamicSettingsData<RaidSurrenderChanceByPrisonersCountData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RaidSurrenderChanceByPrisonersCount.json";
		}
	}
}
