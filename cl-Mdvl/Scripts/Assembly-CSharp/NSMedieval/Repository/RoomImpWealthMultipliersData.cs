using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class RoomImpWealthMultipliersData : DynamicSettingsData<RoomImpWealthMultipliersData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/RoomImpWealthMultipliers.json";
		}
	}
}
