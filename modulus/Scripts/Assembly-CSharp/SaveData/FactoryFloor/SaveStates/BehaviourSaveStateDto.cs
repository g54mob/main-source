using System;
using Data.SaveData;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public abstract class BehaviourSaveStateDto : AbstractSaveData
	{
		protected BehaviourSaveStateDto()
			: base(0)
		{
		}

		protected BehaviourSaveStateDto(int currentVersion)
			: base(currentVersion)
		{
		}
	}
}
