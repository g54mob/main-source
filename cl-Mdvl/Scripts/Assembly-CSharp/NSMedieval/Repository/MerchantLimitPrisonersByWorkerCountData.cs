using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class MerchantLimitPrisonersByWorkerCountData : DynamicSettingsData<MerchantLimitPrisonersByWorkerCountData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/MerchantLimitPrisonersByWorkerCount.json";
		}
	}
}
