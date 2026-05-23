using System;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class SupplyTankRecipientSaveStateDto : BehaviourSaveStateDto
	{
		public const int CurrentVersion = 0;

		public bool HasCapsule;

		public int CurrentResourceAmount;

		public SupplyTankRecipientSaveStateDto()
			: base(0)
		{
		}
	}
}
