using SaveData.FactoryFloor.SaveStates;

namespace Data.Buildings
{
	public class GNNGateBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		private const int CurrentVersion = 0;

		public BuildingBehaviourSaveStateDto BuildingBehaviourSaveStateDto;

		public GNNGateBehaviourSaveStateDto()
			: base(0)
		{
		}
	}
}
