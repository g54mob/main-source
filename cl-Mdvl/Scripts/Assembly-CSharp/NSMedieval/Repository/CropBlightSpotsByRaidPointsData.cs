using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class CropBlightSpotsByRaidPointsData : DynamicSettingsData<CropBlightSpotsByRaidPointsData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/CropBlightSpotsByRaidPoints.json";
		}
	}
}
