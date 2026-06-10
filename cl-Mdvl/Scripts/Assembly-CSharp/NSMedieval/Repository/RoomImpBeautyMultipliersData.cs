using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RoomImpBeautyMultipliersData : DynamicSettingsData<RoomImpBeautyMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RoomImpBeautyMultipliers.json";
		}
	}
}
