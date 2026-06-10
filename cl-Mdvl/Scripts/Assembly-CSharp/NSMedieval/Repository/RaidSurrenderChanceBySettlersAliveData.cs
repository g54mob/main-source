using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RaidSurrenderChanceBySettlersAliveData : DynamicSettingsData<RaidSurrenderChanceBySettlersAliveData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RaidSurrenderChanceBySettlersAlive.json";
		}
	}
}
