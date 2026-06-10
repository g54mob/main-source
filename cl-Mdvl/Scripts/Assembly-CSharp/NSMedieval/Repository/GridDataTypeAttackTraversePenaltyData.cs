using Models.Blueprint.Settings;
using NSEipix.Repository;

namespace NSMedieval.Repository
{
	public class GridDataTypeAttackTraversePenaltyData : DynamicSettingsData<GridDataTypeAttackTraversePenaltyData, GridDataTypeAttackTraversePenalty>
	{
		protected override string JsonFile()
		{
			return "Settings/GridDataTypeAttackTraversePenalty.json";
		}
	}
}
