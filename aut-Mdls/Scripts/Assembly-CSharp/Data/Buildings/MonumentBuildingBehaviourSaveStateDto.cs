using SaveData.FactoryFloor.SaveStates;

namespace Data.Buildings
{
	public class MonumentBuildingBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		private const int CurrentVersion = 0;

		public int CurrentDataShardAmount;

		public int CurrentStepsUntilChargeRunsOut;

		public BuildingBehaviourSaveStateDto BuildingBehaviourSaveStateDto;

		public MonumentBuildingBehaviourSaveStateDto()
			: base(0)
		{
		}
	}
}
