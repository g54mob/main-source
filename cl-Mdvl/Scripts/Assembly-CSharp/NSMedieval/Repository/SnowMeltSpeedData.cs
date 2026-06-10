using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class SnowMeltSpeedData : DynamicSettingsData<SnowMeltSpeedData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/SnowMeltSpeed.json";
		}
	}
}
