using System;
using Data.SaveData;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterSlotsBehaviourSaveStateDto : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int StepsToNextAction;

		public int SlotIndex;

		public int ActionIndex;

		public FreighterHubSlotSaveStateDto[] FreighterHubSlotsSaveData;

		public FreighterSlotsBehaviourSaveStateDto()
			: base(0)
		{
		}
	}
}
