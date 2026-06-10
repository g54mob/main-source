using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class MerchantLimitPrisonersByPrisonerCountData : DynamicSettingsData<MerchantLimitPrisonersByPrisonerCountData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/MerchantLimitPrisonersByPrisonerCount.json";
		}
	}
}
