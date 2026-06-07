using Data.Variables;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/BuildingMaxLockedStage", fileName = "BuildingMaxLockedStageData", order = 0)]
	public class BuildingMaxLockedStageData : IntVariableSO
	{
		public int MaxLockedBuildingStage => Value;

		public void Apply(int maxLockedBuildingStage)
		{
			SetValue(maxLockedBuildingStage);
		}

		public new void ResetToDefault()
		{
			SetValue(_defaultValue);
		}
	}
}
