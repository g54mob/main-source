using System;
using Data.FactoryFloor;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class OverflowBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public InputBufferSaveData InputBufferSaveData;
	}
}
