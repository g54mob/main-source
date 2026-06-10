using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RaidMaxPrisonersBySettlersAliveData : DynamicSettingsData<RaidMaxPrisonersBySettlersAliveData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RaidMaxPrisonersBySettlersAlive.json";
		}
	}
}
