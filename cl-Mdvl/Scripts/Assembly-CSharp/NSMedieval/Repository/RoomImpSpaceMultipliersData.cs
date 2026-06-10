using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RoomImpSpaceMultipliersData : DynamicSettingsData<RoomImpSpaceMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RoomImpSpaceMultipliers.json";
		}
	}
}
